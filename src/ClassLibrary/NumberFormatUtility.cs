using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class NumberFormatUtility
    {
        public string FormatNumber(double number)
        {
            return number.ToString("#,##0");
        }
    }
}
