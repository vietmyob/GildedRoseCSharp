using csharp.DTO;
using csharp.Interface;

namespace csharp.Logic.Updater
{
    public class BackstagePassUpdater : IUpdater
    {
        private readonly ItemChecker _itemChecker = new ItemChecker();
        private readonly ItemUpdater _itemUpdater = new ItemUpdater();

        public void Update(Item item)
        {
            UpdateQuality(item);
            _itemUpdater.UpdateSellInDate(item);
            DropQualityAfterExpired(item);
        }

        private void DropQualityAfterExpired(Item item)
        {
            if (_itemChecker.HasExpired(item))
                item.Quality = 0;
        }

        private void UpdateQuality(Item item)
        {
            if (!_itemChecker.IsBelowMaxQuality(item)) return;
            item.Quality++;
            IncreaseQualityForBackstagePass(item);
        }

        private void IncreaseQualityForBackstagePass(Item item)
        {
            if (item.Name != ItemName.BackstagePass) return;
            UpdateBackstagePassQualityBasedOnSellIn(item, 11);
            UpdateBackstagePassQualityBasedOnSellIn(item, 6);
        }

        private void UpdateBackstagePassQualityBasedOnSellIn(Item item, int days)
        {
            if (_itemChecker.IsBelowMaxQuality(item) && _itemChecker.HasToBeSoldIn(item, days))
                item.Quality++;
        }
    }
}