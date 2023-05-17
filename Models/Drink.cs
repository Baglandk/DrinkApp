using Newtonsoft.Json;

namespace drink_info.model
{
    public class Drinks
    {
        [JsonProperty("drinks")]
        public List<Drink> DrinkList {get;set;} 
    }
    public class Drink
    {
        public int idDrink { get; set; }
        public string strDrink { get; set; }
    }
}