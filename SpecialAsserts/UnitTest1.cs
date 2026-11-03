namespace SpecialAsserts
{
    public class Tests
    {
        //Special Asserts are generally for enabling you to take an immediate ending action on a test. They are generally used for situations where the test cannot continue or is not valid if a certain condition is met.

        //Special Assert List:
        //Assert.Pass - Ends a test by passing it.
        //Assert.Fail - Ends a test by failing it.
        //Assert.Ignore
        //Assert.Inconclusive
        [SetUp]
        public void Setup()
        {
        }

        //Assert.Pass() 
        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        //Assert.Fail(string message)
        [Test]
        public void Test2()
        {
            Assert.Fail("Test failed.");
        }

        //Assert.Ignore(string message)
        //It ends the test immediately and marks it as ignored. It is used when a test cannot be run for some reason, such as a missing dependency or an unsupported platform.
        //Use it when a test discovers at run time that it cannot meaningfully run in the current environment, for example because a database, service or license is not available. The difference between Assert.Ignore and Ignore Attribute lies exactly in the timing of the decision to ignore the test. If we already know that a test cannot run, we should use the Ignore Attribute. If we only discover that a test cannot run at run time, we should use Assert.Ignore.
        [Test]
        public void ExpDBDataTest()
        {
            var connectionString = Environment.GetEnvironmentVariable("REPORTING_DB");
            if(string.IsNullOrEmpty(connectionString))
            {
                Assert.Ignore("Database connection string is not set. Test ignored.");
            }//Nothing below this line is executed if the text is ignored.
            Assert.Pass();

            //The way Assert.Ignore works is that it throws an exception that is caught by the NUnit, and taking it inside a try catch block will result in the test not being ignored and interrupted as IgnoreException gets swallowed.
            //Though if you must utilize try catch block for a specific reason, then do not forget to exclude IgnoreException.
            //Moreover, remember that you cannot use Assert.Ignore inside a Assert.EnterMultipleScope() block.


            //Where you can call it
            //In a test method
            //In a [SetUp] method - would affect all the tests in the same fixture but the ignore is test-level although all the tests in the fixture would be ignored.
            //In a [OneTimeSetup] method - whereas the whole fixture would be ignored, not all the tests in it individually.
            //In a [SetUpFixture] class - Every single test fixture in the namespace would be ignored.
            //Ignoring from [OneTimeSetUp] is the usual way to skip a whole group of tests that share one unavailable dependency
        }

        //For Data-Driven tests, you can ignore the cases in the IEnumerable TestCaseSource method;

        [Test]
        [TestCaseSource(nameof(TCSource)]
        public void SourceTest(int val1, int val2)
        {

        }

        private static IEnumerable<TestCaseData> TCSource()
        {
            yield return new TestCaseData(2, 1);
            yield return new TestCaseData(3,2); 
            yield return new TestCaseData(4, 3).Ignore("This test case is ignored."); //You can ignore a specific test case this way instead of ignoring the whole test method.
            yield return new TestCaseData(5, 6).Ignore("Ignored 'til june").Until(new DateTimeOffset(2026, 6, 1, 0, 0, 0, TimeSpan.Zero));//We can set a specific date (by giving a DataTimeOffset argument to the associated method) the test won't run until just like how it works in [Ignore] attribute.
        }



        //Use Cases 

        // "This test should run, but can't here. Someone should know."
        // Use: Assert.Ignore() or [Ignore]
        // NUnit result: Skipped:Ignored

        // "This test is under development and can't run yet."
        // Use: [Ignore] on the test or fixture
        // NUnit result: Skipped:Ignored

        // "The test ran but couldn't reach a verdict. Another run might."
        // Use: Assert.Inconclusive() or Assume.That()
        // NUnit result: Inconclusive

        // "This test is not meant to run in this environment or selection."
        // Use: [Platform], [Explicit], [Category] with a filter
        // NUnit result: Skipped

        // "Keep going, but flag this."
        // Use: Warn or Assert.Warn()
        // NUnit result: Warning


        //How the VS Test Adapter and dotnet test show these results
        // NUnit result: Skipped:Ignored (Assert.Ignore(), [Ignore])
        // Test Explorer outcome: Skipped, with the reason as the error message

        // NUnit result: Skipped (filtered, [Platform], [Explicit])
        // Test Explorer outcome: None (Not Run)

        // NUnit result: Inconclusive
        // Test Explorer outcome: None (Not Run)

        // NUnit result: Warning
        // Test Explorer outcome: Skipped by default; configurable with MapWarningTo


        //Assert.Inconclusive(string message)
        //Indicates that the test could not be completed with the data available.
        //It should be used in situations where another run with different data might run to completion, with either a success or failure outcome.
        // ends the test immediately by throwing an InconclusiveException, so nothing after the call runs. Like Assert.Ignore, it may not be used inside a multiple assert block.
        [Test]
        public void Test4()
        {

        }
    }
}
