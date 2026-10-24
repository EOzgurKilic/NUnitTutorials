using Calculator;
namespace DataDrivenTests;

//[TestFixture(5,3)]//We can give common arguments to each tests in a class where we use TestFixture attribute 
//Just like TestCase, TestFixture has a TestFixtureSource version too
[TestFixtureSource(nameof(fixtureData))]
public class Fixture (int i, int j) //The common arguments must be represented by corresponding parameters defined with the class constructor. This is a new syntax of the class constructor concept. It is the equivalent of the structure below.
{
    /*
    private int i;
    private int j;
    public Fixture(int i, int j)
    {
        this.i = i;
        this.j = j;
    }
    */
    
    private static object[] fixtureData = //But unlike TestCaseSource, we prepare an object array whose elements have the arguments for the TestFixtureSource
    {
        new object[] { 1, 2 },
        new object[] { 34, 23 },
        new object[] { 1, 423 },
        new object[] { 64, 2 },
        new object[] { 745, 345 }
    };
    
    private Calculate cal;
    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        cal = new Calculate();
    }
    
    [Test]
    public void Add_TwoNumbers_ReturnSum(){Assert.That(cal.Add(i,j), Is.EqualTo(i + j));}
    [Test]
    public void Subtract_TwoNumbers_ReturnSum(){Assert.That(cal.Subtract(i,j), Is.EqualTo(i - j));}
}