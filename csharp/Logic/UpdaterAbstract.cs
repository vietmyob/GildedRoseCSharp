using csharp.DTO;

namespace csharp.Logic
{
    public abstract class UpdaterAbstract
    {
        private readonly ItemChecker _itemChecker;

        protected UpdaterAbstract()
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
    }
}
