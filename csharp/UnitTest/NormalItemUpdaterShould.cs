using csharp.DTO;
using csharp.Logic.Updater;
using NUnit.Framework;

namespace csharp.UnitTest
{
    [TestFixture]
    public class NormalItemUpdaterShould
    {
        private NormalItemUpdater _normalItemUpdater;
        [SetUp]
        public void SetUp()
        {
            _normalItemUpdater = new NormalItemUpdater();
        }

        [Test]
        public void ShouldDegradeQualityByOne()
        {
            var item = new Item() {Name = "Normal Item", SellIn = 15, Quality = 20};
            _normalItemUpdater.Update(item);
            Assert.AreEqual(19, item.Quality);
        }

        [Test]
        public void ShouldDegradeTwiceAsFastAfterExpired()
        {
            var item = new Item() {Name = "Normal Item", SellIn = 0, Quality = 20};
            _normalItemUpdater.Update(item);
            Assert.AreEqual(18, item.Quality);
        }
    }
}
