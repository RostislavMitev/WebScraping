using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace WebScraping.Extractors
{
    public class ProductPriceExtractor
    {
        public static string VerifyPrice(HtmlNode productNode)
        {
            //finding the price of the product
            string price = productNode.SelectSingleNode(".//span[@class='price-display formatted']").InnerText;

            //clearing the price string from any symbols (including the currency)
            Regex regex = new Regex(@"[0-9,.]+");

            //finding the first match using the regex
            Match match = regex.Match(price);

            //keeping the value from the regex into the price variable
            price = match.Value;

            //checking if there was no price provided after the regex
            if (string.IsNullOrWhiteSpace(price)) return "Unknown";

            return price;
        }
    }
}
