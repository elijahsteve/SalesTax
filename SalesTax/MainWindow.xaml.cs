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
