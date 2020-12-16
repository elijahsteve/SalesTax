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

namespace SalesTax
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ItemCollection InitialItems;

        public MainWindow()
        {
            InitializeComponent();
            InitialItems = lstTotal.Items;
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            lstTotal.Items.Clear();
            lstTotal.Items.Add(InitialItems);

            var isValid = ValidIsNumber(txtAmount.Text, out var outAmount);
            if (isValid)
            {

            }
            else
            {

            }
        }
    }
}
