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
            if (_itemChecker.HasExpired(item))
                item.Quality = 0;
        }

        private void UpdateQuality(Item item)
        {
            if (_itemChecker.IsBelowMaxQuality(item))
            {
                item.Quality++;
                _itemUpdater.IncreaseQualityForBackstagePass(item);
            }
        }
    }
}