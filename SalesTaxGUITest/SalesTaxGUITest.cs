using FluentAssertions;
using FlaUI.UIA3;
using FlaUI.Core.AutomationElements;
using NUnit.Framework;

namespace GUITest
{
    [TestFixture]
    public class SalesTaxGUITest
    {
        //Window Variables
        private FlaUI.Core.Application app;
        private UIA3Automation Automation = new UIA3Automation();
        private Window window;

        //Controls
        private TextBox txtAmount;
        private CheckBox chkCountyTax;
        private Button btnCalculate;
        private ListBoxItem[] lstInitialItems;
        private ListBox lstTotal;

        [OneTimeSetUp]
        public void Setup()
        {
            app = FlaUI.Core.Application.Launch("SalesTax.exe");
            Automation = new UIA3Automation();
            window = app.GetMainWindow(Automation);

            txtAmount = window.FindFirstDescendant(cf => cf.ByAutomationId("txtAmount"))?.AsTextBox();
            chkCountyTax = window.FindFirstDescendant(cf => cf.ByAutomationId("chkCountyTax"))?.AsCheckBox();
            btnCalculate = window.FindFirstDescendant(cf => cf.ByAutomationId("btnCalculate"))?.AsButton();
            lstTotal = window.FindFirstDescendant(cf => cf.ByAutomationId("lstTotal"))?.AsListBox();
            lstInitialItems = lstTotal.Items;
        }

        [Test]
        public void HappyNoCountyTax()
        {
            // Set up test variables
            string input1 = "100";
            string expected = "Total Amount: $104.00";
            var message = $"'{input1}' multiplied by the state tax rate should be {expected}";

            // Peforms automation tasks/events
            txtAmount.Text = "";
            txtAmount.Enter(input1);

            chkCountyTax.IsChecked = false;
            btnCalculate.Click();

            // Pull the result
            var currentItems = lstTotal.Items;
            var result = currentItems[currentItems.Length - 1].Name;


            // Verify result            
            result.Should().Be(expected, because: message);
        }

        [Test]
        public void HappyCountyTax()
        {
            // Set up test variables
            string input1 = "100";
            string expected = "Total Amount: $106.00";
            var message = $"'{input1}' multiplied by the state and county tax rate should be {expected}";

            // Peforms automation tasks/events
            txtAmount.Text = "";
            txtAmount.Enter(input1);
            chkCountyTax.IsChecked = true;
            btnCalculate.Click();

            // Pull the result
            var currentItems = lstTotal.Items;
            var result = currentItems[currentItems.Length - 1].Name;

            // Verify result
            result.Should().Be(expected, because: message);
        }

        [Test]
        public void SadNoCountyTax()
        {
            // Set up test variables
            string input1 = "a";
            string expected = "Total Amount: $0.00";
            string expected2 = "Error";

            var message = $"'{expected}' in lbi.TotalAmount because '{input1}' is not a valid input";
            var message2 = $"'{expected2}' in txt.Amount because '{input1}' is not a valid input";

            // Peforms automation tasks/events
            txtAmount.Text = "";
            txtAmount.Enter(input1);
            chkCountyTax.IsChecked = false;
            btnCalculate.Click();

            // Pull the result
            var currentItems = lstTotal.Items;

            var result = currentItems[currentItems.Length - 1].Name;

            // Verify result

            result.Should().Be(expected, because: message);
            txtAmount.Text.Should().Be(expected2, because: message2);
        }

        [Test]
        public void SadCountyTax()
        {
            // Set up test variables
            string input1 = "a";
            string expected = "Total Amount: $0.00";
            string expected2 = "Error";
            var message = $"'{input1}' multiplied by the state and county tax rate should be {expected}";
            var message2 = $"'{expected2}' in txt.Amount because '{input1}' is not a valid input";

            // Peforms automation tasks/events
            txtAmount.Text = "";
            txtAmount.Enter(input1);
            chkCountyTax.IsChecked = true;
            btnCalculate.Click();

            // Pull the result
            var currentItems = lstTotal.Items;
            var result = currentItems[currentItems.Length - 1].Name;

            // Verify result
            result.Should().Be(expected, because: message);
            txtAmount.Text.Should().Be(expected2, because: message2);
        }

        //may not be in correct order
        [OneTimeTearDown]
        public void TearMe()
        {
            Automation.Dispose();
            window.Close();
            app.Close();
        }

    }
}
