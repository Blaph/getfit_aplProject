import numpy as np
import messageHandler

class Calc(object):
    def __init__(self):
        self.recipe = messageHandler.recipe()
        print("Calculator created.\n")
        
    def calculateAvgAge(self, totalUsers, totalAge, newUserAge):
        return (int(totalAge) + int(newUserAge))/int(totalUsers)
    
    def calculateSexPercentage(self, totalUsers, totalMale, newUserSex):
        malePercentage = (int(totalMale)/int(totalUsers)) * 100
        femalePercentage = 100 - malePercentage
        return malePercentage, femalePercentage
    
    def calculateBMR(self, age, sex, height, weight):
        # Mifflin-St.Jeor's formula
        if sex == 'M':
            return int(10*float(weight) + 6.25*float(height) - 5*int(age) + 5)
        else:
            return int(10*float(weight) + 6.25*float(height) - 5*int(age) - 161)
        
    def calculateTID(self, bmr):
        return int(bmr)*0.10
    
    def calculateIntake(self, bmr, intensity, tid):
        return int(int(bmr)*float(intensity)+float(tid))
    
    def randomizeDish(self, recipes, caloricIntake):
        caloricIntk = int(caloricIntake)
        moreCaloricIntk = caloricIntk - (caloricIntk*0.9)
        lessCaloricIntk = caloricIntk + (caloricIntk*0.9)
        dishes = np.array([
            int(recipe.recipeID) for recipe in recipes 
            if int(recipe.kcal) > moreCaloricIntk
            and int(recipe.kcal) < lessCaloricIntk], 
            dtype="uint8");
        np.random.shuffle(dishes)
        dish = str(dishes[0])
        return dish