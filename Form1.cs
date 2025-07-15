using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Order_Pizza
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        float PriceSize()
        {
            if(radioButton1.Checked) return Convert.ToSingle(radioButton1.Tag);
            else if(radioButton2.Checked) return Convert.ToSingle(radioButton2.Tag);
            else  return Convert.ToSingle(radioButton3.Tag);
        }

        float priceToppings()
        {
            float price = 0;
            if(checkBox1.Checked)  price += Convert.ToSingle(checkBox1.Tag);
            if(checkBox2.Checked)  price += Convert.ToSingle(checkBox2.Tag);
            if(checkBox3.Checked)  price += Convert.ToSingle(checkBox3.Tag);
            if(checkBox4.Checked)  price += Convert.ToSingle(checkBox4.Tag);
            if(checkBox5.Checked)  price += Convert.ToSingle(checkBox5.Tag);
            if(checkBox6.Checked)  price += Convert.ToSingle(checkBox6.Tag);
            return price;
        }

        float priceCrust()
        {
            if (radioButton6.Checked) return  Convert.ToSingle(radioButton6.Tag);
            else return Convert.ToSingle(radioButton7.Tag);
        }

        float TotalPrice()
        {
             return PriceSize() + priceToppings() + priceCrust();
        }

        void UpdateLabelPrice()
        {
            label13.Text = "$ " + TotalPrice().ToString();
        }
        private void radioButton_CheckedChanged(object sender,EventArgs e)
        {
            UpdateLabelPrice();
                if (radioButton1.Checked) label4.Text = "Small";
            if (radioButton2.Checked) label4.Text = "Medium";
            if (radioButton3.Checked) label4.Text = "Large";
            if(radioButton8.Checked)label12.Text = "Eat In";
            if(radioButton5.Checked)label12.Text = "Take Out";
            if(radioButton7.Checked)label11.Text = "Thin Crust";
            if(radioButton6.Checked)label11.Text = "Think Crust";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            radioButton2.Checked = true; 
            radioButton7.Checked = true;
            radioButton5.Checked = true;
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateLabelPrice();

            string Toppings = "";

            if (checkBox1.Checked) Toppings = "Chees Extra";
            if (checkBox2.Checked) Toppings += ", Mushrooms";
            if (checkBox3.Checked) Toppings += ", Tomatoes";
            if (checkBox4.Checked) Toppings += ", Onion";
            if (checkBox5.Checked) Toppings += ", Olives";
            if (checkBox6.Checked) Toppings += ", Green Pepper";
            if (Toppings.StartsWith(",")) Toppings = Toppings.Substring(1, Toppings.Length-1).Trim();
            if(Toppings == "") Toppings = "No Toppings";

            Toppings.Trim();
            label6.Text = Toppings;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Confirm Order","Confirm",MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question) == DialogResult.OK)
            {
                MessageBox.Show("Order Placed Successfully", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                button1.Enabled = false;
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                groupBox3.Enabled = false;
                groupBox4.Enabled = false;

            }
            else

                MessageBox.Show("Update your order", "Update",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            groupBox1.Enabled = true;
            groupBox2.Enabled = true;
            groupBox3.Enabled = true;
            groupBox4.Enabled = true;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            radioButton2.Checked = true;
            radioButton7.Checked = true;
        }
    }
}
