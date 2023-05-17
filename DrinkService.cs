using System.Reflection;
using drink_info.model;
using Newtonsoft.Json;
using RestSharp;

namespace drink_info
{
    public class DrinkService
    {
        internal void GetCategory()
        {
            var client = new RestClient("https://www.thecocktaildb.com/api/json/v1/1/");
            var request = new RestRequest("list.php?c=list");
            var responce = client.ExecuteAsync(request);

            if(responce.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponce = responce.Result.Content;
                var serilize = JsonConvert.DeserializeObject<Categories>(rawResponce);
                List<Category> returnedList = serilize.CategoryList;
                TableVisualizationEngine.ShowTable(returnedList, "Category Name");
            }
        }

        internal void GetDrink(string? drink)
        {
            var client = new RestClient("https://www.thecocktaildb.com/api/json/v1/1/");
            var request = new RestRequest($"lookup.php?i={drink}");
            var responce = client.ExecuteAsync(request);

            if(responce.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponce = responce.Result.Content;
                var serilize = JsonConvert.DeserializeObject<DrinkDetailObject>(rawResponce);
                List<DrinkDetail> returnedList = serilize.DrinkList;
                DrinkDetail drinkDetail = returnedList[0];
                List<object> prepList = new();

                string formattedName = "";
                foreach (PropertyInfo prop in drinkDetail.GetType().GetProperties())
                {

                    if (prop.Name.Contains("str"))
                    {
                        formattedName = prop.Name.Substring(3);
                    }

                    if (!string.IsNullOrEmpty(prop.GetValue(drinkDetail)?.ToString()))
                    {
                        prepList.Add(new
                        {
                            Key = formattedName,
                            Value = prop.GetValue(drinkDetail)
                        });
                    }
                }
                TableVisualizationEngine.ShowTable(returnedList,"Drink Name");
            }
        }

        internal void GetDrinkCategory(string? category)
        {
            var client = new RestClient("https://www.thecocktaildb.com/api/json/v1/1/");
            var request = new RestRequest("filter.php?c=Ordinary_Drink");
            var responce = client.ExecuteAsync(request);

            if(responce.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponce = responce.Result.Content;
                var serilize = JsonConvert.DeserializeObject<Drinks>(rawResponce);
                List<Drink> returnedList = serilize.DrinkList;
                TableVisualizationEngine.ShowTable(returnedList,"Drink Name");
            }
        }
    }
}