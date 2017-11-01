using csharp.DTO;

namespace csharp.Logic
{
    public class ItemUpdater
    {
        private readonly ItemChecker _itemChecker = new ItemChecker();

        public void UpdateQualityBeforeExpired(Item item)
        {
            if (_itemChecker.IsSpecial(item))
                IncreaseSpecialItemQuality(item);
            else
                DecreaseNormalItemQuality(item);
        }

        private void IncreaseSpecialItemQuality(Item item)
        {
            if (_itemChecker.IsBelowMaxQuality(item))
            {
                item.Quality++;
                IncreaseQualityForBackstagePass(item);
            }
        }

        private void DecreaseNormalItemQuality(Item item)
        {
            if (_itemChecker.HasPositiveQuality(item))
                item.Quality--;
        }

        private void IncreaseQualityForBackstagePass(Item item)
        {
            if (item.Name == ItemName.BackstagePass)
            {
                UpdateBackstagePassQualityBasedOnSellIn(item, 11);
                UpdateBackstagePassQualityBasedOnSellIn(item, 6);
            }
        }

        private void UpdateBackstagePassQualityBasedOnSellIn(Item item, int days)
        {
            if (_itemChecker.IsBelowMaxQuality(item) && _itemChecker.HasToBeSoldIn(item, days))
                item.Quality++;
        }

        public void UpdateSellInDate(Item item)
        {
            item.SellIn--;
        }

        public void UpdateQualityAfterExpired(Item item)
        {
            if (!_itemChecker.HasExpired(item)) return;
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
