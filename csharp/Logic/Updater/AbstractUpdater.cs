using csharp.DTO;

namespace csharp.Logic.Updater
{
    public abstract class AbstractUpdater
    {
        private readonly ItemChecker _itemChecker;

        protected AbstractUpdater()
        {
            _itemChecker = new ItemChecker();
        }

        protected void IncreaseQualityByOne(Item item)
        {
            item.Quality = _itemChecker.IsBelowMaxQuality(item) ? item.Quality + 1 : item.Quality;
        }

        protected void DecreaseQualityByOne(Item item)
        {
            item.Quality = _itemChecker.HasPositiveQuality(item) ? item.Quality - 1 : item.Quality;
        }

        protected void UpdateSellIn(Item item)
        {
            item.SellIn--;
        }
    }
}
