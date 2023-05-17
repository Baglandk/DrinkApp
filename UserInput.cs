namespace drink_info
{
    public class UserInput
    {
        DrinkService drinkService = new();
        internal void GetCategoriesInput()
        {
            drinkService.GetCategory();
            System.Console.WriteLine("Choose Categry: ");
            string category = System.Console.ReadLine();

            while(!Validator.IsInpuValid(category))
            {
                System.Console.WriteLine("Please enter a valid input");
                category = System.Console.ReadLine();
            }
            GetDrinksInput(category);
        }

        private void GetDrinksInput(string? category)
        {
            drinkService.GetDrinkCategory(category);
            System.Console.WriteLine("Choose a drink: ");
            string drink = System.Console.ReadLine();

            if(drink=="0") GetCategoriesInput();

            while(!Validator.IsIdValid(drink))
            {
                System.Console.WriteLine("Please enter a valid input");
                drink = System.Console.ReadLine();
            }
            drinkService.GetDrink(drink);
        }
    }
}