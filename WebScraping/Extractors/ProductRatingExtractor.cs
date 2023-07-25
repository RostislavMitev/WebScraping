using HtmlAgilityPack;

namespace WebScraping.Extractors
{
    public class ProductRatingExtractor
    {
        public static decimal VerifyRating(HtmlNode productNode)
        {
            decimal rating;
            //finding the rating of the product
            string ratingValue = productNode.GetAttributeValue("rating", String.Empty);
            //try-catch to encounter wrong input rating
            try
            {
                rating = decimal.Parse(ratingValue);

                //normalising the rating from a 1-10 scale to 1-5 scale if needed
                if (rating > 5 && rating <= 10) rating = (rating - 1) * (5 - 1) / (10 - 1) + 1;
            }
            catch (Exception)
            {
                rating = 0;
            }

            return rating;
        }
    }
}
