using csharp.DTO;
using csharp.Interface;

namespace csharp.Logic.Updater
{
    public class AgedBrieUpdater : UpdaterAbstract, IUpdater
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
                IncreaseQualityByOne(item);
                IncreaseQualityByOne(item);
            }
            else
            {
                IncreaseQualityByOne(item);
            }
        }
    }
}
