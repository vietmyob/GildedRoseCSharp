using csharp.DTO;
using csharp.Interface;

namespace csharp.Logic.Updater
{
    public class ConjuredUpdater : IUpdater
    {
        private readonly ItemChecker _itemChecker = new ItemChecker();
        private readonly ItemUpdater _itemUpdater = new ItemUpdater();
        public void Update(Item item)
        {
            _itemUpdater.UpdateSellInDate(item);
            UpdateQuality(item);
        }

        private void UpdateQuality(Item item)
        {
            if (_itemChecker.HasExpired(item))
            {
                item.Quality = _itemChecker.HasPositiveQuality(item) ? item.Quality - 1 : item.Quality;
                item.Quality = _itemChecker.HasPositiveQuality(item) ? item.Quality - 1 : item.Quality;
                item.Quality = _itemChecker.HasPositiveQuality(item) ? item.Quality - 1 : item.Quality;
                item.Quality = _itemChecker.HasPositiveQuality(item) ? item.Quality - 1 : item.Quality;
            }
            else
            {
                item.Quality = _itemChecker.HasPositiveQuality(item) ? item.Quality - 1 : item.Quality;
                item.Quality = _itemChecker.HasPositiveQuality(item) ? item.Quality - 1 : item.Quality;
            }
        }
    }
}