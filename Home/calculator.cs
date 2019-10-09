using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Home
{
    public partial class calculator : Form
    {
        Double value = 0.00;
        String operation = "";
        Boolean operation_pressed = false;
        public calculator()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            if ((txtresult.Text == "0") || (operation_pressed))
            {
                txtresult.Clear();
                operation_pressed = false;
            }
            Button b = (Button)sender;
            if (b.Text == ".")
            {
                if (!txtresult.Text.Contains("."))
                    txtresult.Text = txtresult.Text + b.Text;
            }
            else
                txtresult.Text = txtresult.Text + b.Text;
        }
        private void button12_Click(object sender, EventArgs e)
        {
            txtresult.Text = "0";
            value = 0;
        }
         private void button15_Click(object sender, EventArgs e)
        {
            txtresult.Text = "0";
            value = 0;
        }

        private void operator_click(object sender, EventArgs e)
        {
            try
            {
                Button b = (Button)sender;
                if (value != 0)
                {
                    equals.PerformClick();
                    operation_pressed = true;
                    operation = b.Text;
                    lblequation.Text = value + " " + operation;
                }
                operation = b.Text;
                value = Double.Parse(txtresult.Text);
                operation_pressed = true;
                lblequation.Text = value + " " + operation;
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        
        }

        private void button16_Click(object sender, EventArgs e)
        {

            try
            {
                lblequation.Text = " ";
                switch (operation)
                {
                    case "+":
                        txtresult.Text = (value + Double.Parse(txtresult.Text)).ToString();
                        break;
                    case "-":
                        txtresult.Text = (value - Double.Parse(txtresult.Text)).ToString();
                        break;
                    case "x":
                        txtresult.Text = (value * Double.Parse(txtresult.Text)).ToString();
                        break;
                    case "/":
                        txtresult.Text = (value / Double.Parse(txtresult.Text)).ToString();
                        break;
                }
                value = Double.Parse(txtresult.Text);
                operation = "";//end switch
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
