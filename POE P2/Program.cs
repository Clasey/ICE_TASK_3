using System;
using System.Collections.Generic;
using System.Linq;

namespace RecipeApp
{
    // Main class that contains the entry point of the application
    class Program
    {
        static void Main(string[] args)
        {
            // Create a list to store recipes
            List<Recipe> recipes = new List<Recipe>();

            while (true)
            {
                Console.WriteLine("\nOptions:");
                Console.WriteLine("1. Add Recipe");
                Console.WriteLine("2. View Recipes");
                Console.WriteLine("3. Scale Recipe");
                Console.WriteLine("4. Reset Recipe");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");
                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input! Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        // Create a new recipe and add it to the list
                        Recipe newRecipe = new Recipe();
                        newRecipe.GetRecipeDetails();
                        recipes.Add(newRecipe);
                        break;
                    case 2:
                        // View all recipes and allow the user to select one
                        if (recipes.Count == 0)
                        {
                            Console.WriteLine("No recipes available.");
                        }
                        else
                        {
                            DisplayRecipes(recipes);
                            Console.Write("Enter the number of the recipe to view details: ");
                            if (!int.TryParse(Console.ReadLine(), out int recipeIndex))
                            {
                                Console.WriteLine("Invalid input! Please enter a number.");
                                continue;
                            }
                            recipeIndex--;
                            if (recipeIndex >= 0 && recipeIndex < recipes.Count)
                            {
                                recipes[recipeIndex].DisplayRecipe();
                                recipes[recipeIndex].DisplayTotalCalories();
                            }
                            else
                            {
                                Console.WriteLine("Invalid recipe number.");
                            }
                        }
                        break;
                    case 3:
                        // Scale the recipe
                        ScaleRecipe(recipes);
                        break;
                    case 4:
                        // Reset the scaled recipe to original
                        ResetRecipe(recipes);
                        break;
                    case 5:
                        // Exit the program
                        Environment.Exit(0);
                        break;
                    default:
                        // Handle invalid input
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
        }

        // Method to display all recipes sorted alphabetically by name
        static void DisplayRecipes(List<Recipe> recipes)
        {
            Console.WriteLine("\nRecipes:");
            // Sort recipes by name
            recipes.Sort((x, y) => string.Compare(x.Name, y.Name));
            // Display each recipe with its index
            for (int i = 0; i < recipes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {recipes[i].Name}");
            }
        }

        // Method to scale the recipe
        static void ScaleRecipe(List<Recipe> recipes)
        {
            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipes available.");
                return;
            }

            DisplayRecipes(recipes);
            Console.Write("Enter the number of the recipe to scale: ");
            if (!int.TryParse(Console.ReadLine(), out int recipeIndex))
            {
                Console.WriteLine("Invalid input! Please enter a number.");
                return;
            }
            recipeIndex--;
            if (recipeIndex >= 0 && recipeIndex < recipes.Count)
            {
                recipes[recipeIndex].ScaleRecipe();
                Console.WriteLine("Recipe scaled successfully.");
            }
            else
            {
                Console.WriteLine("Invalid recipe number.");
            }
        }

        // Method to reset the scaled recipe to original
        static void ResetRecipe(List<Recipe> recipes)
        {
            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipes available.");
                return;
            }

            DisplayRecipes(recipes);
            Console.Write("Enter the number of the recipe to reset: ");
            if (!int.TryParse(Console.ReadLine(), out int recipeIndex))
            {
                Console.WriteLine("Invalid input! Please enter a number.");
                return;
            }
            recipeIndex--;
            if (recipeIndex >= 0 && recipeIndex < recipes.Count)
            {
                recipes[recipeIndex].ResetRecipe();
                Console.WriteLine("Recipe reset to original successfully.");
            }
            else
            {
                Console.WriteLine("Invalid recipe number.");
            }
        }
    }

    // Class representing a recipe
    class Recipe
    {
        // Properties
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Step> Steps { get; set; }
        private List<Ingredient> originalIngredients;

        // Delegate for calorie notification
        public delegate void CalorieNotificationHandler(Recipe recipe);

        // Event for calorie notification
        public event CalorieNotificationHandler CalorieNotification;

        // Method to get recipe details from the user
        public void GetRecipeDetails()
        {
            Console.WriteLine("Enter Recipe Name: ");
            Name = Console.ReadLine();

            Ingredients = new List<Ingredient>();
            Steps = new List<Step>();

            Console.Write("Enter the number of ingredients: ");
            int numIngredients;
            while (!int.TryParse(Console.ReadLine(), out numIngredients) || numIngredients <= 0)
            {
                Console.WriteLine("Invalid input! Enter number of ingredients.");
                Console.Write("Enter the number of ingredients: ");
            }

            // Loop to get details of each ingredient
            for (int i = 0; i < numIngredients; i++)
            {
                Console.Write($"Enter ingredient {i + 1} name: ");
                string name = Console.ReadLine();

                Console.Write($"Enter quantity for {name}: ");
                double quantity = double.Parse(Console.ReadLine());

                Console.Write($"Enter unit for {name}: ");
                string unit = Console.ReadLine();

                Console.Write($"Enter calories for {name}: ");
                double calories = double.Parse(Console.ReadLine());

                Console.Write($"Enter food group for {name}: ");
                string foodGroup = Console.ReadLine();

                // Create a new ingredient object and store it in the list
                Ingredients.Add(new Ingredient(name, quantity, unit, calories, foodGroup));
            }

            Console.Write("Enter the number of steps: ");
            int numSteps = int.Parse(Console.ReadLine());

            // Loop to get details of each step
            for (int i = 0; i < numSteps; i++)
            {
                Console.Write($"Enter step {i + 1}: ");
                string description = Console.ReadLine();
                // Create a new step object and store it in the list
                Steps.Add(new Step(description));
            }

            // Save original ingredients for scaling purposes
            originalIngredients = new List<Ingredient>(Ingredients);
        }

        // Method to display the recipe to the user
        public void DisplayRecipe()
        {
            Console.WriteLine($"\nRecipe: {Name}");
            Console.WriteLine("Ingredients:");
            // Iterate through each ingredient and display its details
            foreach (Ingredient ingredient in Ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name} ({ingredient.Calories} calories, {ingredient.FoodGroup})");
            }
            Console.WriteLine("\nSteps:");
            // Iterate through each step and display its description
            for (int i = 0; i < Steps.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Steps[i].Description}");
            }
        }

        // Method to calculate and display the total calories of all ingredients
        public void DisplayTotalCalories()
        {
            if (Ingredients == null)
            {
                Console.WriteLine("Recipe has no ingredients.");
                return;
            }
            double totalCalories = Ingredients.Sum(ingredient => ingredient.Calories);
            Console.WriteLine($"Total Calories: {totalCalories}");

            // Notify if total calories exceed 300
            if (totalCalories > 300)
            {
                CalorieNotification?.Invoke(this);
            }
        }

        // Method to scale the recipe
        public void ScaleRecipe()
        {
            if (originalIngredients == null)
            {
                Console.WriteLine("Recipe has no ingredients.");
                return;
            }
            Console.Write("Enter scale factor: ");
            if (!double.TryParse(Console.ReadLine(), out double scaleFactor) || scaleFactor <= 0)
            {
                Console.WriteLine("Invalid input! Scale factor must be a positive number.");
                return;
            }

            Ingredients = originalIngredients.Select(ingredient =>
            {
                return new Ingredient(ingredient.Name, ingredient.Quantity * scaleFactor, ingredient.Unit, ingredient.Calories * scaleFactor, ingredient.FoodGroup);
            }).ToList();
        }

        // Method to reset the scaled recipe to original
        public void ResetRecipe()
        {
            if (originalIngredients == null)
            {
                Console.WriteLine("Recipe has no ingredients.");
                return;
            }
            Ingredients = new List<Ingredient>(originalIngredients);
        }
    }

    // Class representing an ingredient
    class Ingredient
    {
        // Properties
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public double Calories { get; set; }
        public string FoodGroup { get; set; }

        // Constructor
        public Ingredient(string name, double quantity, string unit, double calories, string foodGroup)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
            Calories = calories;
            FoodGroup = foodGroup;
        }
    }

    // Class representing a step in the recipe
    class Step
    {
        // Property
        public string Description { get; set; }

        // Constructor
        public Step(string description)
        {
            Description = description;
        }
    }
}