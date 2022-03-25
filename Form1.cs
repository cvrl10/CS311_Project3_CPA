namespace CS311_Project3_CPA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Summarize()
        {
            String selections = (String)cboSize.SelectedItem;
            decimal subTotal = Price(selections);
            CheckBox[] ckb = {ckbPepperoni,
                                ckbSausage,
                                ckbCanadianBacon,
                                ckbSpicyItalianSausag,
                                ckbOnion,
                                cbkGreenPeper,
                                ckbBlackOlives,
                                ckbGreenOlives,
                                ckbBananaPeppers,
                                ckbJalapeno,
                                ckbExtraCheese,
                                ckbMushroom};
            
            for (int i = 0; i < ckb.Length; i++)
                if (ckb[i].Checked)
                    subTotal += Price(ckb[i].Text);

            txtSubTotal.Text = subTotal.ToString("C");
            decimal tax = 0.06m * subTotal;
            txtTax.Text = tax.ToString("C");
            txtTotal.Text = (subTotal+tax).ToString("C");

            if (selections == null)
                selections = "You ordered a pizza";
            else
                selections = $"You ordered a {selections} pizza";

            if (rdoThin.Checked)
                selections += $" with {rdoThin.Text} crust and";
            else if (rdoThick.Checked)
                selections += $" with {rdoThick.Text} crust and";
            else if (rdoRegular.Checked)
                selections += $" with {rdoRegular.Text} crust and";
            else
                selections += " and";

            rtfSummary.Text = selections;

            for (int i = 0; i < ckb.Length; i++)
                if (ckb[i].Checked)
                    rtfSummary.AppendText($"\n{ckb[i].Text}");
        }//end Summarize
        private decimal Price(String selection)
        {
            switch (selection)
            {
                case "Small":
                case "Pepperoni":
                case "Sausage":
                case "Canadian Bacon":
                case "Spicy Italian Sausage":
                    return 2.00m;
                case "Medium":
                    return 5.00m;
                case "Large":
                    return 10.00m;
                case "X-Large":
                    return 15.00m;
                case "Ginormous":
                    return 20.00m;
                case null:
                    return 0.00m;
                default:
                    return 1.00m;
            }
        }//end Price

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            Summarize();
        }//end btnCalculate_Click
    }
}