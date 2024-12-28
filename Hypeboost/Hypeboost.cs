using HtmlAgilityPack;

class Hypeboost
{
    public string SKU { get; set; }
    public bool IncludeSales { get; set; }
    public string ProductUrl { get; set; }
    
    public Hypeboost(string sku, bool includeSales)
    {
        SKU = sku;
        ProductUrl = GetUrl(sku);
        IncludeSales = includeSales;
    }


    private static string GetUrl(string SKU)
    {

        try
        {
            var HttpClient = new HttpClient();
            var html = HttpClient.GetStringAsync($"https://hypeboost.com/search/shop?keyword={SKU}").Result;
            var htmldoc = new HtmlDocument();
            htmldoc.LoadHtml(html);

            var productUrl = htmldoc.DocumentNode.SelectSingleNode("//a[contains(@href, 'hypeboost.com')]");

            if (productUrl != null)
            {
                var url = productUrl.GetAttributeValue("href", "");
                return url;
            }

            return "No product found";
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

    public string GetProductImg()
    {
        try
        {
            var HttpClient = new HttpClient();
            var html = HttpClient.GetStringAsync(ProductUrl).Result;
            var htmldoc = new HtmlDocument();
            htmldoc.LoadHtml(html);

            var imgNode = htmldoc.DocumentNode.SelectSingleNode("//img[contains(@src, 'hypeboost.com')]");

            if (imgNode != null)
            {
                var imgSrc = imgNode.GetAttributeValue("src", "");
                return imgSrc;
            }

            return "No picture found";
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

    public string GetProductTitle()
    {
        try
        {
            var HttpClient = new HttpClient();
            var html = HttpClient.GetStringAsync(ProductUrl).Result;
            var htmldoc = new HtmlDocument();
            htmldoc.LoadHtml(html);

            string productTitle = htmldoc.DocumentNode.SelectSingleNode("//h1")?.InnerText.Trim() ?? string.Empty;

            if(productTitle.Contains("&#039;"))
            {
                productTitle = productTitle.Replace("&#039;", "'");
            }
            
            return productTitle;
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

    public List<string> GetSizePrices()
    {
        try
        {
            var HttpClient = new HttpClient();
            var html = HttpClient.GetStringAsync(ProductUrl).Result;
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
                        if(IncludeSales)
                        {
                            sizePrices.Add($"{sizeLabel}: {price} (Seller has {salesCount} sales)");
                        }
                        else
                        {
                            sizePrices.Add($"{sizeLabel}: {price }");
                        }
                    }
                }
            }

            return sizePrices;
        }
        catch (Exception e)
        {
            return new List<string> { e.Message };
        }
    }


    public List<string> GetSizePayoutPrices()
    {
        try
        {
            var HttpClient = new HttpClient();
            var html = HttpClient.GetStringAsync(ProductUrl).Result;
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

                        if(IncludeSales)
                        {
                            sizePrices.Add($"{sizeLabel}: {calculatedPrice:F2} € (Seller has: {salesCount} sales)");
                        }
                        else
                        {
                            sizePrices.Add($"{sizeLabel}: {calculatedPrice:F2} €");
                        }
                    }
                }
            }

            return sizePrices;
        }
        catch (Exception e)
        {
            return new List<string> { e.Message };
        }
    }

    public string PrintList(List<string> list)
    {   
        try
        {
            string result = "";
            foreach (var item in list)
            {
                result += item + "\n";
            }
            return result;
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }


}