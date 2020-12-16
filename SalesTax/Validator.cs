using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTax
{
    public static class Validator
    {
        public static bool ValidIsNumber(string str, out double number)
        {
            /*// bool for tryparse
            bool youIsNumber = double.TryParse(str.Trim(), out number);
            // ensures number is greater than zero
            if (number <= 0)
            {
                number = default;
                youIsNumber = false;
            }
            // returns the bool value of blnreturn which refers to the boolean variable of 
            // return which is referencing the return value of the tryparse that we created
            return youIsNumber;*/

            return double.TryParse(str.Trim(), out number) && number >= 0;
        }
    }
}
