using Calculator;
namespace NUnitTutorials;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        //Arrange - creates the object you want to test, often called the system under test.
        var calculator = new Calculate();
        
        //Act - Calls the method you want to test
        var result = calculator.Add(1, 1);
        
        //Assert - Checks that the result you ended up with is what you expected. Assert.That takes the actual value and a constraint that describes the expected value, such as Is.EqualTo(2);
        Assert.That(result, Is.EqualTo(2));
    }
}