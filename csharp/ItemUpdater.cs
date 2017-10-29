namespace csharp
{
    public class ItemUpdater
    {
        public void UpdateQualityBeforeExpired(Item item)
        {
            if (item.IsSpecial())
                IncreaseSpecialItemQuality(item);
            else
                DecreaseNormalItemQuality(item);
        }

        private void DecreaseNormalItemQuality(Item item)
        {
            if (item.Quality <= 0) return;
            item.Quality--;
        }

        private void IncreaseSpecialItemQuality(Item item)
        {
            if (item.Quality >= 50) return;
            item.Quality++;
            IncreaseQualityForBackstagePass(item);
        }

        private void IncreaseQualityForBackstagePass(Item item)
        {
            if (item.Name != "Backstage passes to a TAFKAL80ETC concert") return;
            item.Quality = item.SellIn < 11 && item.Quality < 50 ? item.Quality + 1 : item.Quality;
            item.Quality = item.SellIn < 6 && item.Quality < 50 ? item.Quality + 1 : item.Quality;
        }

        public void UpdateSellInDate(Item item)
        {
            item.SellIn--;
        }

        public void UpdateQualityAfterExpired(Item item)
        {
            if (!item.HasExpired()) return;
            switch (item.Name)
            {
                case "Aged Brie":
                    IncreaseSpecialItemQuality(item);
                    break;
                case "Backstage passes to a TAFKAL80ETC concert":
                    item.Quality = 0;
                    break;
                default:
                    DecreaseNormalItemQuality(item);
                    break;
            }
        }
    }
}
