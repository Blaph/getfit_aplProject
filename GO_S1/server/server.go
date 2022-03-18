package main

import (
	"database/sql"
	"fmt"
	"getfit_server1/client"
	"getfit_server1/dbmanager"
	"net"
	"strconv"
	"strings"
)

const (
	SERVER_HOST = "127.0.0.1"
	SERVER_PORT = "10000"
	SERVER_TYPE = "tcp"
	BUF_SIZE    = 2048
)

func main() {
	// Avvia il server
	fmt.Println("Server starting...")
	server, err := net.Listen(SERVER_TYPE, SERVER_HOST+":"+SERVER_PORT)
	if err != nil {
		fmt.Println("Connection error! Cannot run to the server.")
		fmt.Println("Exiting server boot...")
		panic(err.Error())
	}
	fmt.Println("GetFit! Go Server 1.0 listening.")
	fmt.Printf("Type: %s\tIP: %s:%s\n", SERVER_TYPE, SERVER_HOST, SERVER_PORT)
	defer server.Close()

	// Stabilisci una connessione col DB
	db := dbmanager.ConnectToDB()
	defer db.Close()

	// Aggiorna il numero di utenti totali nella piattaforma
	totalUsers, err := dbmanager.GetTotalUsers(db)
	if err != nil {
		fmt.Println("Error! Cannot retrieve total users number")
		panic(err)
	}
	message := "setTotalUsers," + strconv.Itoa(totalUsers) // Costriusco il comando da inviare al server python
	_ = client.SendMessage(message)

	// Aggiorna l'età totale degli utenti della piattaforma
	totalAge, err := dbmanager.GetTotalAge(db)
	if err != nil {
		fmt.Println("Error! Cannot retrieve total users age")
		panic(err)
	}
	message = "setTotalAge," + strconv.Itoa(totalAge)
	_ = client.SendMessage(message)

	// Aggiorna il numero di utenti maschili e femminili
	totalMale, err := dbmanager.GetTotalGenders(db)
	if err != nil {
		fmt.Println("Error! Cannot retrieve total genders number")
		panic(err)
	}
	message = "setTotalGenders," + strconv.Itoa(totalMale)
	_ = client.SendMessage(message)

	// Gestiamo le richieste in arrivo dal client C#
	for {
		conn, err := server.Accept() // Accetta la connessione in ingresso di un client
		if err != nil {
			fmt.Println("Error accepting clients! Cannot accept any client incoming request.")
			fmt.Println("Exiting server...")
			panic(err.Error())
		}
		fmt.Printf("Client %s connected.\n", conn.RemoteAddr().String())
		go processClient(conn, db) // Avvia una goroutine in cui ottiene il messaggio in arrivo e lo gestisce
	}
}

// Si riferisce ai client in arrivo (quindi, gestisce ciò che arriva dal client C#)
func processClient(conn net.Conn, db *sql.DB) {
	buffer := make([]byte, BUF_SIZE)
	messageLen, err := conn.Read(buffer)
	if err != nil {
		fmt.Println("Error reading incoming message! Error:")
		panic(err.Error())
	}
	message := splitString(string(buffer[:messageLen]))
	handleMessage(message, db, conn)
	conn.Close()
}

func splitString(message string) []string {
	return strings.Split(message, ",")
}

func handleMessage(message []string, db *sql.DB, conn net.Conn) {
	command := message[0]
	switch command {
	// Iscrizione dell'utente
	case "signup":
		user := signUp(message[1:])
		_, err := dbmanager.AddUser(user, db)
		if err != nil {
			fmt.Println("Could not add user to db!")
			panic(err)
		}

	// Caricamento delle informazioni personali dell'utente
	case "selectUser":
		msg := selectUser(message[1:], db)
		_, err := conn.Write([]byte(msg))
		if err != nil {
			fmt.Println("Error while sending user datas to client!")
			panic(err)
		}

	// Mostrare tutti gli ingredienti presenti nel db
	case "showAllIngredients":
		ingredientP := showAllIngredientsDescription(db)
		showIngredientsDescription(ingredientP, conn)

	// Mostrare un ingrediente dato il suo nome
	case "showIngredient":
		msg := showIngredient(message[1], db)
		_, err := conn.Write([]byte(msg))
		if err != nil {
			fmt.Println("Error while looking for an ingredient description!")
			panic(err)
		}

	// Verificare che un ingrediente sia tra i preferiti di un utente o meno
	case "isFavouriteIngredient":
		msg := isFavouriteIngredient(message[1:], db)
		_, err := conn.Write([]byte(msg))
		if err != nil {
			fmt.Println("Could not detect if the ingredient is a favourite one!")
			panic(err)
		}

	// Aggiungere un ingrediento ai preferiti
	case "addFavouriteIngredient":
		msg := addFavouriteIngredient(message[1:], db)
		_, err := conn.Write([]byte(msg))
		if err != nil {
			fmt.Println("Could not add ingredient to user's favourites! :C")
			panic(err)
		}

	// Rimuovere un ingrediente dai preferiti
	case "removeFavouriteIngredient":
		msg := removeFavouriteIngredient(message[1:], db)
		_, err := conn.Write([]byte(msg))
		if err != nil {
			fmt.Println("Could not remove ingredient from user's favourites! :C")
			panic(err)
		}

	// Verifica se un ingrediente è già presente nel db
	case "addNewIngredient":
		msg := addNewIngredient(message[1:], db)
		_, err := conn.Write([]byte(msg))
		if err != nil {
			fmt.Println("Could not verify if ingredient is already in db! :C")
			panic(err)
		}

	// Mostrare tutti le ricette presenti nel db
	case "showAllRecipes":
		recipeP := showAllRecipes(db)
		showRecipes(recipeP, conn)

	// Verifica se una ricetta è già presente nel db
	case "addNewRecipe":
		msg := addNewRecipe(message[1:], db)
		_, err := conn.Write([]byte(msg))
		if err != nil {
			fmt.Println("Could not verify if ingredient is already in db! :C")
			panic(err)
		}

	// Associa gli ingredienti alla ricetta appena aggiunta
	case "addRecipeIngredients":
		msg := addRecipeIngredients(message[1:], db)
		_, err := conn.Write([]byte(msg))
		if err != nil {
			fmt.Println("Could not link an ingredient to its recipe! :C")
			panic(err)
		}

	// Associa gli ingredienti alla ricetta appena aggiunta
	case "addRecipeSteps":
		msg := addRecipeSteps(message[1:], db)
		_, err := conn.Write([]byte(msg))
		if err != nil {
			fmt.Println("Could not link a step to its recipe! :C")
			panic(err)
		}

	// Mostra la ricetta
	case "showRecipe":
		showRecipe(message[1:], db, conn)

	// Verificare che una ricetta sia tra i preferiti di un utente o meno
	case "isFavouriteRecipe":
		msg := isFavouriteRecipe(message[1:], db)
		_, err := conn.Write([]byte(msg))
		if err != nil {
			fmt.Println("Could not detect if the recipe is a favourite one!")
			panic(err)
		}

	// Aggiungere un ingrediento ai preferiti
	case "addFavouriteRecipe":
		msg := addFavouriteRecipe(message[1:], db)
		_, err := conn.Write([]byte(msg))
		if err != nil {
			fmt.Println("Could not add recipe to user's favourites! :C")
			panic(err)
		}

	// Rimuovere un ingrediente dai preferiti
	case "removeFavouriteRecipe":
		msg := removeFavouriteRecipe(message[1:], db)
		_, err := conn.Write([]byte(msg))
		if err != nil {
			fmt.Println("Could not remove recipe from user's favourites! :C")
			panic(err)
		}

	case "makeNewMenu":
		msg := randomizeMenu(message[1:], db)
		_, err := conn.Write([]byte(msg))
		if err != nil {
			fmt.Println("Could not remove recipe from user's favourites! :C")
			panic(err)
		}

	default:
		panic("Error! Command not identified!")
	}
}

func randomizeMenu(message []string, db *sql.DB) string {
	breakfast, lunch, dinner := dbmanager.RandomizeMenu(message, db)
	if breakfast == "noPreferences" {
		fmt.Println("User has no favourite ingredients.")
		return breakfast // Ritorna l'errore
	}

	var menu [3]string
	caloricIntake := message[1]
	menu[0] = client.SendMessage("randomizeDish," + caloricIntake + "," + breakfast)
	menu[1] = client.SendMessage("randomizeDish," + caloricIntake + "," + lunch)
	menu[2] = client.SendMessage("randomizeDish," + caloricIntake + "," + dinner)

	breakfastID, err := strconv.Atoi(menu[0])
	if err != nil {
		fmt.Println("Error while converting breakfastID from string to int!")
		panic(err)
	}

	lunchID, err := strconv.Atoi(menu[1])
	if err != nil {
		fmt.Println("Error while converting lunchID from string to int!")
		panic(err)
	}

	dinnerID, err := strconv.Atoi(menu[2])
	if err != nil {
		fmt.Println("Error while converting dinnerID from string to int!")
		panic(err)
	}

	breakfast = dbmanager.GetMenuRecipe(breakfastID, db)
	lunch = dbmanager.GetMenuRecipe(lunchID, db)
	dinner = dbmanager.GetMenuRecipe(dinnerID, db)

	msg := breakfast + "," + lunch + "," + dinner

	return msg
}

func addFavouriteRecipe(message []string, db *sql.DB) string {
	response, err := dbmanager.AddFavouriteRecipe(message, db)
	if response == "favouriteRecipeError" {
		return response
	} else if err != nil {
		fmt.Println("Could not add recipe to user's favourites! :C")
		panic(err)
	}
	return "favouriteRecipeAdded"
}

func removeFavouriteRecipe(message []string, db *sql.DB) string {
	response, err := dbmanager.RemoveFavouriteRecipe(message, db)
	if response == "removeFavouriteRecipeError" {
		return response
	} else if err != nil {
		fmt.Println("Could not remove recipe from user's favourites! :C")
		panic(err)
	}
	return "favouriteRecipeRemoved"
}

func isFavouriteRecipe(message []string, db *sql.DB) string {
	response, err := dbmanager.IsFavouriteIngredient(message, db)
	if response {
		return "favouriteRecipeFound"
	} else {
		if err != nil {
			fmt.Println("Could not detect if the recipe is a favourite one!")
			panic(err)
		}
		return "favouriteRecipeNotFound"
	}
}

func showRecipe(message []string, db *sql.DB, conn net.Conn) {
	// Cerchiamo la ricetta nel db
	recipe, _ := dbmanager.VerifyRecipe(message[0], db)

	// Otteniamo un puntatore all'elenco di passi della ricetta
	recipeSteps, err := dbmanager.ShowSteps(recipe.RecipeID, db)
	if err != nil {
		fmt.Println("Could not find recipe steps!")
		panic(err)
	}

	// Otteniamo un puntatore all'elenco di ingredienti della ricetta
	recipeIngredients, err := dbmanager.ShowRecipeIngredients(recipe.RecipeID, db)
	if err != nil {
		fmt.Println("Could not find recipe ingredients!")
		panic(err)
	}

	// Inviamo al client, tutti i passi della ricetta
	showSteps(recipeSteps, conn)

	// Inviamo al client, tutti gli ingredienti della ricetta
	showIngredients(recipeIngredients, conn)

	// Inviamo avgKcal e recipeID
	buffer := make([]byte, BUF_SIZE)
	msg := strconv.Itoa(recipe.AvgKcal) + "," + strconv.Itoa(recipe.RecipeID)
	_, err = conn.Write([]byte(msg))
	if err != nil {
		fmt.Println("Error while retrieving ingredient list!")
		panic(err)
	}
	messageLen, err := conn.Read(buffer)
	if err != nil {
		fmt.Println("Error while waiting for ack!")
	}
	response := string(buffer[:messageLen])
	fmt.Println("Response received: ", response)
}

func addRecipeSteps(message []string, db *sql.DB) string {
	// Otteniamo la descrizione dell'ingrediente
	// message[0] = recipeID
	// message[1] = stepID
	// message[2] = stepDesc
	response, err := dbmanager.AddRecipeSteps(message, db)
	if response == "addRecipeStepsError" {
		return response
	} else if err != nil {
		fmt.Println("Could not link a step to its recipe! :C")
		panic(err)
	}
	return response
}

func showSteps(ingredientP *[]dbmanager.RecipeStep, conn net.Conn) {
	buffer := make([]byte, BUF_SIZE)
	for i, value := range *ingredientP {
		msg := strconv.Itoa(i) + "," + value.StepDesc
		_, err := conn.Write([]byte(msg))
		if err != nil {
			fmt.Println("Error while retrieving ingredient list!")
			panic(err)
		}
		messageLen, err := conn.Read(buffer)
		if err != nil {
			fmt.Println("Error while waiting for ack!")
		}
		response := string(buffer[:messageLen])
		fmt.Println("Response received: ", response)
	}
	msg := "endOfArray"
	_, err := conn.Write([]byte(msg))
	if err != nil {
		fmt.Println("Error while sending 'endOfArray'!")
		panic(err)
	}
}

func showIngredients(ingredientP *[]dbmanager.Ingredient, conn net.Conn) {
	buffer := make([]byte, BUF_SIZE)
	for _, value := range *ingredientP {
		ingQuantity := strconv.FormatFloat(float64(value.Quantity), 'f', 1, 32)
		msg := value.IngredientDesc.IngredientName + "," + ingQuantity
		_, err := conn.Write([]byte(msg))
		if err != nil {
			fmt.Println("Error while retrieving ingredient list!")
			panic(err)
		}
		messageLen, err := conn.Read(buffer)
		if err != nil {
			fmt.Println("Error while waiting for ack!")
		}
		response := string(buffer[:messageLen])
		fmt.Println("Response received: ", response)
	}
	msg := "endOfArray"
	_, err := conn.Write([]byte(msg))
	if err != nil {
		fmt.Println("Error while sending 'endOfArray'!")
		panic(err)
	}
}

func addRecipeIngredients(message []string, db *sql.DB) string {
	// Otteniamo la descrizione dell'ingrediente
	// message[0] = recipeID
	// message[1] = ingredientName
	// message[2] = ingQuantity
	ingredientDescription, err := dbmanager.ShowIngredient(message[1], db)
	if err != nil {
		fmt.Println("Ingredient description not found!")
		panic(err)
	}

	// Message conterrà recipeID, ingredientID, ingQuantity della ricetta
	message[1] = strconv.Itoa(int(ingredientDescription.Id))

	response, err := dbmanager.AddRecipeIngredients(message, db)
	if response == "addRecipeIngredientError" {
		return response
	} else if response == "duplicateIngredient" {
		return response
	} else if err != nil {
		fmt.Println("Could not link ingredients to their recipes! :C")
		panic(err)
	}
	return response
}

func addNewRecipe(message []string, db *sql.DB) string {
	recipe, response := dbmanager.VerifyRecipe(message[0], db)
	if response == "recipeExistent" {
		return response
	}
	recipeName := message[0]

	avgKcal, err := strconv.Atoi(message[1])
	if err != nil {
		fmt.Println("Cannot convert kcal from string to int.")
		panic(err)
	}

	breakfast, err := strconv.ParseBool(message[2])
	if err != nil {
		fmt.Println("Cannot convert breakfast from string to bool")
	}

	lunch, err := strconv.ParseBool(message[3])
	if err != nil {
		fmt.Println("Cannot convert lunch from string to bool")
	}

	dinner, err := strconv.ParseBool(message[4])
	if err != nil {
		fmt.Println("Cannot convert dinner from string to bool")
	}

	userID, err := strconv.Atoi(message[5])
	if err != nil {
		fmt.Println("Cannot convert kcal from string to int.")
		panic(err)
	}

	favourite, err := strconv.ParseBool(message[6])
	if err != nil {
		fmt.Println("Cannot convert favourite from string to bool")
	}

	recipe = dbmanager.Recipe{
		RecipeName: recipeName,
		AvgKcal:    avgKcal,
		Breakfast:  breakfast,
		Lunch:      lunch,
		Dinner:     dinner,
		UserID:     userID,
	}
	recipeID, err := dbmanager.AddNewRecipe(message, recipe, db)
	if err != nil {
		fmt.Println("Error while adding new ingredient into db!")
		panic(err)
	}
	if favourite {
		message[0] = message[5]                  //recipePreferences.userID = loggedUserID
		message[1] = strconv.Itoa(int(recipeID)) //recipePreferences.recipeID = recipeID
		dbmanager.AddFavouriteRecipe(message, db)
	}
	response = "recipeAdded," + strconv.Itoa(int(recipeID))
	return response
}

func showRecipes(recipeP *[]dbmanager.Recipe, conn net.Conn) {
	buffer := make([]byte, BUF_SIZE)
	for _, value := range *recipeP {
		msg := value.RecipeName
		_, err := conn.Write([]byte(msg))
		if err != nil {
			fmt.Println("Error while retrieving recipe list!")
			panic(err)
		}
		messageLen, err := conn.Read(buffer)
		if err != nil {
			fmt.Println("Error while waiting for ack!")
		}
		response := string(buffer[:messageLen])
		fmt.Println("Response received: ", response)
	}
	msg := "endOfArray"
	_, err := conn.Write([]byte(msg))
	if err != nil {
		fmt.Println("Error while sending 'endOfArray'!")
		panic(err)
	}
}

func showAllRecipes(db *sql.DB) *[]dbmanager.Recipe {
	recipesNames, err := dbmanager.ShowAllRecipes(db)
	if err != nil {
		fmt.Println("Error while retrieving ingredients!")
		panic(err)
	}
	return recipesNames
}

func addNewIngredient(message []string, db *sql.DB) string {
	ingredientDescription, response := dbmanager.VerifyIngredient(message[0], db)
	if response == "ingredientExistent" {
		return response
	}
	ingredientName := message[0]

	kcal, err := strconv.Atoi(message[1])
	if err != nil {
		fmt.Println("Cannot convert kcal from string to int.")
		panic(err)
	}

	carbs, err := strconv.ParseFloat(message[2], 32)
	if err != nil {
		fmt.Println("Cannot convert carbs from string to float32.")
		panic(err)
	}

	proteins, err := strconv.ParseFloat(message[3], 32)
	if err != nil {
		fmt.Println("Cannot convert proteins from string to float32.")
		panic(err)
	}

	fats, err := strconv.ParseFloat(message[4], 32)
	if err != nil {
		fmt.Println("Cannot convert fats from string to float32.")
		panic(err)
	}

	userID, err := strconv.Atoi(message[5])
	if err != nil {
		fmt.Println("Cannot convert kcal from string to int.")
		panic(err)
	}

	favourite, err := strconv.ParseBool(message[6])
	if err != nil {
		fmt.Println("Cannot convert favourite from string to bool.")
		panic(err)
	}

	ingredientDescription = dbmanager.IngredientDescription{
		IngredientName: ingredientName,
		Kcal:           kcal,
		Carbs:          float32(carbs),
		Proteins:       float32(proteins),
		Fats:           float32(fats),
		UserID:         userID,
	}
	ingredientID, err := dbmanager.AddNewIngredient(message, ingredientDescription, db)
	if err != nil {
		fmt.Println("Error while adding new ingredient into db!")
		panic(err)
	}
	if favourite {
		message[0] = message[5]
		message[1] = strconv.Itoa(int(ingredientID))
		dbmanager.AddFavouriteIngredient(message, db)
	}
	return "ingredientAdded"
}

func addFavouriteIngredient(message []string, db *sql.DB) string {
	response, err := dbmanager.AddFavouriteIngredient(message, db)
	if response == "favouriteIngredientError" {
		return response
	} else if err != nil {
		fmt.Println("Could not add ingredient to user's favourites! :C")
		panic(err)
	}
	return "favouriteIngredientAdded"
}

func removeFavouriteIngredient(message []string, db *sql.DB) string {
	response, err := dbmanager.RemoveFavouriteIngredient(message, db)
	if response == "removeFavouriteIngredientError" {
		return response
	} else if err != nil {
		fmt.Println("Could not remove ingredient to user's favourites! :C")
		panic(err)
	}
	return "favouriteIngredientRemoved"
}

func isFavouriteIngredient(message []string, db *sql.DB) string {
	response, err := dbmanager.IsFavouriteIngredient(message, db)
	if response {
		return "favouriteIngredientFound"
	} else {
		if err != nil {
			fmt.Println("Could not detect if the ingredient is a favourite one!")
			panic(err)
		}
		return "favouriteIngredientNotFound"
	}
}

func showIngredient(message string, db *sql.DB) string {
	ingredientDescription, err := dbmanager.ShowIngredient(message, db)
	if err != nil {
		fmt.Println("Ingredient description not found!")
		return "ingredientNotFound"
	}
	// Costruiamo la stringa da inviare in risposta al client
	// Conterrà ingredientID, ingredientName, kcal, carbs, proteins, fats, userID dell'ingrediente selezionato
	msg := strconv.Itoa(ingredientDescription.Id) + "," + ingredientDescription.IngredientName + "," + strconv.Itoa(ingredientDescription.Kcal) + "," + strconv.FormatFloat(float64(ingredientDescription.Carbs), 'f', 1, 32) + "," + strconv.FormatFloat(float64(ingredientDescription.Proteins), 'f', 1, 32) + "," + strconv.FormatFloat(float64(ingredientDescription.Fats), 'f', 1, 32) + "," + strconv.Itoa(ingredientDescription.UserID)
	return msg
}

func showIngredientsDescription(ingredientP *[]dbmanager.IngredientDescription, conn net.Conn) {
	buffer := make([]byte, BUF_SIZE)
	for _, value := range *ingredientP {
		msg := value.IngredientName
		_, err := conn.Write([]byte(msg))
		if err != nil {
			fmt.Println("Error while retrieving ingredient list!")
			panic(err)
		}
		messageLen, err := conn.Read(buffer)
		if err != nil {
			fmt.Println("Error while waiting for ack!")
		}
		response := string(buffer[:messageLen])
		fmt.Println("Response received: ", response)
	}
	msg := "endOfArray"
	_, err := conn.Write([]byte(msg))
	if err != nil {
		fmt.Println("Error while sending 'endOfArray'!")
		panic(err)
	}
}

func signUp(message []string) dbmanager.User {
	// Creiamo l'utente, senza specificare BMR e caloricIntake
	email := message[0]

	pass := message[1]

	age, err := strconv.Atoi(message[2])
	if err != nil {
		fmt.Println("Cannot convert age from string to int.")
		panic(err)
	}

	sex := message[3]

	height, err := strconv.ParseFloat(message[4], 32)
	if err != nil {
		fmt.Println("Cannot convert height from string to float32.")
		panic(err)
	}

	weight, err := strconv.ParseFloat(message[5], 32)
	if err != nil {
		fmt.Println("Cannot convert weight from string to float32.")
		panic(err)
	}

	intensity, err := strconv.ParseFloat(message[6], 32)
	if err != nil {
		fmt.Println("Cannot convert intensity from string to float32.")
		panic(err)
	}

	newUser := dbmanager.User{
		Id:            0,
		Email:         email,
		Pass:          pass,
		Age:           age,
		Sex:           sex,
		Height:        float32(height),
		Weight:        float32(weight),
		Intensity:     float32(intensity),
		Bmr:           0,
		CaloricIntake: 0,
	}

	// Chiediamo al server python di calcolare BMR
	msg := "calculateBMR," + strconv.Itoa(age) + "," + sex + "," + strconv.FormatFloat(height, 'f', 1, 32) + "," + strconv.FormatFloat(weight, 'f', 1, 32)
	bmr := client.SendMessage(msg)

	// Chiediamo al server python di calcolare TID
	msg = "calculateTID," + bmr
	tid := client.SendMessage(msg)

	// Chiediamo al server python di calcolare caloricIntake
	msg = "calculateIntake," + bmr + "," + strconv.FormatFloat(intensity, 'f', 1, 32) + "," + tid
	caloricIntake := client.SendMessage(msg)

	// Riempiamo i campi del nuovo utente che erano rimasti vuoti
	newUser.Bmr, err = strconv.Atoi(bmr)
	if err != nil {
		fmt.Println("Could not convert bmr from string to int!")
		panic(err)
	}

	newUser.CaloricIntake, err = strconv.Atoi(caloricIntake)
	if err != nil {
		fmt.Println("Could not convert caloricIntake from string to int!")
	}

	// Diciamo al server python di calcolare i parametri statistici che saranno lì visualizzati
	msg = "calculateAvgAge," + strconv.Itoa(newUser.Age)
	_ = client.SendMessage(msg)
	msg = "calculateSexPercentage," + string(newUser.Sex)
	_ = client.SendMessage(msg)
	return newUser
}

func selectUser(message []string, db *sql.DB) string {
	user, err := dbmanager.SelectUser(message, db)
	if err != nil {
		fmt.Println("User not found!")
		return "userNotFound"
	}
	// Costruiamo la stringa da inviare in risposta al client
	// Conterrà id, age, sex, height, weight, caloricIntake dell'utente che sta accedendo alla sua dashboard
	msg := strconv.Itoa(user.Id) + "," + strconv.Itoa(user.Age) + "," + user.Sex + "," + strconv.FormatFloat(float64(user.Height), 'f', 1, 32) + "," + strconv.FormatFloat(float64(user.Weight), 'f', 1, 32) + "," + strconv.Itoa(user.CaloricIntake)
	return msg
}

func showAllIngredientsDescription(db *sql.DB) *[]dbmanager.IngredientDescription {
	ingredientsNames, err := dbmanager.ShowAllIngredientsDescription(db)
	if err != nil {
		fmt.Println("Error while retrieving ingredients!")
		panic(err)
	}
	return ingredientsNames
}
