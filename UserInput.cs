namespace drink_info
{
    public class UserInput
    {
        static string CategoryPath = "Category.txt";
        static string DrinkPath = "Drink.txt";
        DrinkService drinkService = new();
        FileReader f = new FileReader();
        internal void GetCategoriesInput()
        {
            drinkService.GetCategory();
            System.Console.WriteLine("Choose Categry: ");
            f.Popular(CategoryPath);
            string category = System.Console.ReadLine();

            while(!Validator.IsInpuValid(category))
            {
                System.Console.WriteLine("Please enter a valid input");
                category = System.Console.ReadLine();
            }
            f.Write(category,CategoryPath);
            GetDrinksInput(category);
        }

        private void GetDrinksInput(string? category)
        {
            drinkService.GetDrinkCategory(category);

            System.Console.WriteLine("Choose a drink: ");
            f.Popular(DrinkPath);
            string drink = System.Console.ReadLine();

            if(drink=="0") GetCategoriesInput();

            while(!Validator.IsIdValid(drink))
            {
                System.Console.WriteLine("Please enter a valid input");
                drink = System.Console.ReadLine();
            }
            f.Write(drink, DrinkPath);
            drinkService.GetDrink(drink);
        }
    }
}