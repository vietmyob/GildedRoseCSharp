using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        private readonly List<Item> _iTems;

        public GildedRose(List<Item> iTems)
        {
            _iTems = iTems;
        }

        public void UpdateQuality()
        {
            foreach (var item in _iTems)
            {
                if (item.IsLegendary()) continue;

                if (item.IsSpecial())
                    UpdateSpecialItemQuality(item);
                else
                    UpdateNormalItemQuality(item);

                UpdateSellInDate(item);

                UpdateQualityAfterExpired(item);
            }
        }

        private void UpdateNormalItemQuality(Item item)
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

        private void UpdateQualityAfterExpired(Item item)
        {
            if (!item.HasExpired()) return;
            switch (item.Name)
            {
                case "Aged Brie":
                    item.Quality = item.Quality < 50 ? item.Quality + 1 : item.Quality;
                    break;
                case "Backstage passes to a TAFKAL80ETC concert":
                    item.Quality = 0;
                    break;
                default:
                    if (item.Quality > 0)
                        item.Quality = item.Quality - 1;
                    break;
            }
        }
    }
}
