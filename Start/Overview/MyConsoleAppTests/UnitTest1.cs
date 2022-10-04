using MyConsoleApp;
using System;
namespace Solution
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void SampleTests_TestInteger_DisablePascalCase()
        {
            //arranje
            int _test;
            string _resultExpected = string.Empty;
            string _result = string.Empty;
            // act
            _resultExpected = "1";
            _test = 1;
            _result = Kata.ToUnderscore(_test);
            // assert
            Assert.That(_resultExpected.Equals(_result));
        }
        [Test]
        [TestCase("test_controller", "TestController")]
        [TestCase("this_is_beautiful_day", "ThisIsBeautifulDay")]
        [TestCase("am7_days", "Am7Days")]
        [TestCase("my3_code_is4_times_better", "My3CodeIs4TimesBetter")]
        [TestCase("arbitrarily_sending_different_types_to_functions_makes_katas_cool", "ArbitrarilySendingDifferentTypesToFunctionsMakesKatasCool")]
        public void SampleTests_TestString_DisablePascalCase(string test, string result)
        {
            Assert.AreEqual(test, Kata.ToUnderscore(result));
        }
    }
    [TestFixture, Description("Fixed tests")]
    public class FixedTests
    {
        private void Test(Dictionary<string, int> expected, Dictionary<string, int> actual)
        {
            var expectedStr = "{ " +
                              string.Join(", ", expected.Select(kv => $"{kv.Key}: {kv.Value}"))
                              + " }";
            var actualStr = "{ " +
                            string.Join(", ", actual.Select(kv => $"{kv.Key}: {kv.Value}"))
                            + " }";

            Assert.AreEqual(expected, actual, $"Expected: {expectedStr}, Actual: {actualStr}");
        }

        [Test, Description("Should work for some example programs")]
        public void ExamplePrograms()
        {
            // Test(new Dictionary<string, int> {{"a", 1}}, SimpleAssembler.Interpret(new[] {"mov a 5", "inc a", "dec a", "dec a", "jnz a -1", "inc a"}));
            Test(new Dictionary<string, int> { { "a", 0 }, { "b", -20 } },
                SimpleAssembler.Interpret(new[] { "mov a -10", "mov b a", "inc a", "dec b", "jnz a -2" }));
        }
    }

    [TestFixture]
    public class SolutionTest
    {
        [Test]
        public void TestToRoman_001()
        {
            int input = 1;
            string expected = "I";

            string actual = RomanNumerals.ToRoman(input);

            Assert.AreEqual(expected, actual);

            //todo | kafka | redis | grpc | 
            //http://localhost:3000/weatherforecast
            //http://20.31.91.62/WeatherForecast
        }

        [Test]
        public void TestToRoman_002()
        {
            int input = 2;
            string expected = "II";

            string actual = RomanNumerals.ToRoman(input);

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void TestToRoman_003()
        {
            int input = 2008;
            string expected = "MMVIII";

            string actual = RomanNumerals.ToRoman(input);

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void TestFromRoman_001()
        {
            string input = "I";
            int expected = 1;

            int actual = RomanNumerals.FromRoman(input);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestFromRoman_002()
        {
            string input = "II";
            int expected = 2;

            int actual = RomanNumerals.FromRoman(input);

            Assert.AreEqual(expected, actual);
        }
    }
}

namespace MyConsoleAppTests
{
    [TestFixture]
    public class BinarySearchTest
    { [Test]
        [TestCase("?","1")]
        public void ScanChar_Return(string expectedResult,string input)
        {
            Assert.Equals(expectedResult
            , Answer.ScanChar(input));
        }
        [Test]
        [TestCase(2, new int[] { 0, 1, 2, 3, 4 }, 0, 5, 2)]
        public void BinarySearchTest_SearchForMiddleElement_ReturnElementIndex(int expectedResult, int[] array, int minPostionArray, int maxPostitionArray, int middleElement)
        {
            Assert.AreEqual(expectedResult
            , BinarySearch.BinarySearchOnArray(array, minPostionArray, maxPostitionArray, middleElement));
        }
    }
    [TestFixture]
    public class SolutionTest
    {
        private readonly IList<int> collection = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24 };
        private PagnationHelper<int> helper;

        [SetUp]
        public void SetUp()
        {
            helper = new PagnationHelper<int>(collection, 10);
        }

        [Test]
        [TestCase(-1, ExpectedResult = -1)]
        [TestCase(1, ExpectedResult = 10)]
        [TestCase(3, ExpectedResult = -1)]
        public int PageItemCountTest(int pageIndex)
        {
            return helper.PageItemCount(pageIndex);
        }

        [Test]
        [TestCase(-1, ExpectedResult = -1)]
        [TestCase(12, ExpectedResult = 1)]
        [TestCase(24, ExpectedResult = -1)]
        public int PageIndexTest(int itemIndex)
        {
            return helper.PageIndex(itemIndex);
        }

        [Test]
        public void ItemCountTest()
        {
            Assert.AreEqual(24, helper.ItemCount);
        }

        [Test]
        public void PageCountTest()
        {
            Assert.AreEqual(3, helper.PageCount);
        }
    }
    [TestFixture]
    public class KataTests
    {
    [Test]
    // [TestCase(new int[] {1, 2, 1, 1, 3, 1, 0, 0, 0, 0},new int[] {1, 2, 0, 1, 0, 1, 0, 3, 0, 1})]
    public void MoveZeroes_MovexerostoTheEndArray_ResturnArray(
        // int[] expectedResult, int[] result
        )
    {
    //   Assert.AreEqual(expectedResult, Kata.MoveZeroes(result));
      Assert.AreEqual(new int[] {1, 2, 1, 1, 3, 1, 0, 0, 0, 0}, Kata.MoveZeroes(new int[] {1, 2, 0, 1, 0, 1, 0, 3, 0, 1}));
    }
        [Test]
        [TestCase("1", 1)]
        [TestCase("120", 5)]
        [TestCase("362880", 9)]
        [TestCase("1307674368000", 15)]
        public void Factorial_CalculateFactorial_ReturnStringWithFactoialSum(string expected, int n)
        {
            Assert.AreEqual(expected, Kata.Factorial(n));
        }
    }
    [TestFixture]
    public class SystemTests
    {
        [Test]
        public void Rot13_EncriptMessageInput_Encryptionsuccessfull()
        {
            Assert.AreEqual("ROT13 example.", Kata.Rot13("EBG13 rknzcyr."));
        }
    }
    [TestFixture]
    public static class JosephusSurvivorTests
    {

        private static void testing(int actual, int expected)
        {
            Assert.AreEqual(expected, actual);
        }
        [Test]
        [TestCase(7, 3, 4)]
        // [TestCase(11,19,10)]
        // [TestCase(40,3,28)]
        // [TestCase(14,2,13)]
        // [TestCase(100,1,100)]
        // [TestCase(1,300,1)]
        // [TestCase(2,300,1)]
        // [TestCase(5,300,1)]
        // [TestCase(7,300,7)]
        // [TestCase(300,300,265)]
        public static void test1(int n, int offset, int survivor)
        {        //test project creation:
                 // dotnet new console -o $PROJECT_NAME  # PROJECT_NAME is a directory name
                 // dotnet add package Microsoft.NET.Test.Sdk
                 // dotnet add package Nunit3TestAdapter
                 //  dotnet add package NUnit
            Console.WriteLine("Basic Tests JosSurvivor");
            testing(JosephusSurvivor.JosSurvivor(n, offset), survivor);
        }
    }
    [TestFixture]
    public static class ScrambliesTests
    {
        private static void testing(bool actual, bool expected)
        {
            Assert.AreEqual(expected, actual);
        }
        [Test]
        [TestCase("rkqodlw", "world", true)]
        [TestCase("cedewaraaossoqqyt", "codewars", true)]
        [TestCase("katas", "steak", false)]
        [TestCase("scriptjavx", "javascript", false)]
        [TestCase("scriptingjava", "javascript", true)]
        [TestCase("scriptsjava", "javascripts", true)]
        [TestCase("javscripts", "javascript", false)]
        [TestCase("aabbcamaomsccdd", "commas", true)]
        [TestCase("commas", "commas", true)]
        [TestCase("sammoc", "commas", true)]
        public static void Scramble_ValidateAllTestCases_PassAllTests(string str1, string str2, bool expectedResult)
        {
            testing(Scramblies.Scramble(str1, str2), expectedResult);
        }
    }
    [TestFixture]
    public class StripCommentsTest
    {
        //multivision | area telecomunicações | possio software de avarias na rede 
        [Test]
        public void StripComments()
        {
            Assert.AreEqual(
                    "apples, pears\ngrapes\nbananas",
                    StripCommentsSolution.StripComments("apples, pears # and bananas\ngrapes\nbananas !apples", new string[] { "#", "!" }));

            Assert.AreEqual("a\nc\nd", StripCommentsSolution.StripComments("a #b\nc\nd $e f g", new string[] { "#", "$" }));

        }
    }
    public class SnailTest
    {
        [Test]
        public void SnailTest_4x4Matrix()
        {
            int[][] array =
           {
           new []{1, 2, 3,10},
           new []{4, 5, 6,11},
           new []{7, 8, 9,12},
           new []{13, 14, 15,16}
       };
            var r = new[] { 1, 2, 3, 10, 11, 12, 16, 15, 14, 13, 7, 4, 5, 6, 9, 8 };
            Test(array, r);
        }
        [Test]
        public void BubbleSortRecursive_SortArray_Success()
        {
            //arrange
            var r = new[] { 1, 2, 3, 6, 9, 8, 7, 4, 5 };
            var _auxArray = new[] { 1, 2, 3, 10, 11, 12, 16, 15, 14, 13, 7, 4, 5, 6, 9, 8 };
            //act
            int[] _auxSortedArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] _auxSortedArray1 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            int[] _auxReturnBubleSortMethod = SnailSolution.BublerSortRecursive(r, r.Length);
            int[] _auxReturnBubleSortMethod2 = SnailSolution.BublerSortRecursive(_auxArray, _auxArray.Length);

            //assert
            Assert.AreEqual(_auxSortedArray, _auxReturnBubleSortMethod);
            Assert.AreEqual(_auxSortedArray1, _auxReturnBubleSortMethod2);
        }
        [Test]
        public void SnailTest_3x3Matrix()
        {
            int[][] array =
            {
           new []{1, 2, 3},
           new []{4, 5, 6},
           new []{7, 8, 9}
       };
            var r = new[] { 1, 2, 3, 6, 9, 8, 7, 4, 5 };
            Test(array, r);
        }
        public string Int2dToString(int[][] a)
        {
            return $"[{string.Join("\n", a.Select(row => $"[{string.Join(",", row)}]"))}]";
        }
        public void Test(int[][] array, int[] result)
        {
            var text = $"{Int2dToString(array)}\nshould be sorted to\n[{string.Join(",", result)}]\n";
            Console.WriteLine(text);
            Assert.AreEqual(result, SnailSolution.Snail(array));
        }
    }
    public class CountIPAddressesTest
    {
        [Test]
        public void SmapleTest()
        {
            Assert.AreEqual(50, CountIPAddresses.IpsBetween("10.0.0.0", "10.0.0.50"));
            Assert.AreEqual(246, CountIPAddresses.IpsBetween("20.0.0.10", "20.0.1.0"));
            // Assert.AreEqual((1L << 32) - 1L, CountIPAddresses.IpsBetween("0.0.0.0", "255.255.255.255"));
        }
    }
    public class Tests
    {
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
    [TestFixture]
    public class SolutionTests
    {
        [Test]
        public void SmallPyramidTest()
        {
            var smallPyramid = new[]
            {
              new[] {3},
              new[] {7, 4},
              new[] {2, 4, 6},
              new[] {8, 5, 9, 3}
          };
            Console.WriteLine("at SmallPyramidTest");
            Assert.AreEqual(26, PyramidSlideDown.LongestSlideDown(smallPyramid));
        }

        [Test]
        public void MediumPyramidTest()
        {
            var mediumPyramid = new[]
            {
              new [] {75},
              new [] {95, 64},
              new [] {17, 47, 82},
              new [] {18, 35, 87, 10},
              new [] {20,  4, 82, 47, 65},
              new [] {19,  1, 23, 75,  3, 34},
              new [] {88,  2, 77, 73,  7, 63, 67},
              new [] {99, 65,  4, 28,  6, 16, 70, 92},
              new [] {41, 41, 26, 56, 83, 40, 80, 70, 33},
              new [] {41, 48, 72, 33, 47, 32, 37, 16, 94, 29},
              new [] {53, 71, 44, 65, 25, 43, 91, 52, 97, 51, 14},
              new [] {70, 11, 33, 28, 77, 73, 17, 78, 39, 68, 17, 57},
              new [] {91, 71, 52, 38, 17, 14, 91, 43, 58, 50, 27, 29, 48},
              new [] {63, 66,  4, 68, 89, 53, 67, 30, 73, 16, 69, 87, 40, 31},
              new [] { 4, 62, 98, 27, 23,  9, 70, 98, 73, 93, 38, 53, 60,  4, 23}
          };
            Assert.AreEqual(1437, PyramidSlideDown.LongestSlideDown(mediumPyramid));
        }
    }
}