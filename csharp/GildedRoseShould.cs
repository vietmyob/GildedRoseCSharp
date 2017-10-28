using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace csharp
{
    [TestFixture]
    public class GildedRoseShould
    {
        [Test]
        public void ReduceQualityByOneForNormalItem()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Normal Item", SellIn = 15, Quality = 20 } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(19, items.First().Quality);
        }
    }
}
