using MyConsoleApp;
using System;
using System.Numerics;

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

namespace
MyConsoleAppTests
{

    [TestFixture]
    public static class LongestConsecutivesTests
    {
        private static void testing(string actual, string expected)
        {
            Assert.AreEqual(expected, actual);
        }
        [Test]
        [TestCase(new String[] { "zone", "abigail", "theta", "form", "libe", "zas", "theta", "abigail" }, 2, "abigailtheta")]
        [TestCase(new String[] { }, 3, "")]
        [TestCase(new String[] { "itvayloxrp", "wkppqsztdkmvcuwvereiupccauycnjutlv", "vweqilsfytihvrzlaodfixoyxvyuyvgpck" }, 2, "wkppqsztdkmvcuwvereiupccauycnjutlvvweqilsfytihvrzlaodfixoyxvyuyvgpck")]
        [TestCase(new String[] { "wlwsasphmxx", "owiaxujylentrklctozmymu", "wpgozvxxiu" }, 2, "wlwsasphmxxowiaxujylentrklctozmymu")]
        [TestCase(new String[] { "zone", "abigail", "theta", "form", "libe", "zas" }, -2, "")]
        // [TestCase(new String[] { "it", "wkppv", "ixoyx", "3452", "zzzzzzzzzzzz" }, 3, "ixoyx3452zzzzzzzzzzzz")]
        [TestCase(new String[] { "it", "wkppv", "ixoyx", "3452", "zzzzzzzzzzzz" }, 15, "")]
        [TestCase(new String[] { "it", "wkppv", "ixoyx", "3452", "zzzzzzzzzzzz" }, 0, "")]
        public static void test1(string[] array, int k, string expected)
        {
            Console.WriteLine("Basic Tests");
            testing(LongestConsecutives.LongestConsec(array, k), expected);
        }
    }
    [TestFixture]
    public class JadenCaseTest
    {
        [Test]
        public void JapenCase_TurnOn_CamelCase_JadenCaseFormattedString()
        {
            Assert.AreEqual("How Can Mirrors Be Real If Our Eyes Aren't Real",
                            "How can mirrors be real if our eyes aren't real".ToJadenCase(),
                            "Strings didn't match.");
            // quantidade prestaçõis restantes
            //valor prestação
        }
    }
    [TestFixture]
    public class BinarySearchTest
    {
        [Test]
        [TestCase("?", "1")]
        public void ScanChar_Return(string expectedResult, string input)
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
    public class IsPangramTest
    {
        [Test]
        public void IsPangram_VerifyIfItsPangram_ReturnTrue()
        {
            Assert.AreEqual(true, Kata.IsPangram("The quick brown fox jumps over the lazy dog."));
        }
        [Test]
        public void IsPangram_VerifyLongString1IsPangram_ReturnTrue()
        {
            // arrange
            // act
            // assert
            Assert.AreEqual(true, Kata.IsPangram("Raw Danger! (Zettai Zetsumei Toshi 2) for the PlayStation 2 is a bit queer, but an alright game I guess, uh... CJ kicks and vexes Tenpenny precariously? This should be a pangram now, probably."));
        }
        [Test]
        [TestCase(true, "Pack my box with five dozen liquor jugs.")]
        [TestCase(true, "ABCD45EFGH,IJK,LMNOPQR56STUVW3XYZ")]
        [TestCase(true, "AbCdEfGhIjKlM zYxWvUtSrQpOn")]
        [TestCase(true, "aaaaaaaaaaaaaaaaaaaaaaaaaa")]
        [TestCase(true, "Detect Pangram")]
        [TestCase(true, "A pangram is a sentence that contains every single letter of the alphabet at least once.")]

        public void IsPangram_VerifyLongString2IsPangram_ReturnTrue(bool expected, string input) =>
            Assert.AreEqual(expected, Kata.IsPangram(input));
        [Test]
        public void IsPangram_VerifyLongString3IsPangram_ReturnTrue() =>
            Assert.AreEqual(true, Kata.IsPangram("ABCD45EFGH,IJK,LMNOPQR56STUVW3XYZ"));
        [Test]
        public void IsPangram_VerifyLongString4IsPangram_ReturnTrue() =>
            Assert.AreEqual(true, Kata.IsPangram("AbCdEfGhIjKlM zYxWvUtSrQpOn"));
        [Test]
        public void IsPangram_VerifyLongString5IsPangram_ReturnTrue() =>
            Assert.AreEqual(true, Kata.IsPangram("aaaaaaaaaaaaaaaaaaaaaaaaaa"));
        [Test]
        public void IsPangram_VerifyLongString6IsPangram_ReturnTrue() =>
            Assert.AreEqual(true, Kata.IsPangram("Detect Pangram"));
        [Test]
        public void IsPangram_VerifyLongString7IsPangram_ReturnTrue() =>
            Assert.AreEqual(true, Kata.IsPangram("A pangram is a sentence that contains every single letter of the alphabet at least once."));
        // A pangram is a sentence that contains every single letter of the alphabet at least once.
    }
    [TestFixture]
    public class StringEndsWith
    {
        private static object[] sampleTestCases = new object[]
        {
      new object[] {"samurai", "ai", true},
      new object[] {"sumo", "omo", false},
      new object[] {"ninja", "ja", true},
      new object[] {"sensei", "i", true},
      new object[] {"samurai", "ra", false},
      new object[] {"abc", "abcd", false},
      new object[] {"abc", "abc", true},
      new object[] {"abcabc", "bc", true},
      new object[] {"ails", "fails", false},
      new object[] {"fails", "ails", true},
      new object[] {"this", "fails", false},
      new object[] {"abc", "", true},
      new object[] {":-)", ":-(", false},
      new object[] {"!@#$%^&*() :-)", ":-)", true},
      new object[] {"abc\n", "abc", false},
        };

        [Test, TestCaseSource("sampleTestCases")]
        public void Test_ValidateIfEnds_ReturnBool(string str, string ending, bool expected)
        {
            Assert.AreEqual(expected, Kata.StringEndsWith(str, ending));
        }
    }
    [TestFixture]
    public class ConverterTests
    {
        [Test]
        public void SumTwoSmallestNumbers_Calculate_ReturnCalculatedValue()
        {
            int[] numbers = { 5, 8, 12, 19, 22 };
            Assert.AreEqual(13, Kata.SumTwoSmallestNumbers(numbers));
        }
        [Test]
        public void SumTwoSmallestNumbers_Calculate_ReturnCalculatedValue2()
        {
            int[] numbers = { 19, 5, 42, 2, 77 };
            Assert.AreEqual(7, Kata.SumTwoSmallestNumbers(numbers));
        }
        [Test]
        public void SumTwoSmallestNumbers_Calculate_ReturnCalculatedValue3()
        {
            int[] numbers = { 10, 343445353, 3453445, 2147483647 };
            Assert.AreEqual(3453455, Kata.SumTwoSmallestNumbers(numbers));
        }
    }

    [TestFixture]
    public class GetIntegersFromListClassTests
    {
        [Test]
        public void GetIntegersFromList_MixedValues_ShouldPass_1()
        {
            var list = new List<object>() { 1, 2, "a", "b" };
            var expected = new List<int>() { 1, 2 };
            var actual = Kata.GetIntegersFromList(list);
            Assert.IsTrue(expected.SequenceEqual(actual));
        }
        [Test]
        public void GetIntegersFromList_MixedValues_ShouldPass_2()
        {
            var list = new List<object>() { 1, "a", "b", 0, 15 };
            var expected = new List<int>() { 1, 0, 15 };
            var actual = Kata.GetIntegersFromList(list);
            Assert.IsTrue(expected.SequenceEqual(actual));
        }
        [Test]
        public void GetIntegersFromList_MixedValues_ShouldPass_3()
        {
            var list = new List<object>() { 1, 2, "aasf", "1", "123", 123 };
            var expected = new List<int>() { 1, 2, 123 };
            var actual = Kata.GetIntegersFromList(list);
            Assert.IsTrue(expected.SequenceEqual(actual));
        }
    }
    [TestFixture]
    public class AreYouPlayingBanjo
    {
        [Test]
        public static void Martin()
        {
            Assert.AreEqual("Martin does not play banjo", Kata.AreYouPlayingBanjo("Martin"));
        }

        [Test]
        public static void Rikke()
        {
            Assert.AreEqual("Rikke plays banjo", Kata.AreYouPlayingBanjo("Rikke"));
        }

        [Test]
        public static void bravo()
        {
            Assert.AreEqual("bravo does not play banjo", Kata.AreYouPlayingBanjo("bravo"));
        }

        [Test]
        public static void rolf()
        {
            Assert.AreEqual("rolf plays banjo", Kata.AreYouPlayingBanjo("rolf"));
        }
    }
    [TestFixture]
    public class TotalPointsTest
    {

        [Test]
        public void Test1() =>
            Test(new[] { "1:0", "2:0", "3:0", "4:0", "2:1", "3:1", "4:1", "3:2", "4:2", "4:3" }, 30);

        [Test]
        public void Test2() =>
            Test(new[] { "1:1", "2:2", "3:3", "4:4", "2:2", "3:3", "4:4", "3:3", "4:4", "4:4" }, 10);

        [Test]
        public void Test3() =>
            Test(new[] { "0:1", "0:2", "0:3", "0:4", "1:2", "1:3", "1:4", "2:3", "2:4", "3:4" }, 0);

        [Test]
        public void Test4() =>
            Test(new[] { "1:0", "2:0", "3:0", "4:0", "2:1", "1:3", "1:4", "2:3", "2:4", "3:4" }, 15);

        [Test]
        public void Test5() =>
            Test(new[] { "1:0", "2:0", "3:0", "4:4", "2:2", "3:3", "1:4", "2:3", "2:4", "3:4" }, 12);

        private void Test(string[] input, int expectedOutput) =>
            Assert.AreEqual(expectedOutput, Kata.TotalPoints(input));

    }
    [TestFixture]
    public class KataTests
    {
        [Test]
        public void SumPositives_CalculateSum_ReturnSum()
        {
            Assert.AreEqual(16, Kata.SumPositives(new[] { 6, 2, 1, 8, 10 }));
        }
        [Test]
        public void SplitStrings_SplitString_ReturnArray()
        {
            Assert.AreEqual(new string[] { "ab", "c_" }, Kata.SplitStrings("abc"));
            Assert.AreEqual(new string[] { "ab", "cd", "ef" }, Kata.SplitStrings("abcdef"));
        }
        [Test]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, ExpectedResult = 15)]
        [TestCase(new int[] { 1, -2, 3, 4, 5 }, ExpectedResult = 13)]
        [TestCase(new int[] { -1, 2, 3, 4, -5 }, ExpectedResult = 9)]
        [TestCase(new int[] { }, ExpectedResult = 0)]
        [TestCase(new int[] { -1, -2, -3, -4, -5 }, ExpectedResult = 0)]
        public static int PositiveSum_Return(int[] arr)
        {
            return Kata.PositiveSum(arr);
        }
        [Test]
        [TestCase("20 8 5 19 21 14 19 5 20 19 5 20 19 1 20 20 23 5 12 22 5 15 3 12 15 3 11", "The sunset sets at twelve o' clock.")]
        [TestCase("20 8 5 14 1 18 23 8 1 12 2 1 3 15 14 19 1 20 13 9 4 14 9 7 8 20", "The narwhal bacons at midnight.")]
        public void AlphabetPosition1Test_ConstructnewStringWithPositionLetters_ReturnString(string expected, string input)
        {
            Assert.AreEqual(expected, Kata.AlphabetPosition1(input));
        }
        [Test]
        public void DigitalRoot_Calculate_ReturnSum()
        {
            Assert.AreEqual(7, Kata.DigitalRoot(16));
            Assert.AreEqual(6, Kata.DigitalRoot(456));
        }
        [Test]
        public void DuplicateEncode_EncodeWord_ReturnEncoded()
        {
            Assert.AreEqual("(((", Kata.DuplicateEncode("din"));
            Assert.AreEqual("()()()", Kata.DuplicateEncode("recede"));
            Assert.AreEqual(")())())", Kata.DuplicateEncode("Success"), "should ignore case");
            Assert.AreEqual("))((", Kata.DuplicateEncode("(( @"));
        }
        [Test]
        public static void ToWeirdCase_Scramble_ReturnWordScrambled()
        {
            Assert.AreEqual("ThIs", Kata.ToWeirdCase("This"));
            Assert.AreEqual("Is", Kata.ToWeirdCase("is"));
            Assert.AreEqual("ThIs Is A TeSt", Kata.ToWeirdCase("This is a test"));
        }
        [Test]
        [TestCase(0, "")]
        [TestCase(0, "abcde")]
        [TestCase(2, "aabbcde")]
        [TestCase(1, "Indivisibility")]
        public void DuplicateCount_CountDuplicates_ReturnTotalDuplicates(int expected, string input)
        => Assert.AreEqual(expected, Kata.DuplicateCount(input));
        [Test]
        public void DuplicateCount_CountDuplicatesAndIgnoreCase_ReturnTotalDuplicates()
        => Assert.AreEqual(2, Kata.DuplicateCount("aabBcde"), "should ignore case");
        [Test]
        public void DuplicateCount_CountDuplicatesAndNoCharactersAdjacent_ReturnTotalDuplicates()
        => Assert.AreEqual(2, Kata.DuplicateCount("Indivisibilities"), "characters may not be adjacent");
        [Test]
        [TestCase("sihT si na !elpmaxe", "This is an example!")]
        [TestCase("sihT si na tset", "This is an test")]
        public void ReverseWords_ReturnString(string expected, string input) => Assert.AreEqual(expected, Kata.ReverseWords(input));
        [Test]
        [TestCase(new string[] { "ab", "c_" }, "abc")]
        [TestCase(new string[] { "ab", "cd", "ef" }, "abcdef")]
        public void SplitString(string[] expected, string input) => Assert.AreEqual(expected, Kata.SplitString(input));
        [Test]
        // [TestCase(new int[] { 2 }       , new int[] { 1, 2 }, new int[] { 1 })]//passed
        [TestCase(new int[] { 2, 2 }, new int[] { 1, 2, 2 }, new int[] { 1 })] //not passed
        // [TestCase(new int[] { 1 }       , new int[] { 1, 2, 2 }, new int[] { 2 })]//passed
        // [TestCase(new int[] { 1, 2, 2 } , new int[] { 1, 2, 2 }, new int[] { })]not passed
        // [TestCase(new int[] { }         , new int[] { }, new int[] { 1, 2 })]//passed
        // [TestCase(new int[] { 3 }       , new int[] { 1, 2, 3 }, new int[] { 1, 2 })]//passed
        public void ArrayDiff_ReturnArrayDiff(int[] expected, int[] input1, int[] input2)
        {
            Assert.AreEqual(expected, Kata.ArrayDiff(input1, input2));
        }
        [Test]
        public void BigNumbersAdd_SumTwoBigIntegers_ReturnSumValue()
        {
            Assert.AreEqual("110", Kata.BigNumbersAdd("91", "19"));
            Assert.AreEqual("1111111111", Kata.BigNumbersAdd("123456789", "987654322"));
            Assert.AreEqual("1000000000", Kata.BigNumbersAdd("999999999", "1"));
        }
        [Test]
        public static void IsPerfectSquare_VerifyIfItsPerfectSquare_ReturnTrueIfItsPerfectSquareOotherwiseFalse()
        {
            Assert.AreEqual(false, Kata.IsPerfectSquare(-1), "negative numbers aren't square numbers");
            Assert.AreEqual(false, Kata.IsPerfectSquare(3), "3 isn't a square number");
            Assert.AreEqual(true, Kata.IsPerfectSquare(4), "4 is a square number");
            Assert.AreEqual(true, Kata.IsPerfectSquare(25), "25 is a square number");
            Assert.AreEqual(false, Kata.IsPerfectSquare(26), "26 isn't a square number");
        }
        [Test, Description("Sample Tests")]
        public void OrderWords_OrderWordsinString_ReturnNewOrderedString()
        {
            Assert.AreEqual("Thi1s is2 3a T4est", Kata.OrderWords("is2 Thi1s T4est 3a"));
            Assert.AreEqual("Fo1r the2 g3ood 4of th5e pe6ople", Kata.OrderWords("4of Fo1r pe6ople g3ood th5e the2"));
            Assert.AreEqual("", Kata.OrderWords(""));
        }
        [Test]
        [TestCase("20 8 5 19 21 14 19 5 20 19 5 20 19 1 20 20 23 5 12 22 5 15 3 12 15 3 11", "The sunset sets at twelve o' clock.")]
        [TestCase("20 8 5 14 1 18 23 8 1 12 2 1 3 15 14 19 1 20 13 9 4 14 9 7 8 20", "The narwhal bacons at midnight.")]
        public void AlphabetPosition_ReplaceCharacterByNumberPosition_ReturnString(string expected, string input)
        {
            Assert.AreEqual(expected, Kata.AlphabetPosition(input));
            // Assert.AreEqual("20 8 5 14 1 18 23 8 1 12 2 1 3 15 14 19 1 20 13 9 4 14 9 7 8 20", Kata.AlphabetPosition("The narwhal bacons at midnight."));
        }
        [Test]
        // [TestCase(new int[] {1, 2, 1, 1, 3, 1, 0, 0, 0, 0},new int[] {1, 2, 0, 1, 0, 1, 0, 3, 0, 1})]
        public void MoveZeroes_MovexerostoTheEndArray_ResturnArray(
            // int[] expectedResult, int[] result
            )
        {
            //   Assert.AreEqual(expectedResult, Kata.MoveZeroes(result));
            Assert.AreEqual(new int[] { 1, 2, 1, 1, 3, 1, 0, 0, 0, 0 }, Kata.MoveZeroes(new int[] { 1, 2, 0, 1, 0, 1, 0, 3, 0, 1 }));
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