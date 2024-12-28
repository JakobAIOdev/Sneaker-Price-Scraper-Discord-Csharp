using Discord;
using Discord.WebSocket;

class Program
{
    private DiscordSocketClient? _client;
    private bool includeSales = false; // Include sales information in embeds

    private readonly string botToken = ""; // Your bot token here

    static void Main(string[] args) => new Program().RunBotAsync().GetAwaiter().GetResult();

    public async Task RunBotAsync()
    {
        _client = new DiscordSocketClient(new DiscordSocketConfig
        {
            GatewayIntents = GatewayIntents.AllUnprivileged | GatewayIntents.MessageContent
        });

        _client.Log += Log;
        _client.MessageReceived += HandleCommandAsync;

        await _client.LoginAsync(TokenType.Bot, botToken);
        await _client.StartAsync();

        await Task.Delay(-1);
    }

    private Task Log(LogMessage msg)
    {
        Console.WriteLine(msg.ToString());
        return Task.CompletedTask;
    }

    private async Task HandleCommandAsync(SocketMessage message)
    {
        if (message.Author.IsBot) return;

        if (message.Content.StartsWith("!payout "))
        {
            System.Console.WriteLine("Payout command received");
            await SendPayoutPricesInEmbed(message);
        }
        else if (message.Content.StartsWith("!prices "))
        {
            System.Console.WriteLine("Prices command received");
            await SendPricesInEmbed(message);
        }
        else if (message.Content.StartsWith("!help"))
        {
            System.Console.WriteLine("Help command received");
            await message.Channel.SendMessageAsync("Usage: !payout <SKU> or !prices <SKU>");
        }
        else if (message.Content.StartsWith("!settings"))
        {
            System.Console.WriteLine("Settings command received");
            if (message.Content.Contains("sales"))
            {
                includeSales = !includeSales;
                await message.Channel.SendMessageAsync("Sales are now " + (includeSales ? "included" : "excluded"));
            }
            else
            {
                await message.Channel.SendMessageAsync("Usage: !settings sales");
            }
        }
        else if (message.Content.StartsWith("!paypal"))
        {
            System.Console.WriteLine("PayPal command received");
            await SendPayPalEmbed(message);
        }
        else if (message.Content.StartsWith("!help"))
        {
            System.Console.WriteLine("Help command received");
            await message.Channel.SendMessageAsync("Usage: !payout <SKU> or !prices <SKU>");
        }
    }

    private async Task SendPayoutPricesInEmbed(SocketMessage message)
    {
        string sku = message.Content.Substring(8).Trim();
        Hypeboost hypeboost = new Hypeboost(sku, includeSales);
        var embed = new EmbedBuilder()
            .WithTitle(hypeboost.GetProductTitle())
            .WithDescription("Payout prices on Hypeboost")
            .WithColor(Color.Blue)
            .WithThumbnailUrl(hypeboost.GetProductImg())
            .WithUrl(hypeboost.ProductUrl);


        string priceText = string.Join("\n", hypeboost.GetSizePayoutPrices());

        embed.AddField("Prices", priceText);

        await message.Channel.SendMessageAsync(embed: embed.Build());
    }

    private async Task SendPricesInEmbed(SocketMessage message)
    {
        string sku = message.Content.Substring(7).Trim();
        Hypeboost hypeboost = new Hypeboost(sku, includeSales);
        var embed = new EmbedBuilder()
            .WithTitle(hypeboost.GetProductTitle())
            .WithDescription("Prices on Hypeboost")
            .WithColor(Color.Blue)
            .WithThumbnailUrl(hypeboost.GetProductImg())
            .WithUrl(hypeboost.ProductUrl)
            .WithAuthor("HypeboostScraper", "https://github.com/JakobAIOdev", "https://www.reviewuk.co.uk/wp-content/uploads/2022/08/tok4mz0o2zi3dt92-400x400.jpg");


        string priceText = string.Join("\n", hypeboost.GetSizePrices());

        embed.AddField("Prices", priceText);
        embed.AddField("Links", "[Twitter](https://x.com/jakobaio) | [GitHub](https://github.com/JakobAIOdev)");


        await message.Channel.SendMessageAsync(embed: embed.Build());
    }

    private async Task SendPayPalEmbed(SocketMessage message)
    {
        string price = message.Content.Substring(7).Trim();
        float priceFloat = float.Parse(price);
        PayPal paypal = new PayPal(priceFloat);
        var embed = new EmbedBuilder()
            .WithTitle("PayPal Fees")
            .WithDescription("Calculating PayPal fees")
            .WithColor(Color.Blue)
            .WithThumbnailUrl("https://www.paypalobjects.com/webstatic/icon/pp258.png");

        embed.AddField("Input Price", priceFloat.ToString("C", new System.Globalization.CultureInfo("de-DE")));
        embed.AddField("Output Price", paypal.CalculatePayout().ToString("C", new System.Globalization.CultureInfo("de-DE")));
        embed.AddField("Fees", paypal.CalculateFees().ToString("C", new System.Globalization.CultureInfo("de-DE")));
        embed.AddField("Total", (paypal.CalculateFees() + priceFloat).ToString("C", new System.Globalization.CultureInfo("de-DE")));
        embed.AddField("Links", "[Twitter](https://x.com/jakobaio) | [GitHub](https://github.com/JakobAIOdev)");

        await message.Channel.SendMessageAsync(embed: embed.Build());
    }
}

