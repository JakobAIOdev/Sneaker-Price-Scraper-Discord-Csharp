﻿using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;


string PrintList(List<string> list)
{
    string result = "";
    foreach (var item in list)
    {
        result += item + "\n";
    }
    return result;
}


// funktion to get the product URL by the SKU
string UrlRequest (string SKU)
{
    HttpClient client = new HttpClient();
    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"https://hypeboost.com/search/shop?keyword={SKU}");

    request.Headers.Add("accept", "*/*");
    request.Headers.Add("accept-language", "en-DE,en;q=0.9,de-DE;q=0.8,de;q=0.7,en-US;q=0.6");
    request.Headers.Add("cookie", "CookieConsent={stamp:%27DSteGbAfrY8IAjz0BLUBeGzCyXI/gmVX7oPxvrKrlmJaGMEj0A1k3A==%27%2Cnecessary:true%2Cpreferences:true%2Cstatistics:true%2Cmarketing:true%2Cmethod:%27explicit%27%2Cver:1%2Cutc:1725034899171%2Cregion:%27de%27}; locale=eyJpdiI6IjdoNHR3VTVBV3JPc0NYcmpFeGJTSmc9PSIsInZhbHVlIjoicFRiWU83MkhVZjIzMWlielUvYzMxSHpvZ2d5VlkrVDZJYzMwMWZjY0o4OW1Udk1oNVRRaEVpcWFmVlkyVGMwUCIsIm1hYyI6ImY4Yzg1OTFiODRjOTI0M2QwMDNmM2Q0Nzk5Yzk5YzYzMTc4NDA1NmNmNWZkNWViNzNhMWE5ZTk0NzNmMGUxMjciLCJ0YWciOiIifQ%3D%3D; country=eyJpdiI6Ik9pRjArOXdpR2JwMU5GY2ttY0Jxb0E9PSIsInZhbHVlIjoiU0hKMWgrTmJXcnVvb0pERzY5MUZZWGFGc25XbENyc1d5c2dhdTNJU1k0dEwvZXE5N05ZSHNyZk9vZkd6TXNsNSIsIm1hYyI6IjhjNjIxZDAxMjJlNjNlM2E3OTIzZWE0ZjE1NmU4NWJkNmQwNGU5N2JjMjQxZDM4MGE2NTI2N2MwN2UyMWU4MGIiLCJ0YWciOiIifQ%3D%3D; currency=eyJpdiI6IjZ0SlRsWVpZQTFEejFwaDZvdk5UL0E9PSIsInZhbHVlIjoiYzFIaUlUREd4cEJwemtHTGhqZEI1WjJ6dVNUZWFKQTU3cWlkeG9GREpNNExlZVMrZVh0YkJQQUQ3Uit1ZEhZcSIsIm1hYyI6IjM4N2M2MGE1NmE2NTRlNTVjNzNlM2ZkMDMyZTg2NTI5YTg3OTVmYmU5MjM5NDYzNDg4ZGJlYmYyYzRjYzM4NjIiLCJ0YWciOiIifQ%3D%3D; XSRF-TOKEN=eyJpdiI6IkR4YmRmQ29KQ1lrYytqdHV0MGFCOVE9PSIsInZhbHVlIjoiVHk0OFA3cWE2bWFScHlSK2VlZS8vTkdycXJ4OGZqb2N6Q2xrRlpWbTk1d1BzNnQza2VDMUJHSXFwV2svOE5rZCtMNXN5ZnU3bVAyd1NZZllwWFdlL3ZqYzJ4Vkx4Q2s0cWc1Q1l2a0RadkdLK0l6bjMrWlRLdG13dmZhT0dDZmUiLCJtYWMiOiJhYzAyYjljM2IzNTBlNGVjODEyNmIzZmZjMjA3ZjcwMDE0YWE0ZDYwMzY1MDM4ZWM5ZGFhODg3ZDU3NGFmMzFkIiwidGFnIjoiIn0%3D; hypeboost_session=eyJpdiI6IldiR05YcnQ2czArNXdySnNHNndXZVE9PSIsInZhbHVlIjoiRnc2TnBHREhBVHB5dHh3aGlVMER6OTk3RWIxK0VoTHRQQWxrQ3ltYk95TzkrVDNYTE1uYjFSVE5GNlFVTkp0b0l3cHhsUnFnbERmVUdTM0ZBZ0Q0Q1luWmxXa1JQTG1ZSVo4S3BrNUhCTVJ3WTZ4a3lEcEFtQlhhaFk3amN5ek8iLCJtYWMiOiI5OGM1YzVlYWVmOTliOTcwNGFmZDU3YmJmNDRkOGNkM2RmMDVjOWVmZGM3NjQxNDUyYzY4ZmJkYjQ3NjcxMmFlIiwidGFnIjoiIn0%3D");
    request.Headers.Add("dnt", "1");
    request.Headers.Add("priority", "u=1, i");
    request.Headers.Add("referer", "https://hypeboost.com/product/adidas-samba-og-maroon-gold-metallic");
    request.Headers.Add("sec-ch-ua", "\"Google Chrome\";v=\"131\", \"Chromium\";v=\"131\", \"Not_A Brand\";v=\"24\"");
    request.Headers.Add("sec-ch-ua-mobile", "?0");
    request.Headers.Add("sec-ch-ua-platform", "\"macOS\"");
    request.Headers.Add("sec-fetch-dest", "empty");
    request.Headers.Add("sec-fetch-mode", "cors");
    request.Headers.Add("sec-fetch-site", "same-origin");
    request.Headers.Add("user-agent", "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/131.0.0.0 Safari/537.36");
    request.Headers.Add("x-requested-with", "XMLHttpRequest");

    HttpResponseMessage response = client.Send(request);
    response.EnsureSuccessStatusCode();
    string responseBody;
    using (var reader = new StreamReader(response.Content.ReadAsStream()))
    {
        responseBody = reader.ReadToEnd();
    }
    System.Console.WriteLine($"Request status: {response.StatusCode}");
    string productUrl = responseBody.Split("href=\"")[1].Split("\"")[0];
    System.Console.WriteLine(productUrl);
    return productUrl;
}

List<string> GetSizePrices(string SKU)
{
    var HttpClient = new HttpClient();
    var html = HttpClient.GetStringAsync(UrlRequest(SKU)).Result;
    var htmldoc = new HtmlDocument();
    htmldoc.LoadHtml(html);

    List<string> sizePrices = new List<string>();

    var sizes = htmldoc.DocumentNode.SelectNodes("//div[contains(@class, 'size available')]");

    if (sizes != null)
    {
        foreach (var size in sizes)
        {
            var sizeLabel = size.SelectSingleNode(".//div[@class='label']")?.InnerText.Trim();
            var price = size.SelectSingleNode(".//div[@class='price']//span")?.InnerText.Trim();
            var salesCount = size.GetAttributeValue("data-seller-sales-count", "").Replace("sales", "").Trim('(', ')').Trim();

            if (!string.IsNullOrEmpty(sizeLabel) && !string.IsNullOrEmpty(price))
            {
                sizePrices.Add($"{sizeLabel}: {price} (Seller has {salesCount} sales)");
            }
        }
    }

    return sizePrices;
}


List<string> GetSizePayoutPrices(string SKU)
{
    var HttpClient = new HttpClient();
    var html = HttpClient.GetStringAsync(UrlRequest(SKU)).Result;
    var htmldoc = new HtmlDocument();
    htmldoc.LoadHtml(html);

    List<string> sizePrices = new List<string>();

    var sizes = htmldoc.DocumentNode.SelectNodes("//div[contains(@class, 'size available')]");

    if (sizes != null)
    {
        foreach (var size in sizes)
        {
            var sizeLabel = size.SelectSingleNode(".//div[@class='label']")?.InnerText.Trim();
            var priceText = size.SelectSingleNode(".//div[@class='price']//span")?.InnerText.Trim();
            var salesCount = size.GetAttributeValue("data-seller-sales-count", "").Replace("sales", "").Trim('(', ')').Trim();

            if (!string.IsNullOrEmpty(sizeLabel) && !string.IsNullOrEmpty(priceText))
            {
                var priceValue = decimal.Parse(priceText.Replace("€", "").Trim());
                var calculatedPrice = priceValue * 0.915m - 15;

                sizePrices.Add($"{sizeLabel}: {calculatedPrice:F2} € (Seller has: {salesCount} sales)");
            }
        }
    }

    return sizePrices;
}

System.Console.WriteLine("Payout Prices:");
System.Console.WriteLine(PrintList(GetSizePayoutPrices("DZ5485-612")));
System.Console.WriteLine("--------------------");
System.Console.WriteLine("Prices:");
System.Console.WriteLine(PrintList(GetSizePrices("DZ5485-612")));