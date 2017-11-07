using csharp.Logic;
using csharp.Logic.Updater;
using NUnit.Framework;

namespace csharp.UnitTest
{
    [TestFixture]
    public class ReflectorShould
    {
        [Test]
        public void GetClassTypeBasedOnName()
        {
            var reflector = new Reflector();
            var actual = reflector.GetIUpdaterClassType("NormalItemUpdater");
            Assert.AreEqual(typeof(NormalItemUpdater), actual);
        }
    }
}
