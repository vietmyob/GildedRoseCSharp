using System.Collections.Generic;
using csharp.DTO;
using csharp.Logic;
using NUnit.Framework;

namespace csharp.UnitTest
{
    [TestFixture]
    public class InventoryConfigSerialiserShould
    {
        [Test]
        public void GenerateXmlConfig()
        {
            var serialiser = new InventoryConfigSerialiser();
            var inventoryConfig = new InventoryConfig();
            var itemUpdaterMaps = new List<ItemUpdaterMap>
            {
                new ItemUpdaterMap {ItemName = "Normal Item", UpdaterClass = "NormalItemUpdater"},
                new ItemUpdaterMap {ItemName = "Aged Brie", UpdaterClass = "AgedBrieUpdater"},
                new ItemUpdaterMap {ItemName = "Sulfuras, Hand of Ragnaros", UpdaterClass = "SulfurasUpdater"},
                new ItemUpdaterMap {ItemName = "Backstage passes to a TAFKAL80ETC concert", UpdaterClass = "BackstagePassUpdater"},
                new ItemUpdaterMap {ItemName = "Conjured", UpdaterClass = "ConjuredUpdater"}
            };
            inventoryConfig.ItemUpdaterMaps = itemUpdaterMaps;
            serialiser.Generate(inventoryConfig);
        }
    }
}
