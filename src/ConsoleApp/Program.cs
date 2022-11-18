using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int x ;
            int y ;
            int z;

            x = 1;
            y = 1;

            MyMath myMath = new MyMath();
            z = myMath.Add(x,y);

            
            Console.WriteLine(z);

            double d = 1024;
            NumberFormatUtility numberFormatUtility = new NumberFormatUtility();
            string numberFormat = numberFormatUtility.FormatNumber(d);

            Console.WriteLine(numberFormat);

            Console.ReadKey();
        }
    }
}
