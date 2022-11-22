﻿// using System;
using System.Net;
//using System.Collections;
// using System.Collections.Generic;
using System.Text.RegularExpressions;
// using System.Globalization;
using System.Net.Sockets;
using System.Linq;
using System.Text;
// This program shows how to use the IPAddress class to obtain a server
// IP addressess and related information.
// using System;
// using System.Net;
namespace Mssc.Services.ConnectionManagement
{
    class TestIPAddress
    {

        /**
          * The IPAddresses method obtains the selected server IP address information.
          * It then displays the type of address family supported by the server and its
          * IP address in standard and byte format.
          **/
        private static void IPAddresses(string server)
        {
            try
            {
                System.Text.ASCIIEncoding ASCII = new System.Text.ASCIIEncoding();

                // Get server related information.
                IPHostEntry heserver = Dns.GetHostEntry(server);

                // Loop on the AddressList
                foreach (IPAddress curAdd in heserver.AddressList)
                {
                    // Display the type of address family supported by the server. If the
                    // server is IPv6-enabled this value is: InterNetworkV6. If the server
                    // is also IPv4-enabled there will be an additional value of InterNetwork.
                    Console.WriteLine("AddressFamily: " + curAdd.AddressFamily.ToString());

                    // Display the ScopeId property in case of IPV6 addresses.
                    if (curAdd.AddressFamily.ToString() == ProtocolFamily.InterNetworkV6.ToString())
                        Console.WriteLine("Scope Id: " + curAdd.ScopeId.ToString());

                    // Display the server IP address in the standard format. In
                    // IPv4 the format will be dotted-quad notation, in IPv6 it will be
                    // in in colon-hexadecimal notation.
                    Console.WriteLine("Address: " + curAdd.ToString());

                    // Display the server IP address in byte format.
                    Console.Write("AddressBytes: ");

                    Byte[] bytes = curAdd.GetAddressBytes();
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        Console.Write(bytes[i]);
                    }

                    Console.WriteLine("\r\n");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("[DoResolve] Exception: " + e.ToString());
            }
        }

        // This IPAddressAdditionalInfo displays additional server address information.
        private static void IPAddressAdditionalInfo()
        {
            try
            {
                // Display the flags that show if the server supports IPv4 or IPv6
                // address schemas.
                Console.WriteLine("\r\nSupportsIPv4: " + Socket.OSSupportsIPv4);
                Console.WriteLine("SupportsIPv6: " + Socket.OSSupportsIPv6);

                if (Socket.OSSupportsIPv6)
                {
                    // Display the server Any address. This IP address indicates that the server
                    // should listen for client activity on all network interfaces.
                    Console.WriteLine("\r\nIPv6Any: " + IPAddress.IPv6Any.ToString());

                    // Display the server loopback address.
                    Console.WriteLine("IPv6Loopback: " + IPAddress.IPv6Loopback.ToString());

                    // Used during autoconfiguration first phase.
                    Console.WriteLine("IPv6None: " + IPAddress.IPv6None.ToString());

                    Console.WriteLine("IsLoopback(IPv6Loopback): " + IPAddress.IsLoopback(IPAddress.IPv6Loopback));
                }
                Console.WriteLine("IsLoopback(Loopback): " + IPAddress.IsLoopback(IPAddress.Loopback));
            }
            catch (Exception e)
            {
                Console.WriteLine("[IPAddresses] Exception: " + e.ToString());
            }
        }
        public static long IpsBetween(string start, string end)
        {
            long _returnTotalCount = -1;
            string server;

            IPAddress _IPStart;
            IPAddress _IPEnd;
            // Define a regular expression to parse user's input.
            // This is a security check. It allows only
            // alphanumeric input string between 2 to 40 character long.
            Regex regex = new Regex(@"^[a-zA-Z]\w{1,39}$");

            //   if (args.Length < 1)
            //   {
            // If no server name is passed as an argument to this program, use the current
            // server name as default.
            server = Dns.GetHostName();
            // Console.WriteLine("Using current host: " + server);
            //   }
            //   else
            //   {
            server = start;
            if (!(regex.Match(server)).Success
            )
            {
                Console.WriteLine("Input string format not allowed.");
                return _returnTotalCount;
            }
            if (regex.Match(end).Success)
                Console.WriteLine("last IPaddress format allowed.");
            //   }
            // Get the list of the addresses associated with the requested server.
            IPAddresses(server);

            // Get additional address information.
            IPAddressAdditionalInfo();


            if (IPAddress.TryParse(start, out _IPStart) && IPAddress.TryParse(end, out _IPEnd))
            {
                var _enumerableEnd = (from z in _IPEnd.ToString()
                                      orderby z descending
                                      select z).ToString().Split('.');
                var _enumerableStart =
                   (from z in _IPEnd.ToString()
                    orderby z descending
                    select z).ToString()
                                   .Split('.')
                                   ;

                int _auxEnd = 0;
                Int32.TryParse(string.Join("", _enumerableEnd), out _auxEnd);
                int _auxStart = 0;
                Int32.TryParse(string.Join("", _enumerableStart), out _auxStart);
                _returnTotalCount = _auxEnd - _auxStart;
            }
            return _returnTotalCount;
        }

        public static void Main(string[] args)
        {
            string server;
            // Define a regular expression to parse user's input.
            // This is a security check. It allows only
            // alphanumeric input string between 2 to 40 character long.
            Regex rex = new Regex(@"^[a-zA-Z]\w{1,39}$");

            if (args.Length < 1)
            {
                // If no server name is passed as an argument to this program, use the current
                // server name as default.
                server = Dns.GetHostName();
                Console.WriteLine("Using current host: " + server);
            }
            else
            {
                server = args[0];
                if (!(rex.Match(server)).Success)
                {
                    Console.WriteLine("Input string format not allowed.");
                    return;
                }
            }

            // Get the list of the addresses associated with the requested server.
            IPAddresses(server);

            // Get additional address information.
            IPAddressAdditionalInfo();
        }
    }
}
namespace MyConsoleApp
{
    public static class JadenCase
    {
        ///Best patrice
        public static string ToJadenCase(this string phrase)
        {
            //return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(phrase);
            return string.Join(" ", phrase.Split().Select(z => Char.ToUpper(z[0]) + z.Substring(1)));
        }
        /*
        public static string ToJadenCase(this string phrase)
        {
            string[] _str = phrase.Split(' ');
            string _formatted = string.Empty;
            for (int i = 0; i < _str.Length; i++)
            {
                _formatted += string.Join("", _str[i].First().ToString().ToUpper());
                _formatted += string.Join("", _str[i].Skip(1).ToArray());
                if (i != _str.Length - 1)
                {
                    _formatted += " ";
                }
                Console.WriteLine("_formatted {0}", _formatted);
            }
            return _formatted;
        }
        */
    }
    public class SnailSolution
    {
        static void WentLeft(int[][] array, List<int> _returnList, int _next, bool _wentLeft, bool _wentUp, int i)
        {
            int _auxX = array.Length - 1;
            int _auxY = array[i].Length - 1;
            for (int q = _next; q >= 0; q--)
            {
                _returnList.Add(array[array.Length - 1][q]);
                _next = q;
            }
            _wentLeft = false;
            _wentUp = true;
            _next = _next + 1;
        }
        static void WentDown(int _next, int[][] array, List<int> _returnList, bool _wentDown, bool _wentLeft, int j)
        {
            for (int k = _next; k < array.Length; k++)
            {
                _returnList.Add(array[k][j]);
                _next = j;
            }
            _wentDown = false;
            _wentLeft = true;
            _next = _next - 1;
        }
        static void WentUp(int[][] array, decimal _auxMiddle, List<int> _returnList, bool _wentUp, bool _wentRight, int _auxMiddle2)
        {
            int _auxRowLengthMinusOne = array.Length - 1;
            if (_auxRowLengthMinusOne % 2 == 0)
            {
                _auxMiddle = _auxRowLengthMinusOne / 2;
                _auxRowLengthMinusOne = _auxRowLengthMinusOne - 1;
            }
            else
            {
                _auxMiddle = Math.Round(Convert.ToDecimal(_auxRowLengthMinusOne / 2), 0, MidpointRounding.ToEven);
                _auxMiddle = _auxMiddle + 1;
            }
            for (int q = _auxRowLengthMinusOne; q >= _auxMiddle; q--)
            {
                _returnList.Add(array[q][0]);
            }
            _wentUp = false;
            _wentRight = true;
            _auxMiddle2 = _auxRowLengthMinusOne;
        }
        static void WentRight(int[][] array, decimal _auxMiddle, int _auxMiddle2, List<int> _returnList, bool _wentRight, bool _isGoalAchivied, int i)
        {
            int _auxColumnLength = array[i].Length - 1;
            if (_auxColumnLength % 2 == 0)
            {
                _auxMiddle = _auxColumnLength / 2;
            }
            else
            {
                _auxMiddle = Math.Round(Convert.ToDecimal(_auxColumnLength / 2), 0, MidpointRounding.ToEven);
                _auxMiddle = _auxMiddle + 1;
            }
            decimal _auxDec = (_auxColumnLength) / 2;//to consider the 0 position
            _auxDec = _auxDec / 2;
            decimal _auxq = Math.Round(Convert.ToDecimal(_auxDec), MidpointRounding.ToEven);
            // int _auxMiddle = int.Parse(_auxq.ToString());
            int _aux1;
            if (int.TryParse(_auxMiddle2.ToString(), out _aux1))
            {
                for (int q = _auxMiddle2; q <= _auxMiddle; q++)
                {
                    _returnList.Add(array[_auxMiddle2][q]);
                }
                _wentRight = false;
                _isGoalAchivied = true;
            }
            else throw new Exception("Convertion error on middle value");
        }
        public static int[] BublerSortRecursive(int[] array, int length)
        {
            if (length == 1)
            {
                return array;
            }
            int _count = 0;
            for (int i = 0; i < length - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    int _temp = array[i];
                    array[i] = array[i + 1];
                    array[i + 1] = _temp;
                    _count++;
                }
            }
            if (_count == 0)
            {
                return array;
            }
            return BublerSortRecursive(array, length - 1);
        }
        ///Given an n x n array, return the array elements arranged from outermost elements to the middle element, traveling clockwise.
        ///todo | 1 determine the row length and column length| 2- execute the snail path 
        public static int[] Snail(int[][] array)
        {
            int[] _return = new int[] { };
            List<int> _returnList = new List<int>();
            int _rowLength = array.Length - 1;
            int _next = 0;
            int _columnLength = 0;
            bool _wentDown = false;
            bool _wentLeft = false;
            bool _wentUp = false;
            bool _wentRight = false;
            bool _isToAdd = true;
            bool _isGoalAchivied = false;
            decimal _auxMiddle = 0;
            int _auxMiddle2 = 0;
            try
            {
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 0; j < array[i].Length; j++)
                    {
                        if (!_isGoalAchivied)
                        {
                            _columnLength = array[i].Length - 1;
                            if (_isToAdd) _returnList.Add(array[i][j]);
                            if (_columnLength.Equals(j))
                            {
                                _wentDown = true;
                                _isToAdd = false;
                                _next = i + 1;
                            }
                            if (_wentDown)
                            {
                                WentDown(_next, array, _returnList, _wentDown, _wentLeft, j);
                            }
                            if (_wentLeft)
                            {
                                WentLeft(array, _returnList, _next, _wentLeft, _wentUp, i);
                            }
                            if (_wentUp)
                            {
                                WentUp(array, _auxMiddle, _returnList, _wentUp, _wentRight, _auxMiddle2);
                            }
                            if (_wentRight)
                            {
                                WentRight(array, _auxMiddle, _auxMiddle2, _returnList, _wentRight, _isGoalAchivied, i);
                            }
                        }
                    }
                }
            }
            catch (System.Exception e)
            {
                Console.WriteLine($" {Environment.NewLine}Stack{e.ToString()}");
            }
            return _returnList.ToArray();
        }
    }

    public class StripCommentsSolution
    {
        ///Complete the solution so that it strips all text that follows any of a set of comment markers passed in. Any whitespace at the end of the line should also be stripped out.
        public static string StripComments(string text, string[] commentSymbols)
        {//todo 1- get substring from 0 to NewLine |2 - apply regex into previous substring| 3-apply to return value
            string _return = string.Empty;
            string[] _auxText = text.Split(Environment.NewLine, int.MaxValue, StringSplitOptions.RemoveEmptyEntries);
            int _count = 0;
            Dictionary<string, List<string>> _auxDic = new Dictionary<string, List<string>>();
            string _auxString = string.Empty;
            for (int j = 0; j < _auxText.Length; j++)
            {
                for (int i = 0; i < commentSymbols.Length; i++)
                {
                    List<string> _auxList = new List<string>();
                    if (!_auxDic.TryGetValue(_auxText[j], out _auxList))
                    {
                        if (_auxList.Count() == 0) _auxList = new List<string>();
                        if (_auxList.Contains(commentSymbols[i]))
                        {
                            _auxList.Add(commentSymbols[i]);
                            _auxDic.Add(_auxText[j], _auxList);
                            string regex = string.Format(@"^(?:(?!\s{0})(?!\sdef).)*", commentSymbols[i]);
                            var _match = Regex.Match(_auxText[j], regex);
                            // if (_match.Success)
                            // {
                            string _auxValue = _match.Value;
                            _return += _auxValue;
                            if (_count < _auxText.Length - 1)
                            {
                                _return += Environment.NewLine;
                                _count++;
                            }
                            // }
                            // else
                            // _return+=_auxText[j];
                        }
                    }
                    // else{
                    //     _return+=_auxText[j];
                    // }
                }
            }
            return _return;
        }
    }


    public class PagnationHelper<T>
    {
        // TODO: Complete this class
        private List<T> collection;
        private int itemCount;
        public List<T> Collection { get => collection; }
        private int itemsPerPage;
        public int ItemsPerPage
        {
            //todo | research | get=>return >= itemsPerPage;
            get { return itemsPerPage; }
            set => itemsPerPage = value;
        }

        /// <summary>
        /// The number of items within the collection
        /// </summary>
        public int ItemCount
        {
            get => itemCount;

        }
        /// <summary>
        /// The number of pages
        /// </summary>
        public int PageCount
        {
            get
            {
                return 0;
            }
        }
        /// <summary>
        /// Constructor, takes in a list of items and the number of items that fit within a single page
        /// </summary>
        /// <param name="collection">A list of items</param>
        /// <param name="itemsPerPage">The number of items that fit within a single page</param>
        public PagnationHelper(IList<T> collection, int itemsPerPage)
        {
            // collection
        }
        /// <summary>
        /// Returns the number of items in the page at the given page index 
        /// </summary>
        /// <param name="pageIndex">The zero-based page index to get the number of items for</param>
        /// <returns>The number of items on the specified page or -1 for pageIndex values that are out of range</returns>
        public int PageItemCount(int pageIndex)
        {
            return this.PageIndex(pageIndex);
        }

        /// <summary>
        /// Returns the page index of the page containing the item at the given item index.
        /// </summary>
        /// <param name="itemIndex">The zero-based index of the item to get the pageIndex for</param>
        /// <returns>The zero-based page index of the page containing the item at the given item index or -1 if the item index is out of range</returns>
        public int PageIndex(int itemIndex)
        {
            return 0;
        }
    }
    public class JosephusSurvivor
    {/*
    In this kata you have to correctly return who is the "survivor", ie: the last element of a Josephus permutation.

Basically you have to assume that n people are put into a circle and that they are eliminated in steps of k elements, like this:
josephus_survivor(7,3) => means 7 people in a circle;
one every 3 is eliminated until one remains
[1,2,3,4,5,6,7] - initial sequence
[1,2,4,5,6,7] => 3 is counted out
[1,2,4,5,7] => 6 is counted out
[1,4,5,7] => 2 is counted out
[1,4,5] => 7 is counted out
[1,4] => 5 is counted out
[4] => 1 counted out, 4 is the last element - the survivor!
*/
        public static int JosSurvivor(int n, int k)
        {//todo 1- iterate in a contructed list array wich elements begin in 1  en end in n | 2- remove element array considering offset | 3- when offset > array.Length survivor = next element
            int _lastIndex = 0;
            int _originalOffset = k - 1;
            int _originalOffset_Increased = k;
            List<int> _listintegers = new List<int>();
            for (int i = 1; i <= n; i++)
            {
                _listintegers.Add(i);
            }
            int _aux = _originalOffset;//compatible to zero index methods
            while (_aux < _listintegers.Count())
            {
                _listintegers.RemoveAt(_aux);

                if ((_aux + _originalOffset_Increased) <= _listintegers.Count() - 1)
                {
                    _aux += _originalOffset;
                }
                else
                    _aux = _originalOffset;
                _lastIndex = _aux;
            }
            int _survivor = 0;
            if (_lastIndex <= _listintegers.Count() - 1)
                _survivor = _listintegers.ElementAt(_lastIndex++);
            else _survivor = _listintegers.Last();
            return _survivor;
        }
    }
    public class Scramblies
    {
        ///description: Best practise | clever
        public static bool Scramble(string str1, string str2)
        {
            return str2.All(x => str1.Count(y => y == x) >= str2.Count(y => y == x));
        }
        ///Complete the function scramble(str1, str2) that returns true if a portion of str1 characters can be rearranged to match str2, otherwise returns false.
        // public static bool Scramble(string str1, string str2)
        // {
        //     bool _return = true;
        //     int _indexOf = 0;
        //     //todo 1- iterate in each character of str1 and str2, to find a equal character , and if yes, remove character from str1;
        //     for (int i = 0; i < str2.Length; i++)
        //     {
        //         _indexOf = str1.IndexOf(str2[i]);
        //         if (_indexOf > -1)
        //         {
        //             str1 = str1.Remove(_indexOf, 1);
        //         }
        //         else
        //         {
        //             _return = false;
        //             return _return ;
        //         }
        //     }
        //     return _return;
        // }

    }

    public class Answer
    {
        /// multisition technical Exame
        /*
        <returns>the character of which s is the​​​​​​‌​​‌​​‌​‌​‌​‌‌​‌‌‌​​‌​‌‌‌ representation</returns>
        */
        public static char ScanChar(string s)
        {
            if (!s.Equals(string.Empty))
                return char.Parse(Regex.Replace(s, "[a-zA-Z]"
              , new MatchEvaluator(z => ((z.Value[0] + (Char.IsLetter(z.Value, 0) ? z.Value : "?"))))));
            return char.Parse(string.Empty);
        }
    }
    public class BinarySearch
    {
        public static bool Exists(int[] ints, int k)
        {
            if (ints.Length == 0)
                return false;
            int _min = ints[0];
            int _max = ints[ints.Length - 1];
            if (BinarySearchOnArray(ints, _min, _max, k).Equals(-1))
                return false;
            return true;
        }
        public static int BinarySearchOnArray(int[] array, int minPostionArray, int maxPostitionArray, int middleElement)
        {
            if (maxPostitionArray >= minPostionArray)
            {
                int _middle = minPostionArray + (maxPostitionArray - middleElement) / 2;
                if (array[_middle] == middleElement) return _middle;
                if (array[_middle] > middleElement)
                    return BinarySearchOnArray(array, minPostionArray, _middle - 1, middleElement);
                return BinarySearchOnArray(array, _middle + 1, maxPostitionArray, middleElement);
            }
            return -1;
        }
    }
    public static class Kata
    {
        public static bool IsPangram(string str)
        {
            // return str.Where(ch => Char.IsLetter(ch)).Select(ch => Char.ToLower(ch)).Distinct().Count() == 26;
            // return "abcdefghijklmnopqrstuvwxyz".All(x => str.ToLower().Contains(char.ToLower(x)));
            return str.ToUpper().Where(char.IsLetter).Distinct().Count() == 26;

        }
        /*
                public static bool IsPangram(string str)
                {
                    string _alphabet = "a b c d e f g h i j k l m n o p q r s t u v w x y z 0 1 2 3 4 5 6 7 8 9";
                    var _auxArray = _alphabet.Split(' ');
                    Dictionary<char,bool> _dic=new Dictionary<char, bool>();
                    foreach (var item in _auxArray)
                    {
                        _dic.Add(char.Parse(item),false);
                    }
                    Regex _regex = new Regex("[^a-zA-Z0-9]");
                    string _str = _regex.Replace(str, "");
                    _str = _str.ToLower();
                    StringBuilder _sb = new StringBuilder();
                    foreach (var item in _str)
                    {
                        if (!Char.IsPunctuation(item)||Char.IsWhiteSpace(item))
                        {
                            _sb.Append(item);
                        }
                    }
                    string _aq = new string(_str.Where(z => Char.IsPunctuation(z)).ToArray());
                    // return _auxArray.Any(_str.Contains);

                    foreach (var item in _sb.ToString().ToArray())
                    {
                        Console.WriteLine(item);
                        if (_auxArray.Any(z => item.ToString().Contains(z)))
                        {
                            _dic[item]= true;
                        }
                    }
                    return _dic.ContainsValue(false);
                }
                */
        /*
        Write an algorithm that takes an array and moves all of the zeros to the end, preserving the order of the other elements.

        if(numbers.Length==0)
        return -1;
int _max=0;
       for (int i=0;i<numbers.Length;i++){
       if(_max<numbers[i])
       _max=numbers[i];
       }
       return _max;
        */
        public static int[] MoveZeroes(int[] arr)
        {

            if (arr.Length == 0) return arr;
            int[] _array = new int[] { };

            List<int> _listIntegers = new List<int>();
            _listIntegers = arr.ToList();
            for (int i = 0; i < arr.Length; i++)
            {
                if (_listIntegers.ElementAt(i).Equals(0))
                {
                    _listIntegers.RemoveAt(i);
                    _listIntegers.Add(0);
                }
                //questions  review  : 6,8,9
            }
            Console.WriteLine(_listIntegers.Max(z => z.ToString()));
            return _listIntegers.ToArray();
        }

        /*In mathematics, the factorial of integer n is written as n!. It is equal to the product of n and every integer preceding it. For example: 5! = 1 x 2 x 3 x 4 x 5 = 120

Your mission is simple: write a function that takes an integer n and returns the value of n!.

You are guaranteed an integer argument. For any values outside the non-negative range, return null, nil or None (return an empty string "" in C and C++). For non-negative numbers a full length number is expected for example, return 25! =  "15511210043330985984000000"  as a string.

For more on factorials, see http://en.wikipedia.org/wiki/Factorial

NOTES:

The use of BigInteger or BigNumber functions has been disabled, this requires a complex solution

I have removed the use of require in the javascript language.

*/
        public static string Factorial(int n)
        {
            int factorial = n;
            if (n == 0) return 1.ToString();
            if (n < 0) return string.Empty;
            for (int i = 1; i <= n; i++)
            {
                factorial = factorial * i;
            }
            return factorial.ToString();
        }
        /*
        How can you tell an extrovert from an introvert at NSA? Va gur ryringbef, gur rkgebireg ybbxf ng gur BGURE thl'f fubrf.

I found this joke on USENET, but the punchline is scrambled. Maybe you can decipher it? According to Wikipedia, ROT13 (http://en.wikipedia.org/wiki/ROT13) is frequently used to obfuscate jokes on USENET.

Hint: For this task you're only supposed to substitue characters. Not spaces, punctuation, numbers etc.
*/

        ///best practice2
        //   public static string Rot13(string input)
        //   {
        //      var s1 = "NOPQRSTUVWXYZABCDEFGHIJKLMnopqrstuvwxyzabcdefghijklm";
        //      var s2 = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        //      return string.Join("", input.Select(x => char.IsLetter(x)?s1[s2.IndexOf(x)]:x));
        //   }

        ///best practice1
        public static string Rot13(string input) =>
        Regex.Replace(input, "[a-zA-Z]"
        , new MatchEvaluator(z => ((char)(z.Value[0] + (Char.ToLower(z.Value[0]) >= 'n' ? -13 : 13))).ToString()));
        // Regex.Replace(input, "[a-zA-Z]", new MatchEvaluator(c => ((char)(c.Value[0] + (Char.ToLower(c.Value[0]) >= 'n' ? -13 : 13))).ToString()));

        // public static string Rot13(string input)
        // {//todo 1- create a collection to save the cypher | 2- evaluate the input and encrypt it

        //     string _return = string.Empty;
        //     Dictionary<char, char> _ROT13Collection = new Dictionary<char, char>();
        //     _ROT13Collection.Add('A', 'N');
        //     _ROT13Collection.Add('B', 'O');
        //     _ROT13Collection.Add('C', 'P');
        //     _ROT13Collection.Add('D', 'Q');
        //     _ROT13Collection.Add('E', 'R');
        //     _ROT13Collection.Add('F', 'S');
        //     _ROT13Collection.Add('G', 'T');
        //     _ROT13Collection.Add('H', 'U');
        //     _ROT13Collection.Add('I', 'V');
        //     _ROT13Collection.Add('J', 'W');
        //     _ROT13Collection.Add('K', 'X');
        //     _ROT13Collection.Add('L', 'Y');
        //     _ROT13Collection.Add('M', 'Z');
        //     Tuple<char, char> _tuple = new Tuple<char, char>('A', 'N');

        //     foreach (var item in input)
        //     {
        //         bool _isUpper = false;
        //         char _auxItem;
        //         string _aux =string.Empty;
        //         if (char.IsLower(item))
        //         {
        //             _auxItem = char.Parse(item.ToString().ToUpper());
        //             _isUpper = true;
        //         }
        //         else
        //             _auxItem = item;

        //         if (_ROT13Collection.ContainsKey(_auxItem))
        //         {
        //             _aux = _ROT13Collection.Where(z => z.Key == _auxItem).Select(z => z.Value).First().ToString();
        //         }
        //         else if (_ROT13Collection.ContainsValue(_auxItem))
        //             _aux = _ROT13Collection.Where(z => z.Value == _auxItem).Select(z => z.Key).First().ToString();
        //         else
        //             _return += item;
        //         if (_isUpper) 
        //         _return += _aux.ToString().ToLower();
        //         else 
        //         _return+=_aux;
        //     }

        //     return _return;
        // }

        ///Complete the function/method so that it takes a PascalCase string and returns the string in snake_case notation. Lowercase characters can be numbers. If the method gets a number as input, it should return a string.
        public static string ToUnderscore(int str) => str.ToString();
        // public static string ToUnderscore(int str)
        // {
        //      string _return = string.Empty;
        //      string _auxStr=str.ToString();
        //     try
        //     {
        //         string _auxReturn = string.Empty;
        //         for (int i = 0; i < _auxStr.Length; i++)
        //         {
        //             if (Char.IsLetterOrDigit(_auxStr[i]))
        //             {
        //                 if (Char.IsUpper(_auxStr[i]))
        //                 {
        //                     if (i == 0)
        //                     {
        //                         _auxReturn += _auxStr[i].ToString().ToLower();
        //                     }
        //                     else
        //                     {
        //                         _auxReturn += '_'+_auxStr[i].ToString().ToLower() ;
        //                     }
        //                 }
        //                 else{_auxReturn+=_auxStr[i];}
        //             }
        //         }
        //         _return = _auxReturn;    
        //     }
        //     catch (NotImplementedException e)
        //     {
        //         Console.WriteLine($"Error: {e.ToString()}");
        //     }
        //     catch (System.Exception e)
        //     {
        //         Console.WriteLine($"Error: {e.ToString()}");
        //     }
        //     return _return;
        // }

        ///Complete the function/method so that it takes a PascalCase string and returns the string in snake_case notation. Lowercase characters can be numbers. If the method gets a number as input, it should return a string.
        public static string ToUnderscore(string str) => string.Join("_", Regex.Split(str, "(?=[A-Z])").Skip(1)).ToLower();
        // public static string ToUnderscore(string str)
        // {
        //     string _return = string.Empty;
        //     try
        //     {
        //         string _auxReturn = string.Empty;
        //         for (int i = 0; i < str.Length; i++)
        //         {
        //             if (Char.IsLetterOrDigit(str[i]))
        //             {
        //                 if (Char.IsUpper(str[i]))
        //                 {
        //                     if (i == 0)
        //                     {
        //                         _auxReturn += str[i].ToString().ToLower();
        //                     }
        //                     else
        //                     {
        //                         _auxReturn += '_'+str[i].ToString().ToLower() ;
        //                     }
        //                 }
        //                 else{_auxReturn+=str[i];}
        //             }
        //         }
        //         _return = _auxReturn;    
        //     }
        //     catch (NotImplementedException e)
        //     {
        //         Console.WriteLine($"Error: {e.ToString()}");
        //     }
        //     catch (System.Exception e)
        //     {
        //         Console.WriteLine($"Error: {e.ToString()}");
        //     }
        //     return _return;
        // }
    }
    public static class SimpleAssembler
    {
        public static Dictionary<string, int> DictionaryAdd(Dictionary<string, int> returnDic, string variable, int value, bool isToAdd)
        {
            if (isToAdd)
            {
                returnDic.Add(variable, value);
            }
            else
            {
                returnDic[variable] = value;
            }
            return returnDic;
        }
        /// todo 1- get operation and value | 2- execute operation in varible | 3-add var and value to dict
        public static Dictionary<string, int> Interpret(string[] program)
        {
            int _auxValue = 1;
            int _minOperationPostion = 0;
            int _lengthOperationPostion = 3;
            char _auxVar;
            string _auxOperation = string.Empty;
            string _aux = string.Empty;
            string[] _operations = new string[] { "mov", "inc", "dec", "jnz" };
            const int _varPosition = 4;
            const int _valuePosition = 6;
            Dictionary<string, int> _returnDic = new Dictionary<string, int>();
            foreach (var item in program)
            {
                _auxOperation = item.Substring(_minOperationPostion, _lengthOperationPostion);
                _auxVar = item[_varPosition];
                if (!_auxOperation.Equals(_operations[1]) && !_auxOperation.Equals(_operations[2]))
                {
                    _aux = item[_valuePosition].ToString();
                    if (_returnDic.ContainsKey(_aux))
                        _auxValue = _returnDic[_aux];
                    else
                        _auxValue = int.Parse(item.Substring(_valuePosition, item.Length - _valuePosition));
                }
                if (_auxOperation.Equals(_operations[0]))
                {
                    _returnDic.Add(_auxVar.ToString(), _auxValue);
                }
                if (_auxOperation.Equals(_operations[1]))
                {
                    _auxValue++;
                }
                if (_auxOperation.Equals(_operations[2]))
                {
                    _auxValue--;
                }
                if (_auxOperation.Equals(_operations[3]))
                {
                    if (!_returnDic[_auxVar.ToString()].Equals(0))
                        _returnDic[_auxVar.ToString()] = _auxValue;
                }

                try
                {
                    if (!_returnDic.ContainsKey(_auxVar.ToString()))
                    {
                        _returnDic.Add(_auxVar.ToString(), _auxValue);
                    }
                    else
                    {
                        _returnDic[_auxVar.ToString()] = _auxValue;
                    }
                }
                catch (System.Exception e)
                {
                    Console.WriteLine("Exception: " + e.ToString());
                }
            }
            return _returnDic;
        }
    }
    public class CountIPAddresses
    {
        public static long IpsBetween(string start, string end)
        {
            int _returnTotalCount = -1;
            IPAddress _IPStart;
            IPAddress _IPEnd;
            if (IPAddress.TryParse(start, out _IPStart) && IPAddress.TryParse(end, out _IPEnd))
            {
                var _auxIntIpEnd = BitConverter.ToInt32(_IPEnd.GetAddressBytes().Reverse().ToArray(), 0);
                var _auxIntIpStart = BitConverter.ToInt32(_IPStart.GetAddressBytes().Reverse().ToArray(), 0);
                if (_auxIntIpEnd < _auxIntIpStart)
                    _returnTotalCount = _auxIntIpStart - _auxIntIpEnd;
                else
                    _returnTotalCount = _auxIntIpEnd - _auxIntIpStart;
            }
            return _returnTotalCount;
        }
        ///auxiliar method
        //logic  is to know the difference( subtract) the class D IP from 2 IP's
        public static long IpsBetween(string start, string end, bool token)
        {
            long _returnTotalCount = -1;

            IPAddress _IPStart;
            IPAddress _IPEnd;

            //TODO | 1- get last digits(class D of IP) | 2 - validate IPstart it's bigger than IPend
            if (IPAddress.TryParse(start, out _IPStart) && IPAddress.TryParse(end, out _IPEnd))
            {
                var _enumerableEnd = _IPEnd.ToString().Split('.');
                var _enumerableStart = _IPStart.ToString().Split('.');
                int _auxEnd = 0;
                int _auxStart = 0;
                try
                {
                    if (Int32.TryParse(_enumerableEnd[3], out _auxEnd) && Int32.TryParse(_enumerableStart[3], out _auxStart))//it's in the position 3 where is located the Class D IP
                    {
                        if (_auxStart > _auxEnd)
                        {
                            _returnTotalCount = _auxStart - _auxEnd;
                        }
                        else
                            _returnTotalCount = _auxEnd - _auxStart;
                    }
                }
                catch (System.Exception e)
                {
                    Console.WriteLine("Convertion error of Class D IP: " + e.ToString());
                }
            }
            return _returnTotalCount;
        }
    }
    public class RomanNumerals
    {
        ///todo | 1- get total digits length | 2 - 
        public static string ToRoman(int n)
        {
            int _auxLength = n.ToString().Length;
            int _digit = 0;
            int _auxItem = 0;
            string _auxConvert = string.Empty;
            string _return = string.Empty;

            foreach (var item in n.ToString())
            {
                Console.WriteLine($"item: {item}");

                _auxItem = int.Parse(item.ToString());
                _digit = n.ToString()[0];
                if (_auxLength == 4)
                {
                    while (_auxItem != 0)
                    {
                        _return += 'M';
                        _auxItem--;
                    }
                    Console.WriteLine($"M: {_return}");
                }
                if (_auxLength == 3)
                {
                    while (_auxItem != 0)
                    {
                        _return += 'C';
                        _auxItem--;
                    }
                    Console.WriteLine($"C: {_return}");
                }
                if (_auxLength == 2)
                {
                    _auxConvert = ConvertBasicRoman(int.Parse(item.ToString()));
                    _return += _auxConvert;
                }
                if (_auxLength == 1)
                {
                    _auxConvert = ConvertBasicRoman(int.Parse(item.ToString()));
                    _return += _auxConvert;
                    Console.WriteLine($"basic : {_return}");
                }
                _auxLength--;
            }
            Console.WriteLine($"_return: {_return}");
            return _return;
        }
        static string ConvertBasicRoman(int n)
        {
            string _return = "";
            if (n.Equals(1)) _return = "I";
            if (n.Equals(2)) _return = "II";
            if (n.Equals(3)) _return = "III";
            if (n.Equals(4)) _return = "IV";
            if (n.Equals(5)) _return = "V";
            if (n.Equals(6)) _return = "VI";
            if (n.Equals(7)) _return = "VII";
            if (n.Equals(8)) _return = "VIII";
            if (n.Equals(9)) _return = "IX";
            if (n.Equals(10)) _return = "X";
            return _return;
        }
        static int ConvertBasicRoman(string romanNumeral)
        {
            int _return = -1;
            if (romanNumeral.Equals("I")) _return = 1;
            if (romanNumeral.Equals("II")) _return = 2;
            if (romanNumeral.Equals("III")) _return = 3;
            if (romanNumeral.Equals("IV")) _return = 4;
            if (romanNumeral.Equals("V")) _return = 5;
            if (romanNumeral.Equals("VI")) _return = 6;
            if (romanNumeral.Equals("VII")) _return = 7;
            if (romanNumeral.Equals("VIII")) _return = 8;
            if (romanNumeral.Equals("IX")) _return = 9;
            if (romanNumeral.Equals("X")) _return = 10;
            return _return;
        }
        public static int FromRoman(string romanNumeral)
        {
            string? _auxString = null;
            string _auxToUpper = romanNumeral.ToUpperInvariant();
            int _return = 0;
            int _auxConvertBasicRoman = ConvertBasicRoman(romanNumeral);
            if (_auxConvertBasicRoman != -1) return _auxConvertBasicRoman;

            foreach (var item in romanNumeral)
            {
                switch (item)
                {
                    case 'L':
                        _auxString += 50;
                        break;

                    case 'C':
                        _auxString += 100;
                        break;

                    case 'D':
                        _auxString += 500;
                        break;

                    case 'M':
                        _auxString += 1000;
                        break;

                    default:

                        ;
                        break;
                }
            }
            var _q = (from z in romanNumeral select z);
            return _return;
        }
    }
    public class PyramidSlideDown
    {
        //Todo | 1- search the elementary iterate in every tree node | 2- per level edentify , the max and min | 3 - sum teh max level to a total var 
        public static int LongestSlideDown(int[][] pyramid)
        {
            int _totalReturn = 0;
            int _max = 0;
            List<int> _auxList;
            for (int i = 0; i < pyramid.GetLength(0); i++)//iterate in rows 
            {
                Console.WriteLine($"pyramid.GetLength(0):  {pyramid.GetLength(0)}");
                _auxList = pyramid[i].ToList();
                Console.WriteLine($"pyramid.GetLength(0):  {pyramid.GetLength(1)}");
                foreach (var item in _auxList)
                {
                    if (_max < item)
                    {
                        _max = item;
                    }
                    Console.WriteLine($"max:  {_max}");
                }
                _totalReturn += _max;
            }
            Console.WriteLine($"mas:  {_totalReturn}");
            return _totalReturn;
        }
    }

    class Program
    {
        public static int Add(int pOne, int pTwo) => (pOne + pTwo);

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            OperatingSystem _os = Environment.OSVersion;
            Console.WriteLine(_os.Platform + Environment.NewLine + _os.ServicePack + Environment.NewLine + _os.Version);
            // /home/telmosantos/.dotnet/
        }
    }
}
