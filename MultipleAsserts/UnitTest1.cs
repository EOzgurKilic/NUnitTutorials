using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using static System.Reflection.Metadata.BlobBuilder;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MultipleAsserts
{
    public class Tests
    {
        Calculator.Calculate cal;
        [OneTimeSetUp]
        public void Setup()
        {
            cal = new();
        }
        //This is particularly useful for testing things like object initialization and UI appearance as well as certain kinds of integration testing.
        //Multiple asserts are implemented with the Assert.EnterMultipleScope() method.
        [Test]
        public void Test1()
        {
           using (Assert.EnterMultipleScope())
            //The multiple assert block may contain any arbitrary code, not just asserts.
            //Multiple assert blocks may be nested. Failure is not reported until the outermost block exits.
            /*The test will be terminated immediately if any exception is thrown that is not handled.An unexpected exception is often an indication that the test itself is in error, so it must be terminated.If the exception occurs after one or more assertion failures have been recorded, those failures will be reported along with the terminating exception itself.*/
            /*An error is reported if any of the following are used inside a multiple assert block:

            Assert.Pass
            Assert.Ignore
            Assert.Inconclusive
            Assume.That

            Notice that you still can utilize from the special assert type Assert.Fail. The message and stack trace are recorded but the test continues to execute until the end of the block.
             */
            {
                Assert.That(cal.Add(5, 6), Is.EqualTo(10));
                Assert.That(cal.Subtract(6, 5), Is.EqualTo(2));
            }
        }
    }
}
