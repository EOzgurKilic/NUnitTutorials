namespace Assertion
{
    public class Tests
    {
        //Assertion Models

        //Constraint Model (Assert.That())
        //Special Asserts
        //Multiple Asserts


        //It usually is the best the best practice to use a single assert per test, but there are some cases where multiple asserts are needed. Keep in mind that if one assert fails, the rest of the asserts will not be executed and the test will be marked as failed.


        //Constraint Model (Assert.That()) - Check ConstraintAsserts Project
        //Generally the Constraint Model is preferred nowadays, which is Assert.That() with a constraint (takes Constraint arguments). (They are in essence the modern version of the Classic Assertion methods)


        //Special Asserts - Check SpecialAsserts Project
        //The special assertions do not check any condition. They are used for special purposes, like unconditional failure or success, ignoring a test, etc.


        //Multiple Asserts - Check MultipleAsserts Project
        //Usually we prefer a test to fail once a single assert fails, but there are some particular cases where we need the test to continue executing even if an assert fails. In those cases, we can use the Multiple Asserts feature, which allows us to group multiple asserts together and report all failures at once.
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}
