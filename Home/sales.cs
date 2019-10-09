using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing.Printing;

namespace Home
{
    public partial class sales : Form
    {
        public sales(string uname,string role,string message)
        {
            InitializeComponent();
            lblmessage.Text = message;
            lblrole.Text = role;
            lbluname.Text = uname;
            if (lblrole.Text == "User")
            {
                button2.Enabled = false;
            }
            dgvsales.ColumnCount = 5;
            dgvsales.Columns[0].Name = "Cashier";
            dgvsales.Columns[1].Name = "Food Name";
            dgvsales.Columns[2].Name = "Quantity";
            dgvsales.Columns[3].Name = "Total Price";
            dgvsales.Columns[4].Name = "DateTime";
        }
               
        string str = "Server=localhost; Database=promaster; Uid=promaster; Password=promaster2016";
        DataTable dt = new DataTable();
        MySqlConnection con;
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        MySqlCommand cmd;
        private void populate(string cashier,string foodname,string quantity,string totalprice,string time)
        {
            dgvsales.Rows.Add(cashier,foodname,quantity,totalprice,time);
        }
private void populate1(string cashier1,string totalprice1)
        {
            dgvsellers.Rows.Add(cashier1,totalprice1);
        }
private void cashexpected()
{
    con = new MySqlConnection(str);
   if (lblrole.Text == "User")
        {
          string cash = "select Cashier,SUM(TOTALCOST) AS TOTAL from sales where Cashier='"+lbluname.Text+"' GROUP BY Cashier";
            try
            {
                dt.Clear();
                con.Open();
                cmd = new MySqlCommand(cash, con);
                adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    dgvsellers.Rows.Add(row[0].ToString().ToUpper(), row[5].ToString() + ".00");
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
   else if (lblrole.Text == "Admin")
   {
       string cash = "select Cashier,SUM(TOTALCOST) AS TOTAL from sales GROUP BY Cashier";
       try
       {
           dt.Clear();
           con.Open();
           cmd = new MySqlCommand(cash, con);
           adapter = new MySqlDataAdapter(cmd);
           adapter.Fill(dt);
           foreach (DataRow row in dt.Rows)
           {
               dgvsellers.Rows.Add(row[0].ToString().ToUpper(), row[5].ToString() + ".00");
           }
           con.Close();
       }
       catch (Exception ex)
       {
           MessageBox.Show(ex.Message);
       }
   }
   else {
       MessageBox.Show("Ops! it seems you are new to the system \n Request a role from admin");
   }
        
    con = new MySqlConnection(str);
    string totalcash = "select SUM(TOTALCOST)from sales";
    try
    {
        dt.Clear();
        con.Open();
        cmd = new MySqlCommand(totalcash, con);
        adapter = new MySqlDataAdapter(cmd);
        adapter.Fill(dt);
        foreach (DataRow row in dt.Rows)
        {
            txtcash.Text = "   " + row[6].ToString() + ".00";
        }
        con.Close();
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
}
        private void sales_Load(object sender, EventArgs e)
        {
            gpdate.Hide();
            label1.Hide();
            label2.Hide();
            dateTimePicker1.Hide();
            dateTimePicker2.Hide();
            con = new MySqlConnection(str);
         if (lblrole.Text == "User")
         {
             lblexpectedcash.Hide();
             txtcash.Hide();
             string receipt = "select Cashier,FOODNAME,QUANTITY,TOTALCOST,TIME from sales where Cashier='" + lbluname.Text + "' ORDER BY DATETIME DESC ";
             try
             {
                 con.Open();
                 cmd = new MySqlCommand(receipt, con);
                 adapter = new MySqlDataAdapter(cmd);
                 adapter.Fill(dt);
                 foreach (DataRow row in dt.Rows)
                 {
                     populate(row[0].ToString(),row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString());
                  }
                   con.Close();
                   cashexpected();
                        }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
         }
       else if(lblrole.Text=="Admin")
         {
             string receipt = "select Cashier,FOODNAME,QUANTITY,TOTALCOST,DATETIME from sales ORDER BY DATETIME DESC";
             try
             {
               con.Open();
                 cmd = new MySqlCommand(receipt, con);
                 adapter = new MySqlDataAdapter(cmd);
                 adapter.Fill(dt);
                 foreach (DataRow row in dt.Rows)
                 {
                     populate(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString());
                 }
                 con.Close();
                 cashexpected();
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
         }
         else
         {
             MessageBox.Show("Invalid role \n contact Admin to update you details");
         }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lblmessage.Text = "";
       DialogResult= MessageBox.Show("Do you really want to delete all sales records","Please confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
        if (DialogResult==DialogResult.Yes)
        {
            con = new MySqlConnection(str);
            string query = "delete from sales";
            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    lblmessage.ForeColor = Color.Blue;
                    dgvsales.Rows.Clear();
                    lblmessage.Text = "You have successifully deleted all previous sales Records";
                }
                else if (cmd.ExecuteNonQuery() == 0)
                {
                    lblmessage.ForeColor = Color.Red;
                    lblmessage.Text = "No sales record found to delete";
                }
                else
                {
                    lblmessage.ForeColor = Color.Red;
                    lblmessage.Text = "An error occured when deleting sales records";
                                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gpdate.Show();
            label1.Show();
            label2.Show();
            dateTimePicker1.Show();
            dateTimePicker2.Show();
            }

        private void dateTimePicker2_MouseEnter(object sender, EventArgs e)
        {
            con = new MySqlConnection(str);
            string dateselect = "select Cashier,FOODNAME,QUANTITY,TOTALCOST,TIME from sales where Time=DateDiff('" + dateTimePicker1.Text + "','" + dateTimePicker2.Text + "') ORDER BY TIME DESC";
            try
            {
                con.Open();
                cmd = new MySqlCommand(dateselect, con);
                adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    populate(row[0].ToString(), row[2].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
            