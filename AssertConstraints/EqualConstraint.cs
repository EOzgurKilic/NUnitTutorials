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
        public void NumericComparison()
        {
            Assert.That(2 + 2, Is.EqualTo(4));
            Assert.That(3 + 3, Is.Not.EqualTo(6));
            Assert.That(3.5 + 3.6, Is.EqualTo(7.1));
        }

        //Textual Comparison
        [Test]
        public void TextualComparison()
        {
            Assert.That("hi", Is.EqualTo("hi"));
            Assert.That("hi", Is.EqualTo("HI").IgnoreCase); //IgnoreCase ignores key sensitivity.
            Assert.That("h i", Is.EqualTo(" H I ").IgnoreWhiteSpace); //Ignores white space in both arguments.
        }

        //DateTimes and TimeSpans Comparison
        [Test]
        public void TimeComparison()
        {
            DateTime now = DateTime.Now;
            TimeSpan anHour = TimeSpan.FromHours(1.0);
            Assert.That(now, Is.EqualTo(now));
            Assert.That(now + anHour, Is.EqualTo(now).Within(TimeSpan.FromHours(3.0)));
            Assert.That(now + anHour, Is.EqualTo(now).Within(3).Hours); //On these, a numeric tolerance must be followed by a unit 
        }
        
        //Comparing Arrays, Collections, and IEnumerables with AsCollection
        [Test]
        public void CollectionComparison()
        {
            
        }
    }
}
