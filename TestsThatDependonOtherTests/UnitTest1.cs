namespace TestsThatDependonOtherTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        
        //Most tests should be designed to work independantly but occasionally, we might need to give some tests dependancy on other tests to run.
        //We utilize [DependsOnTest(nameof(NameOfTestMethod))] and [DependsOnFixture] to form these dependancies.
        //REMEMBER that nameof() keyword brings and updates the name of the argument given so if the method name changes, you won't need to update the argument's name manually either. (while renaming, hover the method name and control+r to change the name and observe it at the points used in nameof())
        //If the test another one depends on fails, the dependant test does not run but if you give a second argument to the DepensOnTest attribute which is AllowFailure = true, the test would still run even though the test it depends on fails.
        [Test]
        public void Test1()
        {
            Assert.Pass();
        }


        [Test]
        [DependsOnTest(nameof(Test1))]
        public void Test2()
        {
            Assert.Fail();
        }

        [Test]
        [DependsOnTest(nameof(Test2), AllowFailure = true)]
        public void Test3()
        {
            Assert.Pass();
        }
    }

    //We can also use [DependsOnFixture(nameof(ClassName))] when all the tests of a class should wait for another class's tests to be executed.
    [DependsOnFixture(typeof(Tests), AllowFailure = true)] //But we use typeof() this time as classes are considered types.
    public class DependantTS
    {
        [Test]
        public void DependantClassTets() { }
    }
}
