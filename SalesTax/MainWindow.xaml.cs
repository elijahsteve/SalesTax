using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static SalesTax.Validator;
using static SalesTax.Calculate;

namespace SalesTax
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            // Create a GUI named "SalesTax.exe" that will be used to calculate the total dollar amount of a purchase.
            // This GUI should include a button that will perform all the calculations.
            // The State Tax amount is 4% & the County Tax is 2%.    
            // Try to match the created GUI to the provided example GUI as much as possible.

            // In total, the GUI will have the following...
            // 1 label named "lblSalesAmount"
            // 1 textbox named "txtAmount"
            // 1 checkbox named "chkCountyTax"
            // 1 button named "btnCalculate"
            // 1 listbox named "lstTotal"

            // the listbox will include the following items...
            // "lbiSalesAmount"
            // "lbiStateTax"
            // "lbiCountyTax"
            // "lbiTotalTax"
            // "lbiTotalAmount"

            // The textbox should accept a valid positve number as an input.
            // If the input is not a valid positive number, the textbox should instead read "Error".

            // WARNING - IF YOU DO NOT NAME THESE OBJECTS EXACTLY AS ABOVE YOU WILL NOT BE ABLE TO PASS THE TESTS
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            updateValue(lbiSalesAmount, 0d);
            updateValue(lbiStateTax, 0d);
            updateValue(lbiCountyTax, 0d);
            updateValue(lbiTotalTax, 0d);
            updateValue(lbiTotalAmount, 0d);

            var isValid = ValidIsNumber(txtAmount.Text, out var amount);
            if (isValid)
            {
                // variables for the listboxitem inputs
                var statetaxamount = Calculate.GetStateTax(amount);
                var counttaxamount = chkCountyTax.IsChecked == true ? Calculate.GetCountyTax(amount) : 0d;
                var totalsalestax = Calculate.GetTotalSalesTax(amount, chkCountyTax.IsChecked == true);
                var total = Calculate.GetTotal(amount, chkCountyTax.IsChecked == true);

                // changing the text of the listboxitems
                updateValue(lbiSalesAmount, amount);
                updateValue(lbiStateTax, statetaxamount);
                updateValue(lbiCountyTax, counttaxamount);
                updateValue(lbiTotalTax, totalsalestax);
                updateValue(lbiTotalAmount, total);
            }
            else
            {
                txtAmount.Text = "Error";
            }
            txtAmount.Focus();
        }
    }
}
