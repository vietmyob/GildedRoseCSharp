using System.Collections.Generic;
using csharp.DTO;

namespace csharp.Logic
{
    public class GildedRose
    {
        private readonly List<Item> _items;
        private readonly InventoryProcessor _inventoryProcessor;

        public GildedRose(List<Item> items)
        {
            _items = items;
            _inventoryProcessor = new InventoryProcessor();
        }

        public void UpdateInventory()
        {
            _inventoryProcessor.Update(_items);
        }
    }
}
