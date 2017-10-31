using System.Collections.Generic;
using csharp.DTO;

namespace csharp.Logic
{
    public static class ItemExtension
    {
        private static readonly List<string> SpeciaItems;
        private static readonly string LegendaryItem;

        static ItemExtension()
        {
            SpeciaItems = new List<string>
            {
                ItemName.AgedBrie,
                ItemName.BackstagePass
            };
            LegendaryItem = ItemName.Sulfuras;
        }

        public static bool HasExpired(this Item item)
        {
            return item.SellIn < 0;
        }

        public static bool IsLegendary(this Item item)
        {
            return item.Name == LegendaryItem;
        }

        public static bool IsSpecial(this Item item)
        {
            return SpeciaItems.Contains(item.Name);
        }

        public static bool HasPositiveQuality(this Item item)
        {
            return item.Quality > 0;
        }

        public static bool IsBelowMaxQuality(this Item item)
        {
            return item.Quality < 50;
        }

        public static bool HasToBeSoldIn(this Item item, int days)
        {
            return item.SellIn < days;
        }
    }
}
