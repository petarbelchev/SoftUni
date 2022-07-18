using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _02._Fancy_Barcodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfBarcodes = int.Parse(Console.ReadLine());

            Regex regexForBarcodes = new Regex(@"(@#+)(?<barcode>[A-Z][A-Za-z0-9]{4,}[A-Z])(@#+)");
            Regex regexForDigits = new Regex(@"\d+");

            for (int i = 0; i < numOfBarcodes; i++)
            {
                string currBarcode = Console.ReadLine();

                Match matchBarcode = regexForBarcodes.Match(currBarcode);

                if (!matchBarcode.Success)
                {
                    Console.WriteLine("Invalid barcode");
                    continue;
                }

                string productGroup = string.Empty;

                if (regexForDigits.IsMatch(matchBarcode.Groups["barcode"].Value))
                {
                    MatchCollection matchesDigits = regexForDigits.Matches(matchBarcode.Groups["barcode"].Value);

                    StringBuilder sb = new StringBuilder();

                    foreach (Match match in matchesDigits)
                    {
                        sb.Append(match.Value);
                    }

                    productGroup = sb.ToString().TrimEnd();
                }
                else
                {
                    productGroup = "00";
                }

                Console.WriteLine($"Product group: {productGroup}");
            }
        }
    }
}
