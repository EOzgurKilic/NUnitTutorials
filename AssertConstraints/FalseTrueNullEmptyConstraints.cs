namespace AssertConstraints
{
    public class OtherTests
    {
        [SetUp]
        public void Setup()
        {
        }

        //True Constraint
        //tests if a value is true
        [Test]
        public void IfTrueTest()
        {
            Assert.That(1 + 1 == 2, Is.True);
            Assert.That(1 + 1 == 3, Is.Not.True);
        }

        //False Constraint
        //tests if a value is False
        [Test]
        public void IfFalseTest()
        {
            Assert.That(1 + 1 == 3, Is.False);
            Assert.That(1 + 1 == 2, Is.Not.False);
        }

        //Null & Default Constraint
        //tests if a value is null
        [Test]
        public void IfNullTest()
        {
            Assert.That("", Is.Null);
            Assert.That("", Is.Not.Null);
            //Consider using Is.Default for value types instead of Is.Null.
            Assert.That(0, Is.Default);
        }

    }
}
