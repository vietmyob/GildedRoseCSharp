using csharp.DTO;
using csharp.Logic.Updater;
using NUnit.Framework;

namespace csharp.UnitTest
{
    [TestFixture]
    public class AgedBrieUpdaterShould
    {
        private AgedBrieUpdater _agedBrieUpdater;

        [SetUp]
        public void SetUp()
        {
            _agedBrieUpdater = new AgedBrieUpdater();
        }

        [Test]
        public void IncreaseQualityByOne()
        {
            var item = new Item { Name = "Aged Brie", SellIn = 15, Quality = 20 };
            _agedBrieUpdater.Update(item);
            Assert.AreEqual(21, item.Quality);
        }

        [Test]
        public void IncreaseQualityByTwoAfterExpired()
        {
            var item = new Item { Name = "Aged Brie", SellIn = 0, Quality = 20 };
            _agedBrieUpdater.Update(item);
            Assert.AreEqual(22, item.Quality);
        }
    }
}
