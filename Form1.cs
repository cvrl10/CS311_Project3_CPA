namespace CS311_Project3_CPA
{
    using System.Collections.Generic;
    using Properties;
    public partial class Form1 : Form
    {
        Dictionary<String, decimal> price;
        public Form1()
        {
            InitializeComponent();
            pictBox.Image = Resources.ResourceManager.GetObject("27577") as Image;
            price = new Dictionary<string, decimal>() {{"Small", 2.00m},
                                                       {"Pepperoni", 2.00m},
                                                       {"Sausage", 2.00m},
                                                       {"Canadian Bacon", 2.00m},
                                                       {"Spicy Italian Sausage", 2.00m},
                                                       {"Medium", 5.00m},
                                                       {"Large", 10.00m},
                                                       {"X-Large", 15.00m},
                                                       {"Ginormous", 20.00m}};

        }//end empty-argument constructor 

        //totals up the order based on the selections and writes a summary to the rich text box
        private void Summarize()
        {
            String selections = (String)cboSize.SelectedItem;
            decimal subTotal;

            if (selections != null)
            {
                subTotal = price[selections];
                selections = $"You ordered a {selections} pizza";
            }
            else
            {
                subTotal = 0.00m;
                selections = "You ordered a pizza";
            }

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

            //adding the prices of the toppings that are not already in the dictionary
            for (int i = 0; i < ckb.Length; i++)
                if (!price.ContainsKey(ckb[i].Text))
                    price.Add(ckb[i].Text, 1.00m);

            for (int i = 0; i < ckb.Length; i++)
                if (ckb[i].Checked)
                    subTotal += price[ckb[i].Text];

            txtSubTotal.Text = subTotal.ToString("C");
            decimal tax = 0.06m * subTotal;
            txtTax.Text = tax.ToString("C");
            txtTotal.Text = (subTotal + tax).ToString("C");

            if (rdoThin.Checked)
                selections += $" with {rdoThin.Text} crust and the following toppings:";
            else if (rdoThick.Checked)
                selections += $" with {rdoThick.Text} crust and the following toppings:";
            else if (rdoRegular.Checked)
                selections += $" with {rdoRegular.Text} crust and the following toppings:";
            else
                selections += " and";

            rtfSummary.Text = selections;

            for (int i = 0; i < ckb.Length; i++)
                if (ckb[i].Checked)
                    rtfSummary.AppendText($"\n{ckb[i].Text}");
      
        }//end Summarize

        //Event handler for btnCalculate_Click event Click
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            Summarize();
        }//end btnCalculate_Click
    }//end partial class
}//end namespace