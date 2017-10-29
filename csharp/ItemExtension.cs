using System.Collections.Generic;

namespace csharp
{
    public static class ItemExtension
    {
        private static readonly List<string> SpeciaItems;
        private static readonly string LegendaryItem;

        static ItemExtension()
        {
            SpeciaItems = new List<string>
            {
                "Aged Brie",
                "Backstage passes to a TAFKAL80ETC concert"
            };
            LegendaryItem = "Sulfuras, Hand of Ragnaros";
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
    }
}
