using System.Collections.Generic;
using csharp.DTO;

namespace csharp.Logic
{
    public class ItemChecker
    {
        private readonly List<string> _speciaItems;
        private readonly string _legendaryItem;

        public ItemChecker()
        {
            _speciaItems = new List<string>
            {
                ItemName.AgedBrie,
                ItemName.BackstagePass
            };
            _legendaryItem = ItemName.Sulfuras;
        }

        public bool HasExpired(Item item)
        {
            return item.SellIn < 0;
        }

        public bool IsLegendary(Item item)
        {
            return item.Name == _legendaryItem;
        }

        public bool IsSpecial(Item item)
        {
            return _speciaItems.Contains(item.Name);
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
