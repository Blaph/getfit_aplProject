package dbmanager

import (
	"database/sql"
	"fmt"
	"strconv"

	"github.com/go-sql-driver/mysql"
)

const (
	DBUSER    = "root"
	DBPASS    = "12345678"
	DB_HOST   = "127.0.0.1"
	DB_PORT   = "3306"
	CONN_TYPE = "tcp"
	DB_NAME   = "getfit-localdb"
)

type User struct {
	Id            int
	Email         string
	Pass          string
	Age           int
	Sex           string
	Height        float32
	Weight        float32
	Intensity     float32
	Bmr           int
	CaloricIntake int
}

type IngredientDescription struct {
	Id             int
	IngredientName string
	Kcal           int
	Carbs          float32
	Proteins       float32
	Fats           float32
	UserID         int
}

type Recipe struct {
	RecipeID   int
	RecipeName string
	AvgKcal    int
	Breakfast  bool
	Lunch      bool
	Dinner     bool
	UserID     int
}

type Ingredient struct {
	IngredientDesc IngredientDescription
	Quantity       float32
}

type RecipeStep struct {
	StepID   int
	StepDesc string
}

type Menu struct {
	Breakfast string
	Lunch     string
	Dinner    string
}

func ConnectToDB() *sql.DB {
	// Cattura le proprietà della connessione
	cfg := mysql.Config{
		User:   DBUSER,
		Passwd: DBPASS,
		Net:    CONN_TYPE,
		Addr:   DB_HOST + ":" + DB_PORT,
		DBName: DB_NAME,
	}

	// Otteniamo un aggancio al DB
	// db è del tipo '*sql.DB', quindi è un puntatore al DB
	db, err := sql.Open("mysql", cfg.FormatDSN())
	if err != nil {
		fmt.Println("Error while connecting to the db!")
		panic(err)
	}

	// Testiamo la connessione al DB
	pingErr := db.Ping() // Restituisce un oggetto del tipo 'error'
	if pingErr != nil {
		fmt.Println("Error while testing the DB connection!")
		panic(pingErr)
	}
	fmt.Println("Connected to db: ", DB_NAME)
	return db
}

func GetTotalUsers(db *sql.DB) (int, error) {
	var totalUsers int
	row := db.QueryRow("SELECT max(id) as totalUsers FROM users")
	if err := row.Scan(&totalUsers); err != nil {
		if err == sql.ErrNoRows {
			fmt.Println("No user found! :C")
			panic(err)
		}
		fmt.Println("Error while looking for a user! :C")
		panic(err)
	}
	return totalUsers, nil
}

func GetTotalAge(db *sql.DB) (int, error) {
	var totalAge int
	row := db.QueryRow("SELECT sum(age) as totalAge FROM users")
	if err := row.Scan(&totalAge); err != nil {
		if err == sql.ErrNoRows {
			fmt.Println("No users found! :C")
			panic(err)
		}
		fmt.Println("Error while trying to count total users age!")
		panic(err)
	}
	return totalAge, nil
}

func GetTotalGenders(db *sql.DB) (int, error) {
	var totalMale int
	row := db.QueryRow("SELECT count(sex) as totalMale FROM users GROUP BY sex") // Ci serve solo la prima riga, che restituisce il numero di utenti maschi
	if err := row.Scan(&totalMale); err != nil {
		if err == sql.ErrNoRows {
			fmt.Println("Error! No row found!")
			panic(err)
		}
		fmt.Println("Error while counting users' genders! :C")
		panic(err)
	}
	return totalMale, nil
}

func GetMenuRecipe(recipeID int, db *sql.DB) string {
	var recipeName string
	row := db.QueryRow("SELECT recipeName FROM recipes WHERE recipeID = ?", recipeID)
	if err := row.Scan(&recipeName); err != nil {
		if err == sql.ErrNoRows {
			fmt.Println("No recipe found!")
			return "noPreferences"
		}
		fmt.Println("Error while looking for a recipe! :C")
		panic(err)
	}
	return recipeName
}

func getDishes(ingredientIDListP *[]int, db *sql.DB) *[]Recipe {
	// Otteniamo le ricette realizzabili con ciascun ingrediente
	var recipesID []int
	var recipeID int
	var recipeDescriptions []Recipe
	var recipeDescription Recipe
	for _, ingredientID := range *ingredientIDListP {
		rows, err := db.Query("SELECT recipeID FROM recipeIngredients WHERE ingredientID = ?", ingredientID)
		if err != nil {
			fmt.Println("Error while retrieving recipeID from db.")
			panic(err)
		}
		defer rows.Close()

		for rows.Next() {
			if err := rows.Scan(&recipeID); err != nil {
				fmt.Println("Error while looking for a recipe! :C")
				panic(err)
			}
			recipesID = append(recipesID, recipeID)
		}

		// Ricaviamo la descrizione di ogni piatto
		for _, recipeID := range recipesID {
			rows, err := db.Query("SELECT recipeID, avgKcal, breakfast, lunch, dinner FROM recipes WHERE recipeID = ?", recipeID)
			if err != nil {
				fmt.Println("Error while retrieving recipes from db.")
				panic(err)
			}
			defer rows.Close()

			for rows.Next() {
				if err := rows.Scan(&recipeDescription.RecipeID, &recipeDescription.AvgKcal, &recipeDescription.Breakfast, &recipeDescription.Lunch, &recipeDescription.Dinner); err != nil {
					fmt.Println("Error while looking for a recipe! :C")
					panic(err)
				}
				recipeDescriptions = append(recipeDescriptions, recipeDescription)
			}
		}
	}
	return &recipeDescriptions
}

func RandomizeMenu(message []string, db *sql.DB) (string, string, string) {
	userID, err := strconv.Atoi(message[0])
	if err != nil {
		fmt.Println("Could not convert userID from string to int!")
		panic(err)
	}

	// Otteniamo gli ID degli ingredienti preferiti dall'utente
	var ingredientDescriptionsID []int
	var ingredientID int
	rows, err := db.Query("SELECT ingredientID FROM ingredientPreferences WHERE ingredientPreferences.userID= ?", userID)
	if err != nil {
		fmt.Println("Could not retrieve ingredient list!")
		panic(err)
	}
	defer rows.Close()

	for rows.Next() {
		if err := rows.Scan(&ingredientID); err != nil {
			if err == sql.ErrNoRows {
				fmt.Println("No ingredients found! :C")
				return "noPreferences", "", ""
			}
			fmt.Println("Error while looking for an ingredient! :C")
			panic(err)
		}
		ingredientDescriptionsID = append(ingredientDescriptionsID, ingredientID)
	}

	if len(ingredientDescriptionsID) == 0 {
		return "noPreferences", "", ""
	}

	recipeListP := getDishes(&ingredientDescriptionsID, db)

	// Dividiamo i piatti per pasto
	var breakfasts []Recipe
	var lunchs []Recipe
	var dinners []Recipe

	for _, ingredientDescription := range *recipeListP {
		if ingredientDescription.Breakfast {
			breakfasts = append(breakfasts, ingredientDescription)
		}
		if ingredientDescription.Lunch {
			lunchs = append(lunchs, ingredientDescription)
		}
		if ingredientDescription.Dinner {
			dinners = append(dinners, ingredientDescription)
		}
	}

	// Prepariamo i messaggi da inviare
	var breakfastDishes string
	var lunchDishes string
	var dinnerDishes string
	for _, breakfast := range breakfasts {
		breakfastDishes += strconv.Itoa(breakfast.RecipeID) + "-" + strconv.Itoa(breakfast.AvgKcal) + ","
	}
	breakfastDishes += "endOfArray"

	for _, lunch := range lunchs {
		lunchDishes += strconv.Itoa(lunch.RecipeID) + "-" + strconv.Itoa(lunch.AvgKcal) + ","
	}
	lunchDishes += "endOfArray"

	for _, dinner := range dinners {
		dinnerDishes += strconv.Itoa(dinner.RecipeID) + "-" + strconv.Itoa(dinner.AvgKcal) + ","
	}
	dinnerDishes += "endOfArray"
	return breakfastDishes, lunchDishes, dinnerDishes
}

func AddFavouriteRecipe(message []string, db *sql.DB) (string, error) {
	userID, err := strconv.Atoi(message[0])
	if err != nil {
		fmt.Println("Could not convert userID from string to int!")
		panic(err)
	}
	recipeID, err := strconv.Atoi(message[1])
	if err != nil {
		fmt.Println("Could not convert recipeID from string to int!")
		panic(err)
	}
	result, err := db.Exec("INSERT INTO recipePreferences (userID, recipeID) VALUES (?, ?)", userID, recipeID)
	if err != nil {
		fmt.Println("Error while inserting new datas :C")
		panic(err)
	}
	_, err = result.LastInsertId()
	if err != nil {
		fmt.Println("Cannot retrieve last id inserted :C")
		return "favouriteRecipeError", err
	}
	return "favouriteRecipeAdded", nil
}

func RemoveFavouriteRecipe(message []string, db *sql.DB) (string, error) {
	userID, err := strconv.Atoi(message[0])
	if err != nil {
		fmt.Println("Could not convert userID from string to int!")
		panic(err)
	}
	recipeID, err := strconv.Atoi(message[1])
	if err != nil {
		fmt.Println("Could not convert recipeID from string to int!")
		panic(err)
	}
	result, err := db.Exec("DELETE FROM recipePreferences WHERE recipePreferences.userID = ? AND recipePreferences.recipeID = ?", userID, recipeID)
	if err != nil {
		fmt.Println("Error while deleting datas :C")
		panic(err)
	}
	_, err = result.LastInsertId()
	if err != nil {
		fmt.Println("Cannot retrieve last id inserted :C")
		return "removeFavouriteRecipeError", err
	}
	return "favouriteRecipeRemoved", nil
}

func IsFavouriteRecipe(message []string, db *sql.DB) (bool, error) {
	var recipeUserID int
	var storedrecipeID string
	userID, err := strconv.Atoi(message[0])
	if err != nil {
		fmt.Println("Could not convert userID from string to int!")
		panic(err)
	}
	recipeID, err := strconv.Atoi(message[1])
	if err != nil {
		fmt.Println("Could not convert recipeID from string to int!")
		panic(err)
	}
	row := db.QueryRow("SELECT userID, recipeID FROM recipePreferences WHERE recipePreferences.userID = ? AND recipePreferences.ingredientID = ?", userID, recipeID)
	if err := row.Scan(&recipeUserID, &storedrecipeID); err != nil {
		if err == sql.ErrNoRows {
			fmt.Println("No recipe found! :C")
			return false, nil
		}
		fmt.Println("Error while looking for a recipe! :C")
		panic(err)
	}
	return true, nil
}

func ShowSteps(recipeID int, db *sql.DB) (*[]RecipeStep, error) {
	var recipeSteps []RecipeStep
	rows, err := db.Query("SELECT stepID, stepDesc FROM recipeSteps WHERE recipeID = ? ORDER BY stepID", recipeID)
	if err != nil {
		fmt.Println("Could not retrieve ingredient list!")
		panic(err)
	}
	defer rows.Close()

	for rows.Next() {
		var recipeStep RecipeStep
		if err := rows.Scan(&recipeStep.StepID, &recipeStep.StepDesc); err != nil {
			fmt.Println("Error while looking for a recipe step! :C")
			panic(err)
		}
		recipeSteps = append(recipeSteps, recipeStep)
	}
	return &recipeSteps, nil
}

func ShowRecipeIngredients(recipeID int, db *sql.DB) (*[]Ingredient, error) {
	var recipeIngredients []Ingredient
	rows, err := db.Query("SELECT recipeIngredients.ingredientID as ingredientID, recipeIngredients.ingQuantity as ingQuantity, ingredients.ingredientName as ingredientName FROM recipeIngredients JOIN ingredients ON recipeIngredients.ingredientID=ingredients.ingredientID WHERE recipeIngredients.recipeID = ? ", recipeID)
	if err != nil {
		fmt.Println("Could not retrieve recipe ingredients!")
		panic(err)
	}
	defer rows.Close()

	for rows.Next() {
		var ingredient Ingredient
		if err := rows.Scan(&ingredient.IngredientDesc.Id, &ingredient.Quantity, &ingredient.IngredientDesc.IngredientName); err != nil {
			fmt.Println("Error while looking for a recipe ingredient! :C")
			panic(err)
		}
		recipeIngredients = append(recipeIngredients, ingredient)
	}

	return &recipeIngredients, nil
}

func AddRecipeSteps(message []string, db *sql.DB) (string, error) {
	recipeID, err := strconv.Atoi(message[0])
	if err != nil {
		fmt.Println("Could not convert recipeID from string to int!")
		panic(err)
	}

	stepID, err := strconv.Atoi(message[1])
	if err != nil {
		fmt.Println("Could not convert ingredientID from string to int!")
		panic(err)
	}

	stepDesc := message[2]

	result, err := db.Exec("INSERT INTO recipeSteps (recipeID, stepID, stepDesc) VALUES (?, ?, ?)", recipeID, stepID, stepDesc)
	if err != nil {
		fmt.Println("Error while inserting new datas :C")
		panic(err)
	}
	_, err = result.LastInsertId()
	if err != nil {
		fmt.Println("Cannot retrieve last id inserted :C")
		return "addRecipeStepError", err
	}
	return "recipeStepAdded", nil
}

func AddRecipeIngredients(message []string, db *sql.DB) (string, error) {
	recipeID, err := strconv.Atoi(message[0])
	if err != nil {
		fmt.Println("Could not convert recipeID from string to int!")
		panic(err)
	}

	ingredientID, err := strconv.Atoi(message[1])
	if err != nil {
		fmt.Println("Could not convert ingredientID from string to int!")
		panic(err)
	}

	ingQuantity, err := strconv.Atoi(message[2])
	if err != nil {
		fmt.Println("Could not convert ingQuantity from string to int!")
		panic(err)
	}

	result, err := db.Exec("INSERT INTO recipeIngredients (recipeID, ingredientID, ingQuantity) VALUES (?, ?, ?)", recipeID, ingredientID, ingQuantity)
	if err != nil {
		fmt.Println("Error while inserting new datas :C")
		return "duplicateIngredient", err
	}
	_, err = result.LastInsertId()
	if err != nil {
		fmt.Println("Cannot retrieve last id inserted :C")
		return "addRecipeIngredientError", err
	}
	return "recipeIngredientAdded", nil
}

func AddNewRecipe(message []string, newRecipe Recipe, db *sql.DB) (int64, error) {
	result, err := db.Exec("INSERT INTO recipes (recipeName, avgKcal, breakfast, lunch, dinner, userID) VALUES (?, ?, ?, ?, ?, ?)", newRecipe.RecipeName, newRecipe.AvgKcal, newRecipe.Breakfast, newRecipe.Lunch, newRecipe.Dinner, newRecipe.UserID)
	if err != nil {
		fmt.Println("Error while inserting new datas :C")
		panic(err)
	}
	id, err := result.LastInsertId()
	if err != nil {
		fmt.Println("Cannot retrieve last id inserted :C")
		panic(err)
	}
	return id, nil
}

func ShowRecipe(message string, db *sql.DB) (Recipe, error) {
	var recipe Recipe
	recipeName := message
	row := db.QueryRow("SELECT recipeID, recipeName, avgKcal, breakfast, lunch, dinner, userID FROM recipes WHERE recipeName = ?", recipeName)
	if err := row.Scan(&recipe.RecipeID, &recipe.RecipeName, &recipe.AvgKcal, &recipe.Breakfast, &recipe.Lunch, &recipe.Dinner, &recipe.UserID); err != nil {
		if err == sql.ErrNoRows {
			fmt.Println("No recipe found!")
			return recipe, err
		}
		fmt.Println("Error while looking for a recipe! :C")
		panic(err)
	}
	return recipe, nil
}

func VerifyRecipe(message string, db *sql.DB) (Recipe, string) {
	recipe, err := ShowRecipe(message, db)
	if err == sql.ErrNoRows {
		return recipe, "newRecipe"
	}
	return recipe, "recipeExistent"
}

func ShowAllRecipes(db *sql.DB) (*[]Recipe, error) {
	var recipes []Recipe

	rows, err := db.Query("SELECT * FROM recipes ORDER BY recipeName")
	if err != nil {
		fmt.Println("Could not retrieve ingredient list!")
		panic(err)
	}
	defer rows.Close()

	for rows.Next() {
		var recipe Recipe
		if err := rows.Scan(&recipe.RecipeID, &recipe.RecipeName, &recipe.AvgKcal, &recipe.Lunch, &recipe.Lunch, &recipe.Dinner, &recipe.UserID); err != nil {
			fmt.Println("Error while retrieving a single ingredient row!")
			panic(err)
		}
		recipes = append(recipes, recipe)
	}

	// Se viene lanciato un errore durante l'esecuzione della query, lo stampiamo
	if err := rows.Err(); err != nil {
		fmt.Println("Error while executing the query!")
		panic(err)
	}
	return &recipes, nil
}

func ShowAllIngredientsDescription(db *sql.DB) (*[]IngredientDescription, error) {
	var ingredients []IngredientDescription

	rows, err := db.Query("SELECT * FROM ingredients ORDER BY ingredients.IngredientName")
	if err != nil {
		fmt.Println("Could not retrieve ingredient list!")
		panic(err)
	}
	defer rows.Close()

	for rows.Next() {
		var ingredient IngredientDescription
		if err := rows.Scan(&ingredient.Id, &ingredient.IngredientName, &ingredient.Kcal, &ingredient.Carbs, &ingredient.Proteins, &ingredient.Fats, &ingredient.UserID); err != nil {
			fmt.Println("Error while retrieving a single ingredient row!")
			panic(err)
		}
		ingredients = append(ingredients, ingredient)
	}

	// Se viene lanciato un errore durante l'esecuzione della query, lo stampiamo
	if err := rows.Err(); err != nil {
		fmt.Println("Error while executing the query!")
		panic(err)
	}
	ingredientP := &ingredients
	return ingredientP, nil
}

func ShowIngredient(message string, db *sql.DB) (IngredientDescription, error) {
	var ingredientDescription IngredientDescription
	ingredientName := message
	row := db.QueryRow("SELECT ingredientID, ingredientName, kcal, carbs, proteins, fats, userID FROM ingredients WHERE ingredients.ingredientName = ?", ingredientName)
	if err := row.Scan(&ingredientDescription.Id, &ingredientDescription.IngredientName, &ingredientDescription.Kcal, &ingredientDescription.Carbs, &ingredientDescription.Proteins, &ingredientDescription.Fats, &ingredientDescription.UserID); err != nil {
		if err == sql.ErrNoRows {
			fmt.Println("No ingredient found!")
			return ingredientDescription, err
		}
		fmt.Println("Error while looking for an ingredient! :C")
		panic(err)
	}
	return ingredientDescription, nil
}

func AddNewIngredient(message []string, newIngredient IngredientDescription, db *sql.DB) (int64, error) {
	result, err := db.Exec("INSERT INTO ingredients (ingredientName, kcal, carbs, proteins, fats, userID) VALUES (?, ?, ?, ?, ?, ?)", newIngredient.IngredientName, newIngredient.Kcal, newIngredient.Carbs, newIngredient.Proteins, newIngredient.Fats, newIngredient.UserID)
	if err != nil {
		fmt.Println("Error while inserting new datas :C")
		panic(err)
	}
	id, err := result.LastInsertId()
	if err != nil {
		fmt.Println("Cannot retrieve last id inserted :C")
		panic(err)
	}
	return id, nil
}

func VerifyIngredient(message string, db *sql.DB) (IngredientDescription, string) {
	ingredientDescription, err := ShowIngredient(message, db)
	if err == sql.ErrNoRows {
		return ingredientDescription, "newIngredient"
	}
	return ingredientDescription, "ingredientExistent"
}

func AddFavouriteIngredient(message []string, db *sql.DB) (string, error) {
	userID, err := strconv.Atoi(message[0])
	if err != nil {
		fmt.Println("Could not convert userID from string to int!")
		panic(err)
	}
	ingredientID, err := strconv.Atoi(message[1])
	if err != nil {
		fmt.Println("Could not convert ingredientID from string to int!")
		panic(err)
	}
	result, err := db.Exec("INSERT INTO ingredientPreferences (userID, ingredientID) VALUES (?, ?)", userID, ingredientID)
	if err != nil {
		fmt.Println("Error while inserting new datas :C")
		panic(err)
	}
	_, err = result.LastInsertId()
	if err != nil {
		fmt.Println("Cannot retrieve last id inserted :C")
		return "favouriteIngredientError", err
	}
	return "favouriteIngredientAdded", nil
}

func RemoveFavouriteIngredient(message []string, db *sql.DB) (string, error) {
	userID, err := strconv.Atoi(message[0])
	if err != nil {
		fmt.Println("Could not convert userID from string to int!")
		panic(err)
	}
	ingredientID, err := strconv.Atoi(message[1])
	if err != nil {
		fmt.Println("Could not convert ingredientID from string to int!")
		panic(err)
	}
	result, err := db.Exec("DELETE FROM ingredientPreferences WHERE ingredientPreferences.userID = ? AND ingredientPreferences.ingredientID = ?", userID, ingredientID)
	if err != nil {
		fmt.Println("Error while deleting datas :C")
		panic(err)
	}
	_, err = result.LastInsertId()
	if err != nil {
		fmt.Println("Cannot retrieve last id inserted :C")
		return "removeFavouriteIngredientError", err
	}
	return "favouriteIngredientRemoved", nil
}

func IsFavouriteIngredient(message []string, db *sql.DB) (bool, error) {
	var ingredientUserID int
	var storedIngredientID string
	userID, err := strconv.Atoi(message[0])
	if err != nil {
		fmt.Println("Could not convert userID from string to int!")
		panic(err)
	}
	ingredientID, err := strconv.Atoi(message[1])
	if err != nil {
		fmt.Println("Could not convert ingredientID from string to int!")
		panic(err)
	}
	row := db.QueryRow("SELECT userID, ingredientID FROM ingredientPreferences WHERE ingredientPreferences.userID = ? AND ingredientPreferences.ingredientID = ?", userID, ingredientID)
	if err := row.Scan(&ingredientUserID, &storedIngredientID); err != nil {
		if err == sql.ErrNoRows {
			fmt.Println("No ingredient found! :C")
			return false, nil
		}
		fmt.Println("Error while looking for an ingredient! :C")
		panic(err)
	}
	return true, nil
}

func SelectUser(message []string, db *sql.DB) (User, error) {
	var singleUser User
	email := message[0]
	pass := message[1]

	row := db.QueryRow("SELECT id, age, sex, height, weight, intensity, caloricIntake FROM users WHERE users.email = ? AND users.pass = ?", email, pass)
	if err := row.Scan(&singleUser.Id, &singleUser.Age, &singleUser.Sex, &singleUser.Height, &singleUser.Weight, &singleUser.Intensity, &singleUser.CaloricIntake); err != nil {
		if err == sql.ErrNoRows {
			fmt.Println("No user found! :C")
			return singleUser, err
		}
		fmt.Println("Errore while looking for a user! :C")
		panic(err)
	}
	return singleUser, nil
}

func AddUser(newUser User, db *sql.DB) (int64, error) {
	result, err := db.Exec("INSERT INTO users (email, pass, age, sex, height, weight, intensity, bmr, caloricIntake) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)", newUser.Email, newUser.Pass, newUser.Age, newUser.Sex, newUser.Height, newUser.Weight, newUser.Intensity, newUser.Bmr, newUser.CaloricIntake)
	if err != nil {
		fmt.Println("Error while inserting new datas :C")
		panic(err)
	}
	id, err := result.LastInsertId()
	if err != nil {
		fmt.Println("Cannot retrieve last id inserted :C")
		panic(err)
	}
	return id, nil
}
