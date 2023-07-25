using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace WebScraping.Extractors
{
    public class ProductNameExtractor
    {
        public static string VerifyName(HtmlNode productNode)
        {
            //finding the product name
            string productName = productNode.SelectSingleNode(".//h4/a").InnerText;
            //clearing the product name of any symbols
            Regex regex = new Regex(@"\b[A-Za-z]+\b *");
            MatchCollection matches = regex.Matches(productName);

            //walking through all the words that have covered the requirements of the regex
            if (matches.Count > 0)
            {
                productName = string.Empty;
                foreach (Match match in matches)
                {
                    productName += match.Value; //adding up every word from the regex to a string
                }
            }
            else return "Unknown";

            return productName;
        }
    }
}
