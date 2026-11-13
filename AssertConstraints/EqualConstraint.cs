namespace AssertConstraints
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        //Comparing Numerics
        [Test]
        public void Test1()
        {
            Assert.That(2 + 2, Is.EqualTo(4));
            Assert.That(3 + 3, Is.Not.EqualTo(6));
            Assert.That(3.5 + 3.6, Is.EqualTo(7.1));
        }

        //Textual Comparison
        [Test]
        public void Test2()
        {
            Assert.That("hi", Is.EqualTo("hi"));
            Assert.That("hi", Is.EqualTo("HI").IgnoreCase); //IgnoreCase ignores key sensitivity.
            Assert.That("h i", Is.EqualTo(" H I ").IgnoreWhiteSpace); //Ignores white space in both arguments.
        }

        //DateTimes and TimeSpans Comparison
        [Test]
        public void Test3()
        {
            DateTime now = DateTime.Now;
            TimeSpan anHour = TimeSpan.FromHours(1);
            Assert.That(now)
        }
    }
}
