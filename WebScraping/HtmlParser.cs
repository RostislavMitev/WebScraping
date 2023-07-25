using HtmlAgilityPack;

namespace WebScraping
{
    using Extractors;

    public class HtmlParser
    {
        public static List<ProductInfo> InformationExtractor(string input)
        {
            List<ProductInfo> products = new List<ProductInfo>();

            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(input);
            //selecting everything inside the html code
            HtmlNodeCollection productNodes = htmlDocument.DocumentNode.SelectNodes("//div[@class='item']");

            //walking through the html code
            if (productNodes != null)
            {
                //going through every single node and then extracting and storing only the needed information
                foreach (HtmlNode productNode in productNodes)
                {
                    string productName = ProductNameExtractor.VerifyName(productNode);
                    string price = ProductPriceExtractor.VerifyPrice(productNode);
                    decimal rating = ProductRatingExtractor.VerifyRating(productNode);

                    //summary of the current product with all details
                    products.Add(new ProductInfo
                    {
                        ProductName = productName,
                        Price = price,
                        Rating = rating,
                    });
                }
            }

            return products;
        }
    }
}