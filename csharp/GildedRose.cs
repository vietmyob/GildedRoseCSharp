using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        private readonly List<Item> _iTems;
        private readonly ItemUpdater _itemUpdater;
        public GildedRose(List<Item> iTems)
        {
            _iTems = iTems;
            _itemUpdater = new ItemUpdater();
        }

        public void UpdateInventory()
        {
            foreach (var item in _iTems)
            {
                if (item.IsLegendary()) continue;

                _itemUpdater.UpdateQualityBeforeExpired(item);

                _itemUpdater.UpdateSellInDate(item);

                _itemUpdater.UpdateQualityAfterExpired(item);
            }
        }
    }
}
