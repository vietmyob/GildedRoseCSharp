using csharp.DTO;
using csharp.Logic.Updater;
using NUnit.Framework;

namespace csharp.UnitTest
{
    [TestFixture]
    public class BackstagePassUpdaterShould
    {
        private BackstagePassUpdater _backstagePassUpdater;

        [SetUp]
        public void SetUp()
        {
            _backstagePassUpdater = new BackstagePassUpdater();
        }

        [Test]
        public void IncreaseQualityByOneIfMoreThan10SellInDays()
        {
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 };
            _backstagePassUpdater.Update(item);
            Assert.AreEqual(21, item.Quality);
        }

        [Test]
        public void IncreaseQualityByTwoIfFewerThan11SellInDays()
        {
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 20 };
            _backstagePassUpdater.Update(item);
            Assert.AreEqual(22, item.Quality);
        }

        [Test]
        public void IncreaseQualityByThreeIfFewerThan6SellInDays()
        {
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 20 };
            _backstagePassUpdater.Update(item);
            Assert.AreEqual(23, item.Quality);
        }

        [Test]
        public void DropQualityToZeroIfExpired()
        {
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 20 };
            _backstagePassUpdater.Update(item);
            Assert.AreEqual(0, item.Quality);
        }
    }
}
