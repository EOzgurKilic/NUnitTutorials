using Calculator;
namespace AutomatingTests;

public class Tests
{
    private Calculate calculator;
    [OneTimeSetUp]
    public void Setup()
    {
        calculator = new();
    }

    [Test]
    //We use [Values(Param arg1, ...)] to give argument candidates to a parameter of a test method and NUnit tests all combinations that can be possibly formed with the other parameters' arguments automatically.
    //Like in the example below, there are 3 possible values i can take and 2 j can take, which means 3 x 2 = 6 different argument set combinations and accordingly test cases can be formed. NUnit does that for us in the bg automatically.
    public void Add_TwoNumbers_ReturnProduct([Values(1,2,3)]int i, [Values(4,5)]int j) //For bool and enum values, you can leave out the values and just type [Values] before the parameters
    {
        Assert.That(calculator.Add(i, j), Is.EqualTo(i+j));
    }


    [Test]
    //We use [Range(lowerBound, upperBound)] to have a range of argument set of a parameter tested
    //You can also add a third parameter to it which will represent how much the argument will increase within the range in each step 
    public void Subtract_TwoNumbers_ReturnDifference([Range(1, 11,5)]int i, [Range(-10, -1,1)] int j)
    {
        Assert.That(calculator.Subtract(i, j), Is.EqualTo(i - j));
    }
    
    
    [Test]
    //We use [Random(lowerBound, upperBound, amountOfRandomArgsInRange)] to test a certain amount of random numbers select within the specified range for a parameter
    public void Multiply_TwoNumbers_ReturnProduct([Random(0, 10,5)]int i, [Random(-10, -1,1)] int j)
    {
        Assert.That(calculator.Multiply(i, j), Is.EqualTo(i * j));
    }
    
    
    //[Pairwise]
    //This attribute generates just enough cases so that every pair of values is tested together at least once rather than testing all the combinations. Most bugs are caused by one value or by two values together and this way, we find most of them with far fewer tests.
    [Test, Pairwise]
    public void DivideAndAdd_ThreeNumbers_ReturnQuotientSum([Values(60, 20, 40)]int i, [Values(1,2,4)] int j, [Values(10,12,14)] int k)
    {
        Assert.That(calculator.Divide(i, j) + k, Is.EqualTo(i / j + k));
    }
    
}