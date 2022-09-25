using System;
using System.Net;
using System.Text.RegularExpressions;

// This program shows how to use the IPAddress class to obtain a server
// IP addressess and related information.

using System;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;

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
          if(curAdd.AddressFamily.ToString() == ProtocolFamily.InterNetworkV6.ToString())
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
    long _returnTotalCount=-1;
      string server = null;

IPAddress _IPStart=null;
IPAddress _IPEnd=null;
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
        if( regex.Match(end).Success)
          Console.WriteLine("last IPaddress format allowed.");
    //   }
      // Get the list of the addresses associated with the requested server.
      IPAddresses(server);

      // Get additional address information.
      IPAddressAdditionalInfo();

      
      if (IPAddress.TryParse(start, out _IPStart)&&IPAddress.TryParse(end,out _IPEnd))
      {
        var _enumerableEnd= (from z in _IPEnd.ToString()
                    orderby z descending
                    select z).ToString().Split('.');
 var _enumerableStart=
    (from z in _IPEnd.ToString()
                    orderby z descending
                    select z).ToString()
                    .Split('.')
                    ;
                    
                    int _auxEnd=0;
                    Int32.TryParse(string.Join("", _enumerableEnd), out _auxEnd);
                    int _auxStart=0;
                    Int32.TryParse(string.Join("", _enumerableStart), out _auxStart);
                    _returnTotalCount=_auxEnd-_auxStart;
   }
   return _returnTotalCount;
   }

    public static void Main(string[] args)
    {
      string server = null;
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
    public class CountIPAddresses
{
   public static long IpsBetween(string start, string end)
   {
    int _returnTotalCount=-1;
IPAddress _IPStart=null;
IPAddress _IPEnd=null;
    if(IPAddress.TryParse(start,out _IPStart)&& IPAddress.TryParse(end,out _IPEnd)){
         var _auxIntIpEnd=BitConverter.ToInt32(_IPEnd.GetAddressBytes().Reverse().ToArray(), 0);
         var _auxIntIpStart=BitConverter.ToInt32(_IPStart.GetAddressBytes().Reverse().ToArray(), 0);
        if(_auxIntIpEnd<_auxIntIpStart)  
        _returnTotalCount=_auxIntIpStart-_auxIntIpEnd;
        else
        _returnTotalCount=_auxIntIpEnd-_auxIntIpStart;
    }
    return _returnTotalCount;
   }
   ///auxiliar method
   //logic  is to know the difference( subtract) the class D IP from 2 IP's
   public static long IpsBetween(string start, string end,bool token)
   {
 long _returnTotalCount=-1;

IPAddress _IPStart=null;
IPAddress _IPEnd=null;
         
      //TODO | 1- get last digits(class D of IP) | 2 - validate IPstart it's bigger than IPend
      if (IPAddress.TryParse(start, out _IPStart)&&IPAddress.TryParse(end,out _IPEnd))
      {
            var  _enumerableEnd=_IPEnd.ToString().Split('.');
            var  _enumerableStart=_IPStart.ToString().Split('.');
            int _auxEnd=0;
                    int _auxStart=0;
            try
            {
              if(Int32.TryParse( _enumerableEnd[3],out _auxEnd) && Int32.TryParse(_enumerableStart[3],out _auxStart) )//it's in the position 3 where is located the Class D IP
              {
                if (_auxStart>_auxEnd)
                {
                  _returnTotalCount=_auxStart-_auxEnd;
                }
                else
                _returnTotalCount=_auxEnd-_auxStart;
              }
            }
            catch (System.Exception e )
            {
              Console.WriteLine("Convertion error of Class D IP: "+ e.ToString());
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
