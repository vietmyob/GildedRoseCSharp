using csharp.DTO;

namespace csharp.Logic
{
    public class ItemChecker
    {
        public bool HasExpired(Item item)
        {
            return item.SellIn < 0;
        }

        public bool HasPositiveQuality(Item item)
        {
            return item.Quality > 0;
        }

        public bool IsBelowMaxQuality(Item item)
        {
            return item.Quality < 50;
        }

        public bool HasToBeSoldIn(Item item, int days)
        {
            return item.SellIn < days;
        }
    }
}
