using Calculator;

namespace DataDrivenTests;
[TestFixture]
public class Tests
{
    private Calculate cal;
    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        cal = new Calculate();
    }

    [TestCase(1,2)]
    [TestCase(2,3)]
    [TestCase(5,1)]
    public void Multiply_TwoNumbers_ReturnProduct(int i, int j)
    {
        //Data Driven test runs the same test code several times, with different input (arguments) each time. Instead of copying a test to try another value, We write the test once and give the different arguments we want to be tested with to the [TestCase(arg1,arg2,arg3)] and NUnit takes care of the rest.
        Assert.That(cal.Multiply(i,j), Is.EqualTo(i * j));   
    }
    /*
     There is also another way to get the results checked by giving the expected result to the TestCase in the attribute as the third argument instead of using Assert.
     We must return the method output in this pattern  rather than declaring the method as void.
     */
    [TestCase(1,2, ExpectedResult = 2)]
    [TestCase(2,3, ExpectedResult = 6)]
    [TestCase(5,1, ExpectedResult = 5)]
    public int Multiply_TwoNumbers_ReturnProduct2(int i, int j)
    {
        return cal.Multiply(i,j);   
    }
    
    
    //Sometimes when we need to initialize complex objects as arguments or pull data from files to use as arguments or write down many test case scenarios, TestCase() might become insufficient or look unclean in code. 
    //We utilize TestCaseSource() to hand over all the cases and use them in a single line of attribute;
    //First we create an IEnumerable<TestCaseData> void with yield keyword usage
    private static IEnumerable<TestCaseData> AddSumCases()
    {
        //KEEP IN MIND that you do not necessarily have to return TestCaseData and can do normal arrays with elements corresponding to the arguments of the test cases but keep in mind that TestCaseData brings advantages like naming, etc. 
        /*
        that would look like
        private static IEnumerable<int[]> Cases()
        {
            yield return new[] { 1, 2, 3 };
            yield return new[] { 10, 20, 30 };
        } 
         */
        yield return new TestCaseData(0, 0, 0);//We yield return all the cases with the arguments so that it qualifies for IEnumerable<TestCaseData>;
        yield return new TestCaseData(3, 4, 7).SetName("3-4 Sum Case");//We can name the TCs with the SetName()
        yield return new TestCaseData(7, 6, 13).SetDescription("as well as we can add them descriptions with SetDescription()");
        yield return new TestCaseData(4, 5, 9);
        yield return new TestCaseData(3, 2, 5);
        yield return new TestCaseData(4, 75, 79);
        yield return new TestCaseData(28, 34, 62);
        yield return new TestCaseData(3, 45, 48);
        yield return new TestCaseData(0, -1, -1);
        yield return new TestCaseData(-1, -1, -2);
        yield return new TestCaseData(-1, 1, 0);
    }

    [TestCaseSource(nameof(AddSumCases))]
    public void Addition_TwoNumbers_ReturnSum(int i, int j, int sum)
    {
        Assert.That(cal.Add(i, j), Is.EqualTo(sum));
    }
    
    
    //We can also supply values from a reusable list to our test with [ValueSource(nameof(arr))]
    private static readonly int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    [Test]
    public void Divide_TwoNumbers_ReturnQuotient([ValueSource(nameof(numbers))] int i)
    {
        Assert.That(cal.Divide(i, 1), Is.EqualTo(i / 1));
    }
}