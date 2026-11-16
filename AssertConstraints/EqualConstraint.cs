namespace AssertConstraints
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        //Comparing Numerics
        [Test]
        public void NumericComparison()
        {
            Assert.That(2 + 2, Is.EqualTo(4));
            Assert.That(3 + 3, Is.Not.EqualTo(6));
            Assert.That(3.5 + 3.6, Is.EqualTo(7.1));
        }

        //Textual Comparison
        [Test]
        public void TextualComparison()
        {
            Assert.That("hi", Is.EqualTo("hi"));
            Assert.That("hi", Is.EqualTo("HI").IgnoreCase); //IgnoreCase ignores key sensitivity.
            Assert.That("h i", Is.EqualTo(" H I ").IgnoreWhiteSpace); //Ignores white space in both arguments.
        }

        //DateTimes and TimeSpans Comparison
        [Test]
        public void TimeComparison()
        {
            DateTime now = DateTime.Now;
            TimeSpan anHour = TimeSpan.FromHours(1.0);
            Assert.That(now, Is.EqualTo(now));
            Assert.That(now + anHour, Is.EqualTo(now).Within(TimeSpan.FromHours(3.0)));
            Assert.That(now + anHour, Is.EqualTo(now).Within(3).Hours); //On these, a numeric tolerance must be followed by a unit 
        }
        
        //Comparing Arrays, Collections, and IEnumerables with AsCollection
        //Two arrays, Collections or IEnumerables are considered equal if they have the same amount of dimensions and all the corresponding elements in each dimensions are the same.
        //The array shape (dimensions, etc.) is counted as part of the normal behavior of NUnit but if you want to compare two arrays sequentially without considering their shapes, you can utilize the AsCollection modifier. 
        [Test]
        public void CollectionComparison()
        {
            int[] array1 = { 1, 2, 3 };
            int[] array2 = { 1, 2, 3 }; //Array 1 and 2 are equal as their elements are the same and they are one-dimensional arrays.

            Assert.That(array1, Is.EqualTo(array2)); 
            int[,] array3 = { { 1, 2 }, { 3, 4 } };
            int[] array4 = { 1, 2, 3, 4 }; //In normal, NUnit would assume these two arrays as different and fail the assert above if the same was checked. However, with the AsCollection modifier, NUnit will compare them sequentially and ignore their shapes, passing the assert.
            Assert.That(array3, Is.EqualTo(array4).AsCollection);

            //You need to remember that AsCollection wouldn't work the same way for jagged arrays as it applies to individual arrays of the jagged array and not the jagged array as a whole, which causes each corresponding array pair to be compared individually without mixing the remaining arrays of the jagged array in a sequential manner.


            //In normal, NUnit follows everything's IEquatable specific implementations without any modifications in EqualTo comparisons. However, when AsCollection is used, the IEquatable specific implementations are ignored and the comparison is done sequentially.
        }

        //Comparing Dictionaries
        [Test]
        public void ComparingDictionaries() {
            //If the list of keys (regardless of order) and the values associated with those keys are the same, dictionaries are considered equal.
        }

        //Comparing Classes/Structures
        [Test]
        public void ComparingClassesAndStructures() {
            //EqualsTo compares classes based on IEquatable implementations and if not implemented, it compares the references as default behavior of Equals method.

            //If we have two instances in the same type to compare without the IEquatable implementation we have two options to perform specific comparison on them;
            //1. Specify a specific comparer (like IComparer, IEqualityComparer, etc.)
            //2. Use the .UsingPropertiesComparer() modifier to tell NUnit to compare the properties of the instances (check below);
            //Assert.That(inst1, Is.EqualTo(inst2).UsingPropertiesComparer());
        }
        
    }
}
