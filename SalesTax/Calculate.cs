using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTax
{
    public static class Calculate
    {      
        public static double GetStateTax(double amount)
        {
            return amount * .04;
        }

        public static double GetCountyTax(double amount)
        {
            return amount * .02;
        }

        public static double GetTotalSalesTax(double amount, bool countyTaxChecked)
        {
            return amount * (countyTaxChecked ?  0.06 : 0.04);
        }        

        public static double GetTotal(double amount, bool countyTaxChecked)
        {            
            return countyTaxChecked ? amount * 1.06 : amount * 1.04;
        }
    }
}
