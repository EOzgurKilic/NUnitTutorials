using Calculator;
namespace Assumptions_Warnings
{
    public class Tests
    {
        Calculate cal;
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            cal = new();
        }

        //Assumptions
        //It checks whether a condition is met and if not, it skips the test and marks it as inconclusive instead of failing it like assert.
        [TestCase(5)]
        [TestCase(0)]
        [TestCase(-1)]
        public void AssumptionTest(int divider)
        {
            Assume.That(divider, Is.Not.EqualTo(0), "Divider cannot be zero");

            Assert.That(cal.Divide(10, divider), Is.EqualTo(10/divider));
        }

        //Warnings
        //A class basically used to give warnings in certain cases if a condition is met without failing the test.
        [Test]
        public void WarningTest()
        {
            //If forms
            Warn.If(2 + 2 == 4);
            Warn.If(() => 2 + 2 == 4);
            Warn.If(2 + 2, Is.Not.EqualTo(5));
            Warn.If(() => 2 + 2, Is.Not.EqualTo(5).After(500));

            Warn.Unless(2 + 2 == 4);
            Warn.Unless(() => 2 + 2 == 4);
            Warn.Unless(2 + 2, Is.EqualTo(5));
            Warn.Unless(() => 2 + 2, Is.EqualTo(5).After(500));

            Assert.Warn("be warned about the opertaion");
            Assert.Pass();
        }
    }
}
