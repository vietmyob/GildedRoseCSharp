using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        private readonly List<Item> _iTems;
        private readonly List<string> _speciaItems;
        private readonly string _legendaryItem;
        public GildedRose(List<Item> iTems)
        {
            _iTems = iTems;
            _speciaItems = new List<string>
            {
                "Aged Brie" , "Backstage passes to a TAFKAL80ETC concert"
            };
            _legendaryItem = "Sulfuras, Hand of Ragnaros";
        }

        public void UpdateQuality()
        {
            foreach (var item in _iTems)
            {
                if (IsLegendaryItem(item)) continue;
                if (IsSpecialItem(item))
                {
                    UpdateSpecialItemQuality(item);
                }
                else
                {
                    UpdateNormalItemQuality(item);
                }

                UpdateSellInDate(item);

                if (item.SellIn < 0)
                {
                    if (item.Name == "Aged Brie")
                    {
                        item.Quality = item.Quality < 50 ? item.Quality + 1 : item.Quality;
                    }
                    else
                    {
                        if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            item.Quality = 0;
                        }
                        else
                        {
                            if (item.Quality > 0)
                            {
                                item.Quality = item.Quality - 1;
                            }
                        }
                    }
                }
            }
        }

        private static void UpdateNormalItemQuality(Item item)
        {
            if (item.Quality <= 0) return;
            item.Quality = item.Quality - 1;
        }

        private void UpdateSpecialItemQuality(Item item)
        {
            if (item.Quality >= 50) return;
            item.Quality = item.Quality + 1;
            UpdateQualityForBackstagePass(item);
        }

        private void UpdateQualityForBackstagePass(Item item)
        {
            if (item.Name != "Backstage passes to a TAFKAL80ETC concert") return;
            item.Quality = item.SellIn < 11 && item.Quality < 50 ? item.Quality + 1 : item.Quality;
            item.Quality = item.SellIn < 6 && item.Quality < 50 ? item.Quality + 1 : item.Quality;
        }

        private void UpdateSellInDate(Item item)
        {
            item.SellIn = item.SellIn - 1;
        }

        private bool IsLegendaryItem(Item item)
        {
            return item.Name == _legendaryItem;
        }

        private bool IsSpecialItem(Item item)
        {
            return _speciaItems.Contains(item.Name);
        }
    }
}
