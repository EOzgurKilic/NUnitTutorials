using Calculator;
namespace NUnitTutorials;

public class Tests
{
    Calculate calculator2;
    [SetUp]//Marking a method with this attribute tells it is a Setup method.
    //Setup methods are run before each test method so all test methods get fresh instances and so on.
    public void Setup()
    {
        calculator2 = new Calculate();//We carried the common object (source) here to the Setup method so that we don't have to create it in each test.
    }

    [TearDown]
    public void TearDown()
    {
        // Runs after each test method (just like Setup is run before each).
        // Use this method to release resources created during testing,
        // such as closing browser sessions, database connections, or file streams.
        // Exp: (IWebDriver class instance) driver.Quit();
    }

    [OneTimeSetUp]//This does the same job as SetUp attribute but with a nuance;
    //When there is costly setup and we do not need fresh objects for each test method, we put our common objects & etc. inside this method and it only creates them once for the whole class.
    public void OneTimeSetup()
    {
        
    }
    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        // One time version of the TearDown pretty much.
    }

    //Based on the Test Method Naming Convention, The name prototype of the test methods should be:
    //MethodName_Scenario_ExpectedBehavior

    [Test]//Marking a method with this attribute tells it is a test method.
    public void Add_TwoNumbers_ReturnsSum()
    {
        //Arrange - creates the object you want to test, often called the system under test.
        var calculator1 = new Calculate();
        
        //Act - Calls the method you want to test
        var result = calculator1.Add(1, 1);
        
        //Assert - Checks that the result you ended up with is what you expected. Assert.That takes the actual value and a constraint that describes the expected value, such as Is.EqualTo(2);
        Assert.That(result, Is.EqualTo(2));
    }
    [Test]
    public void Divide_TwoNumbers_ReturnsQuotient()
    {
        //Arrange
        //var calculator2 = new Calculate(); Instead of creating a new instance in each test, we can create a common Calculate object in the Setup method.

        //Act and Assert together
        Assert.That(calculator2.Divide(10, 2), Is.EqualTo(5));
    }
    [Test]
    public void Multiply_TwoNumbers_ReturnsProduct()
    {
        //Act and Assert together
        Assert.That(calculator2.Multiply(1, 1), Is.EqualTo(5));
    }
    [Test]
    public void Subtract_TwoNumbers_ReturnsDifference()
    {
        //Act and Assert together
        Assert.That(calculator2.Subtract(1, 1), Is.EqualTo(0));
    }
}