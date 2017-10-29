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
            var items = new List<Item> { new Item { Name = "Normal Item", SellIn = 15, Quality = 20 } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(19, items.First().Quality);
        }

        [Test]
        public void ReduceQualityTwiceAsFastAfterExpired()
        {
            var items = new List<Item> { new Item { Name = "Normal Item", SellIn = 0, Quality = 20 } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(18, items.First().Quality);
        }

        [Test]
        public void NeverMakeQualityNegative()
        {
            var items = new List<Item> { new Item { Name = "Normal Item", SellIn = 15, Quality = 0 } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(0, items.First().Quality);

        }

        [Test]
        public void IncreaseQualityByOneForAgedBrie()
        {
            var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 15, Quality = 20 } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(21, items.First().Quality);
        }

        [Test]
        public void IncreaseQualityByTwoForExpiredAgedBrie()
        {
            var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 20 } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(22, items.First().Quality);
        }

        [Test]
        public void IncreaseQualityByTwoForBackstagePass()
        {
            var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 20 } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(22, items.First().Quality);
        }

        [Test]
        public void IncreaseQualityByThreeForBackstagePass()
        {
            var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 20 } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(23, items.First().Quality);
        }

        [Test]
        public void DropQualityToZeroForExpiredBackstagePass()
        {
            var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 20 } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(0, items.First().Quality);
        }

        [Test]
        public void KeepSulfurasQualityAndSellInDateConstant()
        {
            var items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 15, Quality = 80} };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(80, items.First().Quality);
            Assert.AreEqual(15, items.First().SellIn);
        }

        [Test]
        public void LimitQualityAtFifty()
        {
            var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 15, Quality = 50 } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(50, items.First().Quality);
        }
    }
}
