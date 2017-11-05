using csharp.DTO;
using csharp.Logic.Updater;
using NUnit.Framework;

namespace csharp.UnitTest.UpdaterShould
{
    [TestFixture]
    public class ConjuredUpdaterShould
    {
        private ConjuredUpdater _conjuredUpdaterUpdater;

        [SetUp]
        public void SetUp()
        {
            _conjuredUpdaterUpdater = new ConjuredUpdater();
        }

        [Test]
        public void DecreaseQualityByTwoBeforeExpiry()
        {
            var item = new Item {Name = "Conjured Mana Cake", SellIn = 10, Quality = 30};
            _conjuredUpdaterUpdater.Update(item);
            Assert.AreEqual(28, item.Quality);
        }

        [Test]
        public void DecreaseQualityByFourAfterExpired()
        {
            var item = new Item { Name = "Conjured Mana Cake", SellIn = 0, Quality = 30 };
            _conjuredUpdaterUpdater.Update(item);
            Assert.AreEqual(26, item.Quality);
        }
    }
}
