namespace OrganizingandSelectingTests
{
    [Category("SparedTests")] //We use [Category(name)] to categorize tests and test fixtures.
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
        [Test]
        public void Test2()
        {
            Assert.Pass();
        }
        [Test]
        [Category("IfNeeded")]
        public void Test3()
        {
            //Tests specifically added to a category is also apparent in the category assigned to the fixture where it is located.
            //Which means that this test is both in IfNeeded and SparedTests categories.
            //In Dotnet CLI, it is possible to execute or exclude tests in certain categories.
            //dotnet test --filter "TestCategory = IfNeeded" would only execute Test3 whereas dotnet test --filter "TestCategory!=IfNeeded" would exclude it from the execution.
            Assert.Pass();
        }
        [Test]
        //We mark tests with [Explicit(WhyExplicit?)] that we want to be skipped in normal runs. We can only run this test when we select it ourselves.
        [Explicit("Builds the DB, run it on demand")]
        public void ExplicitTest()
        {
            Assert.Pass();
        }

        [Test]
        //We use [Ignore(WhyIgnored?, Until = date)] to have a Test not executed until a specific date.
        [Ignore("Arbitrarily Ignored", Until = "2099-12-31")]
        public void IgnoredTest()
        {
            Assert.Pass();
        }
    }
}
