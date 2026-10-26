using Calculator;

namespace PreparingAndCleaningUpTests
{
    [SetUpFixture]
    public class SetUpFixture
    {
        //the OneTimeSetUp and OneTimeTearDown methods of a class marked with [TestFixtureSetup] affect all the classes' tests that are declared under the same namespace
        //Which means that whatever is created within that class will be available in other classe by getting called over the class's name.
        //Though, SetUp and TearDown is not applicable with this and the class must be public with a default constructor or static.
        //[SetUpFixture] can be inherited and the derived class's namespace decides what it covers.
        
        public static Calculate cal;

        [OneTimeSetUp]
        public void Setup()
        {
            Console.WriteLine("SetUp Process");
            cal = new();
        }
        [OneTimeTearDown]
        public void Teardown() { Console.WriteLine("TearDown Process"); }
    }
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [TearDown]
        //TearDown method is executed even SetUp method fails which means that you should be checking if the resources (objects, etc.) were created in the SetUp method before attempting to release them.
        public void Teardown() { }

        [Test]
        public void Test1()
        {
            Assert.That(SetUpFixture.cal.Add(1, 1), Is.EqualTo(2)); //cal object is initialized in the SetUpFixture actually
        }
    }


    //Async setup - SetUp and TearDown methods can be declared the way they return async tasks and NUnit waits for them to finish although they do not run with await keyword.

    /*Constructors and IDisposable: by default, NUnit creates one instance of the test class for all its tests, so the constructor runs once, like [OneTimeSetUp]. If the class implements IDisposable, NUnit calls Dispose when it is done with the instance. [SetUp] and [TearDown] make the intent clearer, and work the same way with every life cycle.*/

    /*A new instance for each test: with [FixtureLifeCycle(LifeCycle.InstancePerTestCase)], NUnit creates a new instance of the test class for every test. Fields can then never leak between tests, which also helps when tests run in parallel. [OneTimeSetUp] and [OneTimeTearDown] must be static in that case.*/

    /*[TestCaseSource], [ValueSource] and [TestFixtureSource] members are evaluated when NUnit loads the assembly, before [OneTimeSetUp], [SetUpFixture] or [SetUp] methods run. Changing the data in a setup method has no effect, and a source cannot use objects created there.*/
}