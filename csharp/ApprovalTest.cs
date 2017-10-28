using ApprovalTests.Reporters;
using NUnit.Framework;
using System;
using System.IO;
using System.Text;

namespace csharp
{
    [TestFixture]
    [UseReporter(typeof(NUnitReporter))]
    public class ApprovalTest
    {
        [Test]
        public void ThirtyDays()
        {
            var fakeoutput = new StringBuilder();
            Console.SetOut(new StringWriter(fakeoutput));
            Console.SetIn(new StringReader("a\n"));

            Program.Main(new string[]{});
            var output = fakeoutput.ToString();
            var currentProjPath = AppDomain.CurrentDomain.BaseDirectory;
            var expected = File.ReadAllText(Path.Combine(currentProjPath, "ApprovalTest.ThirtyDays.received.txt"));
            Assert.AreEqual(expected, output);
        }
    }
}
