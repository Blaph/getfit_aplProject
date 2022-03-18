import copy
import Calculator

class recipe(object):
    def __init__(self):
       self.recipeID = 0
       self.kcal = 0

# Gestiamo il messaggio col comando, in arrivo
class messageHandl(object):
    def __init__(self):
       self._totalUsers = 0
       self._totalAge = 0
       self._totalMale = 0
       self._avgAge = 0
       self._pcgMalesUsers = 0
       self._pcgFemalesUsers = 0
       self.calculator = Calculator.Calc()
       self.recipe = recipe()
       self.commands = {    # Sono riferimenti alle funzioni e non le funzioni stesse
            'setTotalUsers': self.setTotalUsers,
            'setTotalAge': self.setTotalAge,
            'setTotalGenders': self.setTotalGenders,
            'calculateAvgAge': self.calculateAvgAge,
            'calculateSexPercentage': self.calculateSexPercentage,
            'calculateBMR': self.calculateBMR,
            'calculateTID': self.calculateTID,
            'calculateIntake': self.calculateIntake,
            'randomizeDish': self.randomizeDish
            }
       print("Message handler created.\n")
        
    def handleMessage(self, message):
        try:
            message = message.decode('utf-8')
            msg = message.split(",")
            command = self.commands[msg[0]]  # Otteniamo la funzione, tramite il suo riferimento nel dizionario
            response = command(msg[1:])
            response = response.encode('utf-8')
        except:
            print("Could not handle incoming message and its command.\n")
        return response
        
    def setTotalUsers(self, msg):
        self._totalUsers = msg[0]
        self._totalUsers = int(self._totalUsers) - 1 # Bilancio questa sottrazione andando subito a sommare un'unità in 'calculateAvgAge'
        print(f"Total users using the platform: {self._totalUsers+1}\n")
        return "setTotalUsers completed."
        
    def setTotalAge(self, msg):
        self._totalAge = msg[0]
        zeroValue = [0]
        self.calculateAvgAge(zeroValue)
        return "setTotalAge completed."
    
    def setTotalGenders(self, msg):
        self._totalMale = msg[0]
        zeroValue = ['F']
        self.calculateSexPercentage(zeroValue) # Inviare 'F' equivale a sommare 0
        return "setTotalGenders completed."
        
    def calculateAvgAge(self, msg):
        self._totalUsers = int(self._totalUsers) + 1
        self._totalAge = int(self._totalAge) + int(msg[0])
        self._avgAge = self.calculator.calculateAvgAge(self._totalUsers, self._totalAge, msg[0])
        print(f"Average Age Users updated.\nNew average users age: {self._avgAge}\n")
        return "calculateAvgAge completed."
        
    def calculateSexPercentage(self, msg):
        if msg[0] == 'M':
            self._totalMale = int(self._totalMale) + 1
        self._pcgMalesUsers, self._pcgFemalesUsers = self.calculator.calculateSexPercentage(self._totalUsers, self._totalMale, msg[0])
        print(f"Users Sex Percentages updated.\nNew percentages are: \nMale: {self._pcgMalesUsers}%\nFemale: {self._pcgFemalesUsers}%\n")
        return "calculateSexPercentage completed."
        
    def calculateBMR(self, msg):
        age = msg[0]
        sex = msg[1]
        height = msg[2]
        weight = msg[3]
        bmr = self.calculator.calculateBMR(age, sex, height, weight)
        return str(bmr)
    
    def calculateTID(self, msg):
        bmr = msg[0]
        tid = self.calculator.calculateTID(bmr)
        return str(tid)
    
    def calculateIntake(self, msg):
        bmr = msg[0]
        intensity = msg[1]
        tid = msg[2]
        caloricIntake = self.calculator.calculateIntake(bmr, intensity, tid)
        return str(caloricIntake)

    def randomizeDish(self, msg):
        recipes = []
        calculator = self.calculator
        rcp = recipe()
        caloricIntake = msg[0]
        recipeList = msg[1:]
        for recipeIdKcal in recipeList:
            r = copy.deepcopy(rcp)
            recipeDesc = recipeIdKcal.split("-")
            r.recipeID = recipeDesc[0]
            if recipeIdKcal != "endOfArray":
                r.kcal = recipeDesc[1]
                recipes.append(r)
        dish = calculator.randomizeDish(recipes, caloricIntake)
        return dish