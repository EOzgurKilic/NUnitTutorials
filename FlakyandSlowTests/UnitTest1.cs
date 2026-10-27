using NUnit.Framework;
namespace FlakyandSlowTests
{
    public class Tests
    {
        //Some tests don't give the same result all the time. They call a service that sometimes times out, test something that is non-deterministic by nature, or now and then take far too long. NUnit has attributes for these tests.
        [SetUp]
        public void Setup()
        {
        }


        //To run a test that occasionally passes up to a certain number of attempts given and give it a pass if any of those attempts passes, we use [Retry(SpecifiedNumberofAttempts)]
        [Test]
        [Retry(3)]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        //In normal, only assertions cause a retry but you can list exception types as arguments to trigger a retry when exceptions are encountered.
        [Retry(3, RetryExceptions = [typeof(TimeoutException)])]
        public void Test2()
        {
            Assert.Pass(); 
        }


        //To run a test up to a specified number of times and pass it if the passing rate is over a specified rate in percent, we use [Repeat(NumberOfRunTimes, RequiredPassPercentage = specifiedRate)]
        [Test]
        [Repeat(20, RequiredPassPercentage = 90)] //Passes when at least 18 of the 20 runs pass.
        public void Test3()
        {
            Assert.Pass();
        }


        //[MaxTime(MaxTimeInMiliSecs, WarningTime = WarningTimeInMiliSecs)] fails a test that takes longer than the time you give in milliseconds and returns warnings for those that take more time than the value given in the second argument.
        [Test]
        [MaxTime(1000, WarningTime = 500)]
        public void Test4()
        {
            Assert.Pass();
        }


        //[CancelAfter(afterHowLongInMiliseconds)] stops a test that runs too long. NUnit passes a CancellationToken to the test and cancels the task with the CancellationToken
        [Test]
        [CancelAfter(1000)]
        public async Task Test5(CancellationToken token)
        {
            await Task.Delay(5000);//token will be cancelled with a Cancel() call made by [CancelAfter]
            token.ThrowIfCancellationRequested();
            Assert.Pass();
        }
    }
}
