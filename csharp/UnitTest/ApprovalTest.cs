using ApprovalTests.Reporters;
using NUnit.Framework;
using System;
using System.IO;
using System.Text;
using ApprovalTests;

namespace csharp.UnitTest
{
    [TestFixture]
    [UseReporter(typeof(DiffReporter))]
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
            Approvals.Verify(output);
        }
    }
}
