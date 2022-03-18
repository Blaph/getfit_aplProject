use `getfit-localdb`;

CREATE TABLE IF NOT EXISTS users (
	id INT AUTO_INCREMENT PRIMARY KEY,
    email CHAR(50) NOT NULL,
    pass CHAR(50) NOT NULL,
    age INT NOT NULL,
    sex CHAR(1) NOT NULL,
    height FLOAT4 NOT NULL,
    weight FLOAT4 NOT NULL,
    intensity FLOAT4,
    bmr INT NOT NULL,
    caloricIntake INT NOT NULL
);

CREATE TABLE IF NOT EXISTS ingredients (
	ingredientID INT AUTO_INCREMENT PRIMARY KEY,
    ingredientName CHAR(50) NOT NULL,
    kcal INT NOT NULL,
    carbs FLOAT4,
    proteins FLOAT4,
    fats FLOAT4,
    userID INT
);

CREATE TABLE IF NOT EXISTS ingredientPreferences (
	userID INT NOT NULL,
    ingredientID INT NOT NULL,
    UNIQUE (userID, ingredientID)
);

CREATE TABLE IF NOT EXISTS recipes (
	recipeID INT AUTO_INCREMENT PRIMARY KEY,
    recipeName CHAR(50) NOT NULL,
    avgKcal INT NOT NULL,
    breakfast BOOL,
    lunch BOOL,
    dinner BOOL,
    userID int
);

CREATE TABLE IF NOT EXISTS recipeIngredients (
	recipeID INT NOT NULL,
    ingredientID INT NOT NULL,
    ingQuantity FLOAT4 NOT NULL,
    UNIQUE (recipeID, ingredientID)
);

CREATE TABLE IF NOT EXISTS recipeSteps (
	recipeID INT NOT NULL,
    stepID INT NOT NULL,
    stepDesc CHAR(100) NOT NULL
);

CREATE TABLE IF NOT EXISTS recipePreferences (
	userID INT NOT NULL,
    recipeID INT NOT NULL,
    UNIQUE (userID, recipeID)
);

INSERT INTO users (id, email, pass, age, sex, height, weight, intensity, bmr, caloricIntake) VALUES ('1', 'admin@getfit.com', 'admin', 27, 'M', 175, 85, 1.6, 1813, 3084);
INSERT INTO users (email, pass, age, sex, height, weight, intensity, bmr, caloricIntake) VALUES ('sandrosaltasozzi@hotmail.it', 1111, 30, 'M', 162, 90, 1.2, 1768, 2298);
INSERT INTO users (email, pass, age, sex, height, weight, intensity, bmr, caloricIntake) VALUES ('marcellasolfrizzi@hotmail.it', 'abc123', 43, 'F', 191, 85, 1.4, 1618, 2427);
INSERT INTO users (email, pass, age, sex, height, weight, intensity, bmr, caloricIntake) VALUES ('frabro@tiscali.it', 'daifranonfareilbro', 50, 'F', 201, 100, 1.8, 2011, 3820);
INSERT INTO users (email, pass, age, sex, height, weight, intensity, bmr, caloricIntake) VALUES ('aaaeee@outlook.com', 'aaee00', 21, 'F', 167, 71, 1.6, 1768, 2529);

INSERT INTO ingredients (ingredientID, ingredientName, kcal, carbs, proteins, fats, userID) VALUES ('1', 'Pistacchio', 605, 10.3, 26.5, 49.2, 1);
INSERT INTO ingredients (ingredientName, kcal, carbs, proteins, fats, userID) VALUES ('Elicoidali', 356, 69.5, 14.5, 1.6, 1);
INSERT INTO ingredients (ingredientName, kcal, carbs, proteins, fats, userID) VALUES ('Zucchero semolato', 400, 100, 0, 0, 2);
INSERT INTO ingredients (ingredientName, kcal, carbs, proteins, fats, userID) VALUES ('Nutella', 539, 57.5, 6.3, 30.9, 2);
INSERT INTO ingredients (ingredientName, kcal, carbs, proteins, fats, userID) VALUES ('Pane bianco', 282, 50, 8.5, 4.6, 3);
INSERT INTO ingredients (ingredientName, kcal, carbs, proteins, fats, userID) VALUES ('Latte parzialmente scremato', 47, 4.8, 3.3, 1.6, 2);
INSERT INTO ingredients (ingredientName, kcal, carbs, proteins, fats, userID) VALUES ('Yogurt bianco intero', 63, 3.8, 3.6, 3.7, 2);
INSERT INTO ingredients (ingredientName, kcal, carbs, proteins, fats, userID) VALUES ('Uova', 128, 0.1, 12.4, 8.7, 3);
INSERT INTO ingredients (ingredientName, kcal, carbs, proteins, fats, userID) VALUES ('Olio di oliva', 820, 0, 0, 92, 4);
INSERT INTO ingredients (ingredientName, kcal, carbs, proteins, fats, userID) VALUES ('Miele', 304, 82, 0.3, 0, 1);
INSERT INTO ingredients (ingredientName, kcal, carbs, proteins, fats, userID) VALUES ('Farina 00', 354, 73, 10, 2, 2);
INSERT INTO ingredients (ingredientName, kcal, carbs, proteins, fats, userID) VALUES ('Riso parboiled', 350, 77, 7, 1.1, 3);
INSERT INTO ingredients (ingredientName, kcal, carbs, proteins, fats, userID) VALUES ('Olio di semi di girasole', 900, 0, 0, 100, 5);
INSERT INTO ingredients (ingredientName, kcal, carbs, proteins, fats, userID) VALUES ('Frollini con gocce di cioccolato', 477, 66, 6.7, 20, 5);
INSERT INTO ingredients (ingredientName, kcal, carbs, proteins, fats, userID) VALUES ('Salsa di datterino', 37, 5.5, 1.0, 0.7, 4);
INSERT INTO ingredients (ingredientName, kcal, carbs, proteins, fats, userID) VALUES ('Sale', 0, 0, 0, 0, 4);
INSERT INTO ingredients (ingredientName, kcal, carbs, proteins, fats, userID) VALUES ('Lievito', 0, 0, 0, 0, 5);
INSERT INTO ingredients (ingredientName, kcal, carbs, proteins, fats, userID) VALUES ('Acqua', 0, 0, 0, 0, 5);

INSERT INTO ingredientPreferences (userID, ingredientID) VALUES (1, 1);
INSERT INTO ingredientPreferences (userID, ingredientID) VALUES (1, 2);
INSERT INTO ingredientPreferences (userID, ingredientID) VALUES (1, 3);
INSERT INTO ingredientPreferences (userID, ingredientID) VALUES (1, 4);
INSERT INTO ingredientPreferences (userID, ingredientID) VALUES (1, 5);
INSERT INTO ingredientPreferences (userID, ingredientID) VALUES (1, 6);
INSERT INTO ingredientPreferences (userID, ingredientID) VALUES (1, 7);
INSERT INTO ingredientPreferences (userID, ingredientID) VALUES (1, 8);
INSERT INTO ingredientPreferences (userID, ingredientID) VALUES (1, 9);
INSERT INTO ingredientPreferences (userID, ingredientID) VALUES (1, 10);
INSERT INTO ingredientPreferences (userID, ingredientID) VALUES (1, 11);
INSERT INTO ingredientPreferences (userID, ingredientID) VALUES (1, 12);
INSERT INTO ingredientPreferences (userID, ingredientID) VALUES (1, 13);
INSERT INTO ingredientPreferences (userID, ingredientID) VALUES (1, 14);
INSERT INTO ingredientPreferences (userID, ingredientID) VALUES (1, 15);
INSERT INTO ingredientPreferences (userID, ingredientID) VALUES (2, 2);
INSERT INTO ingredientPreferences (userID, ingredientID) VALUES (2, 15);
INSERT INTO ingredientPreferences (userID, ingredientID) VALUES (2, 4);
INSERT INTO ingredientPreferences (userID, ingredientID) VALUES (2, 5);
INSERT INTO ingredientPreferences (userID, ingredientID) VALUES (3, 6);
INSERT INTO ingredientPreferences (userID, ingredientID) VALUES (3, 14);
INSERT INTO ingredientPreferences (userID, ingredientID) VALUES (4, 8);
INSERT INTO ingredientPreferences (userID, ingredientID) VALUES (4, 11);
INSERT INTO ingredientPreferences (userID, ingredientID) VALUES (4, 7);
INSERT INTO ingredientPreferences (userID, ingredientID) VALUES (4, 10);
INSERT INTO ingredientPreferences (userID, ingredientID) VALUES (4, 18);
INSERT INTO ingredientPreferences (userID, ingredientID) VALUES (4, 13);
INSERT INTO ingredientPreferences (userID, ingredientID) VALUES (4, 16);
INSERT INTO ingredientPreferences (userID, ingredientID) VALUES (4, 17);

INSERT INTO recipes (recipeID, recipeName, avgKcal, breakfast, lunch, dinner, userID) VALUES ('1', 'Pancakes yogurt e miele', 516, true, false, false, 1);
INSERT INTO recipes (recipeName, avgKcal, breakfast, lunch, dinner, userID) VALUES ('Pane e Nutella', 312, true, false, false, 2);
INSERT INTO recipes (recipeName, avgKcal, breakfast, lunch, dinner, userID) VALUES ('Pasta con la salsa', 450, false, true, true, 3);
INSERT INTO recipes (recipeName, avgKcal, breakfast, lunch, dinner, userID) VALUES ('Uova sode', 350, true, true, true, 4);
INSERT INTO recipes (recipeName, avgKcal, breakfast, lunch, dinner, userID) VALUES ('Latte e cereali', 466, true, false, true, 1);

INSERT INTO recipeIngredients (recipeID, ingredientID, ingQuantity) VALUES (1, 8, 20);
INSERT INTO recipeIngredients (recipeID, ingredientID, ingQuantity) VALUES (1, 10, 30);
INSERT INTO recipeIngredients (recipeID, ingredientID, ingQuantity) VALUES (1, 7, 85);
INSERT INTO recipeIngredients (recipeID, ingredientID, ingQuantity) VALUES (1, 11, 160);
INSERT INTO recipeIngredients (recipeID, ingredientID, ingQuantity) VALUES (1, 18, 150);
INSERT INTO recipeIngredients (recipeID, ingredientID, ingQuantity) VALUES (1, 13, 30);
INSERT INTO recipeIngredients (recipeID, ingredientID, ingQuantity) VALUES (1, 16, 0.7);
INSERT INTO recipeIngredients (recipeID, ingredientID, ingQuantity) VALUES (1, 17, 0.5);
INSERT INTO recipeIngredients (recipeID, ingredientID, ingQuantity) VALUES (2, 4, 50);
INSERT INTO recipeIngredients (recipeID, ingredientID, ingQuantity) VALUES (2, 5, 30);
INSERT INTO recipeIngredients (recipeID, ingredientID, ingQuantity) VALUES (3, 2, 100);
INSERT INTO recipeIngredients (recipeID, ingredientID, ingQuantity) VALUES (3, 15, 25);
INSERT INTO recipeIngredients (recipeID, ingredientID, ingQuantity) VALUES (4, 8, 50);
INSERT INTO recipeIngredients (recipeID, ingredientID, ingQuantity) VALUES (5, 6, 120);
INSERT INTO recipeIngredients (recipeID, ingredientID, ingQuantity) VALUES (5, 14, 25);

INSERT INTO recipeSteps (recipeID, stepID, stepDesc) VALUES (1, 1, "Separare i tuorli dagli albumi");
INSERT INTO recipeSteps (recipeID, stepID, stepDesc) VALUES (1, 2, "Montare gli albumi a neve");
INSERT INTO recipeSteps (recipeID, stepID, stepDesc) VALUES (1, 4, "Aggiungere l'olio di semi e lo yogurt");
INSERT INTO recipeSteps (recipeID, stepID, stepDesc) VALUES (1, 3, "Montare i tuorli con il miele");
INSERT INTO recipeSteps (recipeID, stepID, stepDesc) VALUES (1, 5, "Aggiungere la farina");
INSERT INTO recipeSteps (recipeID, stepID, stepDesc) VALUES (1, 6, "Incorporare gli albumi nell'impasto");
INSERT INTO recipeSteps (recipeID, stepID, stepDesc) VALUES (1, 7, "Far riposare l'impasto circa 30 minuti in frigo");
INSERT INTO recipeSteps (recipeID, stepID, stepDesc) VALUES (1, 8, "Togliere l'impasto dal frigo e aggiungere il lievito");
INSERT INTO recipeSteps (recipeID, stepID, stepDesc) VALUES (1, 9, "Oliare leggermente la padella");
INSERT INTO recipeSteps (recipeID, stepID, stepDesc) VALUES (1, 10, "Cuocere");
INSERT INTO recipeSteps (recipeID, stepID, stepDesc) VALUES (2, 1, "Prendere il pane");
INSERT INTO recipeSteps (recipeID, stepID, stepDesc) VALUES (2, 2, "Aprire il barattolo di Nutella");
INSERT INTO recipeSteps (recipeID, stepID, stepDesc) VALUES (2, 3, "Spalmare la nutella su una fetta");
INSERT INTO recipeSteps (recipeID, stepID, stepDesc) VALUES (2, 4, "Porre l'altra fetta di pane, su quella appena spalmata con la nutella");
INSERT INTO recipeSteps (recipeID, stepID, stepDesc) VALUES (3, 1, "Versare dell'acqua all'interno di una pentola e farla bollire");
INSERT INTO recipeSteps (recipeID, stepID, stepDesc) VALUES (3, 2, "Far cuocere la salsa in un pentolino");
INSERT INTO recipeSteps (recipeID, stepID, stepDesc) VALUES (3, 3, "Aggiungere lo zucchero alla salsa");
INSERT INTO recipeSteps (recipeID, stepID, stepDesc) VALUES (3, 4, "Aggiungere il sale all'acqua in ebollizione");
INSERT INTO recipeSteps (recipeID, stepID, stepDesc) VALUES (3, 5, "Aggiungere la pasta");
INSERT INTO recipeSteps (recipeID, stepID, stepDesc) VALUES (3, 6, "Una volta pronta, scolare la pasta");
INSERT INTO recipeSteps (recipeID, stepID, stepDesc) VALUES (3, 7, "Versare il sugo");
INSERT INTO recipeSteps (recipeID, stepID, stepDesc) VALUES (4, 1, "Versare dell'acqua in un pentolino");
INSERT INTO recipeSteps (recipeID, stepID, stepDesc) VALUES (4, 2, "Attendere che l'acqua faccia degli spilli");
INSERT INTO recipeSteps (recipeID, stepID, stepDesc) VALUES (4, 3, "Aggiungere le uova al pentolino");
INSERT INTO recipeSteps (recipeID, stepID, stepDesc) VALUES (4, 4, "Attendere circa 10 minuti");
INSERT INTO recipeSteps (recipeID, stepID, stepDesc) VALUES (4, 5, "Togliere le uova dal pentolino");
INSERT INTO recipeSteps (recipeID, stepID, stepDesc) VALUES (4, 6, "Sgusciare le uova");
INSERT INTO recipeSteps (recipeID, stepID, stepDesc) VALUES (4, 7, "Servire");
INSERT INTO recipeSteps (recipeID, stepID, stepDesc) VALUES (5, 1, "Riscaldare il latte al microonde");
INSERT INTO recipeSteps (recipeID, stepID, stepDesc) VALUES (5, 2, "Aggiungere i cereali");

INSERT INTO recipePreferences (userID, recipeID) VALUES (1, 1);
INSERT INTO recipePreferences (userID, recipeID) VALUES (1, 2);
INSERT INTO recipePreferences (userID, recipeID) VALUES (1, 3);
INSERT INTO recipePreferences (userID, recipeID) VALUES (1, 4);
INSERT INTO recipePreferences (userID, recipeID) VALUES (1, 5);
INSERT INTO recipePreferences (userID, recipeID) VALUES (2, 4);
INSERT INTO recipePreferences (userID, recipeID) VALUES (2, 3);
INSERT INTO recipePreferences (userID, recipeID) VALUES (3, 5);
INSERT INTO recipePreferences (userID, recipeID) VALUES (3, 1);
INSERT INTO recipePreferences (userID, recipeID) VALUES (3, 4);
INSERT INTO recipePreferences (userID, recipeID) VALUES (5, 2);