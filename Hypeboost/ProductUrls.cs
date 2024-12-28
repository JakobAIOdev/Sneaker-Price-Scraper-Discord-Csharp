using Newtonsoft.Json.Linq;
using System.ComponentModel;
class ProductUrls
{
    public string SKU { get; set; }
    
    public ProductUrls(string sku)
    {
        SKU = sku;
    }

    // StockX
    /*
    public string GetStockXUrl()
    {
    }
    */

    // Ebay
    public string GetEbayUrl(string ebayRegion)
    {
        string ebayUrl = $"https://www.ebay.{ebayRegion}/sch/i.html?_nkw={SKU}";
        return ebayUrl;
    }



    public string GetGoatUrl()
    {
        string requestUrl = $"https://ac.cnstrc.com/search/{SKU}?c=ciojs-client-2.29.12&key=key_XT7bjdbvjgECO5d8&i=5c1db6a2-7a42-4cbd-9606-96a08face508&s=23&num_results_per_page=1&_dt=1679422941544";
        HttpClient client = new HttpClient();
        var response = client.GetAsync(requestUrl).Result;
        response.EnsureSuccessStatusCode();
        string jsonString = response.Content.ReadAsStringAsync().Result;

        JObject json = JObject.Parse(jsonString);
                    
        string slug = json["response"]?["results"]?[0]?["data"]?["slug"]?.ToString() ?? string.Empty;
        if(slug != null)
        {
            string productUrl = "https://www.goat.com/sneakers/" + slug;
            return productUrl;
        }
        else
        {
            return "SKU not found";
        }
    }

    // Hypeboost Url via Hypeboost.cs

    
}

public static class EbayRegions
{
    public const string COM = "com";
    public const string DE = "de";
    public const string AT = "at";
    public const string IT = "it";
    public const string FR = "fr";
    public const string CO_UK = "co.uk";
    public const string NL = "nl";
    public const string BE = "be";
    public const string ES = "es";
    public const string CH = "ch";
    public const string IE = "ie";
}
