// Example SKU: DZ5485-612

Hypeboost hypeboost = new Hypeboost(args[0], false);
//System.Console.WriteLine(hypeboost.GetProductImg(args[0]));
System.Console.WriteLine(hypeboost.GetProductTitle());
System.Console.WriteLine("Prices:");
System.Console.WriteLine(hypeboost.PrintList(hypeboost.GetSizePrices()));