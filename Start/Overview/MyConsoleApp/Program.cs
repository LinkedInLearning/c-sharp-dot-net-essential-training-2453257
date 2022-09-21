using System;

namespace MyConsoleApp
{
    public class RomanNumerals
{
    ///todo | 1- get total digits length | 2 - 
    public static string ToRoman(int n)
    { 
        int _auxLength=n.ToString().Length;
        int _digit=0;
        int _auxItem=0;
        string _auxConvert=string.Empty;
        string _return=string.Empty;

        foreach (var item in n.ToString())
        {
            Console.WriteLine($"item: {item}");
           
            _auxItem=int.Parse(item.ToString());
            _digit=n.ToString()[0];
          if(_auxLength==4)
          {
                 while(_auxItem!=0)
          {
            _return+='M';
            _auxItem--;
           }
                        Console.WriteLine($"M: {_return}");
          }
          if(_auxLength==3)
          {
                 while (_auxItem!=0)
          {
            _return+='C';
            _auxItem--;
           } 
           Console.WriteLine($"C: {_return}");
                }
          if(_auxLength==2)
            {
             _auxConvert= ConvertBasicRoman(int.Parse(item.ToString()));
                        _return+=_auxConvert; 
            }
          if(_auxLength==1)
          {
             _auxConvert= ConvertBasicRoman(int.Parse(item.ToString()));
                        _return+=_auxConvert; 
                        Console.WriteLine($"basic : {_return}");
                      }
                         _auxLength--;
        }
        Console.WriteLine($"_return: {_return}");
        return _return;
    }
static string ConvertBasicRoman(int n){ 
      string _return="";
        if (n.Equals(1)) _return="I";
        if (n.Equals(2)) _return="II";
        if (n.Equals(3)) _return="III";
        if (n.Equals(4)) _return="IV";
        if (n.Equals(5)) _return="V";
        if (n.Equals(6)) _return="VI";
        if (n.Equals(7)) _return="VII";
        if (n.Equals(8)) _return="VIII";
        if (n.Equals(9)) _return="IX";
        if (n.Equals(10)) _return="X";
        return _return;
        }
static int ConvertBasicRoman(string romanNumeral){ 
      int _return=-1;
    if (romanNumeral.Equals("I")) _return=1;
        if (romanNumeral.Equals("II")) _return=2;
        if (romanNumeral.Equals("III")) _return=3;
        if (romanNumeral.Equals("IV")) _return=4;
        if (romanNumeral.Equals("V")) _return=5;
        if (romanNumeral.Equals("VI")) _return=6;
        if (romanNumeral.Equals("VII")) _return=7;
        if (romanNumeral.Equals("VIII")) _return=8;
        if (romanNumeral.Equals("IX")) _return=9;
        if (romanNumeral.Equals("X")) _return=10;
        return _return;
        }
    public static int FromRoman(string romanNumeral)
    {
       string? _auxString=null;
      string _auxToUpper=romanNumeral.ToUpperInvariant();
    int _return=0;
      int _auxConvertBasicRoman=ConvertBasicRoman(romanNumeral);
      if(  _auxConvertBasicRoman!=-1) return _auxConvertBasicRoman;
                
        foreach (var item in romanNumeral)
        {
            switch (item)
            {
            case 'L':
                _auxString+=50;
                break;

            case 'C':
                _auxString+=100;
                break;

            case 'D':
                _auxString+=500;
                break;
                
                case 'M':
                _auxString+=1000;
                break;

                default:
                
                ;
                break;
            }
        }
        var _q= (from z in romanNumeral select z) ;
        return _return;
    }
  }
    public class PyramidSlideDown
{
    //Todo | 1- search the elementary iterate in every tree node | 2- per level edentify , the max and min | 3 - sum teh max level to a total var 
    public static int LongestSlideDown(int[][] pyramid)
    {
        int _totalReturn=0;
        int _max=0;
        int[] _pyramid;
        List<int>  _auxList;
        for (int i = 0; i < pyramid.GetLength(0); i++)//iterate in rows 
        {
                Console.WriteLine($"pyramid.GetLength(0):  {pyramid.GetLength(0)}");
                _auxList=pyramid[i].ToList();
                Console.WriteLine($"pyramid.GetLength(0):  {pyramid.GetLength(1)}");
                foreach (var item in _auxList)
                {
                    if (_max<item)
                    {
                        _max=item;
                    }
                Console.WriteLine($"max:  {_max}");
                }
            _totalReturn+=_max;
        }
                Console.WriteLine($"mas:  {_totalReturn}");
            return _totalReturn;
    }
}

    class Program
    {
        public static int Add(int pOne, int pTwo) => (pOne+pTwo);

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            OperatingSystem _os=Environment.OSVersion;
            Console.WriteLine(_os.Platform+Environment.NewLine+_os.ServicePack+Environment.NewLine+_os.Version);
            // /home/telmosantos/.dotnet/
        }
    }
}
