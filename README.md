# Sneaker Price Scraper Discord Hypeboost

## Only Hypeboost is working as of now!
This project is a sneaker price scraper that allows users to query sneaker prices on Hypeboost using Discord commands.

The bot fetches the latest prices for sneakers from Hypeboost, and displays them in a clean and organized manner on Discord.

  

## Features

Price Scraping: Scrapes sneaker payout prices or listing prices from Hypeboost.

Discord Command Integration: Allows users to query sneaker prices directly via a Discord bot.

Multiple Commands: Users can enter different commands to query different types of sneakers or sizes.

  

## Requirements

+ .NET Core 3.1 or higher

+ Discord.Net library for creating the bot

+ A Discord bot token

  

## Commands

+ "!payout <SKU>" returns the payout prices for all avaible sizes of the given sku.

+ "!prices <SKU>" returns the listing prices for all avaible sizes of the given sku.

+ "!settings sales" gives the option to enable or disable the sales information of the seller in the embed message.

+ "!help" for a list of all commands.

  

## Installation

  
1. Clone the repository:

```
git clone git@github.com:JakobAIOdev/Sneaker-Price-Scraper-Csharp.git
```

2. Input your Discord-Bot-Token in the **Program.cs**
```
private  readonly  string  botToken  =  ""; // Your bot token here
```

4. Run the bot:
```
dotnet run
```


## Usage Examples

(includeSales = false;)
!payout DZ5485-612
<br>
<img width="300" src="https://github.com/user-attachments/assets/99d6e7b6-7e6f-4026-941c-df66bfd00d53" />


!settings sales
<br>
<img width="300" src="https://github.com/user-attachments/assets/73ad9a1a-de8f-43e4-835a-ab1e9a3ae1b6" />


(includeSales = true;)
!payout DZ5485-612
<br>
<img width="300" src="https://github.com/user-attachments/assets/950e6f42-202c-4a9f-a1a8-72316026c8b6" />


(includeSales = false;)
!prices DZ5485-612
<br>
<img width="300" src="https://github.com/user-attachments/assets/0dfdb1b0-5c9b-4e05-b1d9-3dbc98e98a50" />



---

## Contributing

1. Fork the repository.
2. Create a new branch (`git checkout -b feature-branch`).
3. Commit your changes (`git commit -am 'Add new feature'`).
4. Push to the branch (`git push origin feature-branch`).
5. Open a pull request.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
