using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;


string SKU = "DZ5485-612";

string GetURL(string SKU)
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

//System.Console.WriteLine(GetURL(SKU));

string GetImg(string SKU)
{
    string requestUrl = $"https://ac.cnstrc.com/search/{SKU}?c=ciojs-client-2.29.12&key=key_XT7bjdbvjgECO5d8&i=5c1db6a2-7a42-4cbd-9606-96a08face508&s=23&num_results_per_page=1&_dt=1679422941544";
    HttpClient client = new HttpClient();
    var response = client.GetAsync(requestUrl).Result;
    response.EnsureSuccessStatusCode();
    string jsonString = response.Content.ReadAsStringAsync().Result;

    JObject json = JObject.Parse(jsonString);
                
    string imageUrl = json["response"]?["results"]?[0]?["data"]?["image_url"]?.ToString() ?? string.Empty;
    if(imageUrl != null)
    {
        return imageUrl;
    }
    else
    {
        return "SKU not found";
    }
}
//System.Console.WriteLine(GetImg(SKU));

string GetTitle(string SKU)
{
    string requestUrl = $"https://ac.cnstrc.com/search/{SKU}?c=ciojs-client-2.29.12&key=key_XT7bjdbvjgECO5d8&i=5c1db6a2-7a42-4cbd-9606-96a08face508&s=23&num_results_per_page=1&_dt=1679422941544";
    HttpClient client = new HttpClient();
    var response = client.GetAsync(requestUrl).Result;
    response.EnsureSuccessStatusCode();
    string jsonString = response.Content.ReadAsStringAsync().Result;

    JObject json = JObject.Parse(jsonString);
                
    string productTitle = json["response"]?["results"]?[0]?["value"]?.ToString() ?? string.Empty;
    if(productTitle != null)
    {
        return productTitle;
    }
    else
    {
        return "SKU not found";
    }
}
//System.Console.WriteLine(GetTitle(SKU));

string[] GetProductInfos(string SKU)
{
    string requestUrl = $"https://ac.cnstrc.com/search/{SKU}?c=ciojs-client-2.29.12&key=key_XT7bjdbvjgECO5d8&i=5c1db6a2-7a42-4cbd-9606-96a08face508&s=23&num_results_per_page=1&_dt=1679422941544";
    HttpClient client = new HttpClient();
    var response = client.GetAsync(requestUrl).Result;
    response.EnsureSuccessStatusCode();
    string jsonString = response.Content.ReadAsStringAsync().Result;

    JObject json = JObject.Parse(jsonString);

    string slug = json["response"]?["results"]?[0]?["data"]?["slug"]?.ToString() ?? string.Empty;
    string productUrl = "https://www.goat.com/sneakers/" + slug;

    string imageUrl = json["response"]?["results"]?[0]?["data"]?["image_url"]?.ToString() ?? string.Empty;
    string productTitle = json["response"]?["results"]?[0]?["value"]?.ToString() ?? string.Empty;

    string productID = json["response"]?["results"]?[0]?["data"]?["id"]?.ToString() ?? string.Empty;

    string[] productInfos = {productTitle, productUrl, imageUrl, productID};
    return productInfos;
}

string PrintArray(string[] array)
{
    string result = "";
    foreach (string item in array)
    {
        result += item + "\n";
    }
    return result;
}


//System.Console.WriteLine(PrintArray(GetProductInfos(SKU)));
//string url = GetProductInfos(SKU)[1];
//System.Console.WriteLine(GetProductInfos(SKU)[3]);



// 403 forbidden cloudflare
/*
List<string> GetSizesPrices(string SKU, string productID, CountryCode countryCode)
{
    productID = GetProductInfos(SKU)[3];
    //string requestUrl = $"https://www.goat.com/web-api/v1/product_variants/buy_bar_data?productTemplateId={productID}&countryCode={countryCode}";
    string requestUrl = "https://www.goat.com/web-api/v1/product_variants/buy_bar_data?productTemplateId=920714&countryCode=DE";
    // cloudflare 403 forbidden
    HttpClient client = new HttpClient();
    var response = client.GetAsync(requestUrl).Result;
    response.EnsureSuccessStatusCode();
    string jsonString = response.Content.ReadAsStringAsync().Result;
    JObject json = JObject.Parse(jsonString);

    List<string> sizesPrices = new List<string>();
    for(int i = 0; i < json.Count; i++)
    {
        var line = json[i];
        System.Console.WriteLine(line);
    }

    return sizesPrices;

}
//System.Console.WriteLine(GetSizesPrices(SKU, GetProductInfos(SKU)[3], CountryCode.DE));

enum CountryCode
{
    US,
    DE,
    UK,
    FR,
    IT,
    ES,
    CA,
    AU,
    JP,
    CN
}
*/