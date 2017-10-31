using csharp.DTO;

namespace csharp.Logic
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

        private void IncreaseSpecialItemQuality(Item item)
        {
            if (item.IsBelowMaxQuality())
            {
                item.Quality++;
                IncreaseQualityForBackstagePass(item);
            }
        }

        private void DecreaseNormalItemQuality(Item item)
        {
            if (item.HasPositiveQuality())
                item.Quality--;
        }

        private void IncreaseQualityForBackstagePass(Item item)
        {
            if (item.Name == ItemName.BackstagePass)
            {
                item.Quality = item.HasToBeSoldIn(11) && item.IsBelowMaxQuality() ? item.Quality + 1 : item.Quality;
                item.Quality = item.HasToBeSoldIn(6) && item.IsBelowMaxQuality() ? item.Quality + 1 : item.Quality;
            }
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
                case ItemName.AgedBrie:
                    IncreaseSpecialItemQuality(item);
                    break;
                case ItemName.BackstagePass:
                    item.Quality = 0;
                    break;
                default:
                    DecreaseNormalItemQuality(item);
                    break;
            }
        }
    }
}
