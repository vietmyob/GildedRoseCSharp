using csharp.DTO;
using csharp.Logic.Updater;
using NUnit.Framework;

namespace csharp.UnitTest.UpdaterShould
{
    [TestFixture]
    public class SulfurasUpdaterShould
    {
        [Test]
        public void KeepQualityAndSellInConstant()
        {
            var sulfurasUpdater = new SulfurasUpdater();
            var item = new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 15, Quality = 80};
            sulfurasUpdater.Update(item);
            Assert.AreEqual(80, item.Quality);
            Assert.AreEqual(15, item.SellIn);
        }
    }
}
