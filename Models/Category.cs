using Newtonsoft.Json;

namespace drink_info.model
{
    public class Category
    {
        public string strCategory { get; set; }
    }
    public class Categories
    {
        [JsonProperty("drinks")]
        public List<Category> CategoryList { get; set; }
    }
}