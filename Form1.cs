using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hello2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DefaultZeros();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CalculateInvestment();
        }

        public void DefaultZeros()
        {
            initialBox.Text = "10000";
            additionalBox.Text = "0";
            totalTimeBox.Text = "10";
            listBox1.SelectedIndex = listBox1.TopIndex;
            returnRateBox.Text = "7";
        }
        public void CalculateInvestment()
        {

            double total = 0.0;
            try { total = double.Parse(initialBox.Text); }
            catch { total = 0.0; MessageBox.Show("No initial value"); }


            try
            {
                //increment by using the amount of money from TextBox
                if (listBox1.SelectedIndex == listBox1.TopIndex)
                {
                    for (int i = 1; i <= int.Parse(totalTimeBox.Text); i++)
                    {
                        total = total * (1 + (double.Parse(returnRateBox.Text)/100)) + double.Parse(additionalBox.Text);
                    }
                }

                //for monthly deposits/adjustments
                if (listBox1.SelectedIndex != listBox1.TopIndex)
                {
                    for (int i = 1; i <= int.Parse(totalTimeBox.Text) * 12; i++)
                    {
                        total = total * (1 + (double.Parse(returnRateBox.Text) / 100 / 12)) + double.Parse(additionalBox.Text);
                    }
                }
            }

            catch
            {
                MessageBox.Show("You forgot to add some values in the fields");
            }

            //Display total value and the one using 4% rule
            void ShowResult()
            {
                label7.Text = "$ " + total.ToString("0.00");
                label8.Text = "$ " + (total * 0.04 / 12).ToString("0.00");
            }

            ShowResult();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            //nothing
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != listBox1.TopIndex)
            {
                label2.Text = "Additional investment a month";
            }

            if (listBox1.SelectedIndex == listBox1.TopIndex)
            {
                label2.Text = "Additional investment a year";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show("This software allows you to calculate what monthly income you can expect to get in X years.\n" +
                "1. Type your initial amount that is already in your accounts.\n2. Then figure out how much do you put every Month/Year.\n" +
                "Typical return rate for stock market is 7% (it is a default value). Bond market return is around 3-4%.");
        }
    }
}
