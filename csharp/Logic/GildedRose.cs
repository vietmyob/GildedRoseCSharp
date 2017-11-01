using System.Collections.Generic;
using csharp.DTO;

namespace csharp.Logic
{
    public class GildedRose
    {
        private readonly List<Item> _iTems;
        private readonly ItemUpdater _itemUpdater;
        private readonly ItemChecker _itemChecker;

        public GildedRose(List<Item> iTems)
        {
            _iTems = iTems;
            _itemUpdater = new ItemUpdater();
            _itemChecker = new ItemChecker();
        }

        public void UpdateInventory()
        {
            foreach (var item in _iTems)
            {
                if (_itemChecker.IsLegendary(item)) continue;

                _itemUpdater.UpdateQualityBeforeExpired(item);

                _itemUpdater.UpdateSellInDate(item);

                _itemUpdater.UpdateQualityAfterExpired(item);
            }
        }
    }
}
