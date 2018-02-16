using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
 

namespace marketmaker_cli
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args == null)
            {
                Console.WriteLine("args is null");
            }
            else
            {

                string Method = args[0];
                string KMD = args[1];
                string KMD_Address = args[2];


                Console.WriteLine("Method : " + Method);
                Console.WriteLine("KMD : " + KMD);
                Console.WriteLine("KMD_Address : " + KMD_Address);


                Program prg = new Program();
                prg.MarketMaker(Method, KMD, KMD_Address);
            }
            Console.ReadLine();


        }
        private void MarketMaker(string Balance, string KMD, string KMD_Address)
        {
            using (var client = new WebClient())
            {
                client.Headers.Add("Content-Type:application/json");
                client.Headers.Add("Accept:application/json");
                var result = client.DownloadString("http://ec2-52-221-176-76.ap-southeast-1.compute.amazonaws.com/AIWebAPI/Balance/balance.json");
                string correctString = result.Replace("RANyPgfZZLhSjQB9jrzztSw66zMMYDZuxQ", KMD_Address);
                Console.WriteLine(Environment.NewLine + correctString);
                Console.ReadLine();


            }
        }
    }
}
