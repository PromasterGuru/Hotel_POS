using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Data.Sql;
using MySql.Data.MySqlClient;

namespace Home
{
    public partial class AddUsers : Form
    {
  
        public AddUsers()
        {
            InitializeComponent();
         }
        string connection = "Server=localhost;Database=promaster;Uid=promaster;Pwd=promaster2016";
        MySqlConnection con;
        MySqlCommand cmd;
        DataTable dt = new DataTable();
        private void button3_Click(object sender, EventArgs e)
        {
            ViewWorkers fm = new ViewWorkers();
            fm.StartPosition = FormStartPosition.CenterScreen;
            fm.Show();
            this.Hide();
        }
       static string encript(string value)
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider()) {
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] data = md5.ComputeHash(utf8.GetBytes(value));
                return Convert.ToBase64String(data);
            }

        }
        public void clear()
        {
            lblemail.Text = "Email";
            lblidno.Text = "IDNo";
            lbltelno.Text = "TelNo";
            lbluname.Text = "Username";
            lblpword.Text = "Password";
            lblcpword.Text = "Username";
            txtemail.Text = "";
            txtidno.Text = "";
            txttelno.Text = "";
            txtuname.Text = "";
            txtpass.Text = "";
            txtcpword.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            txtrole.Text = "User";
             if (txtemail.Text == "")
            {
                lblemail.ForeColor = Color.Red;
                lblemail.Text = "Enter email";
                return;
            }
            if (txtidno.Text == "")
            {
                lblidno.ForeColor = Color.Red;
                lblidno.Text = "Enter IDNo";
                return;
            }
            if (txttelno.Text == "")
            {
                lbltelno.ForeColor = Color.Red;
                lbltelno.Text = "Enter TelNo";
                return;
            }
            if (txtuname.Text == "")
            {
                lbluname.ForeColor = Color.Red;
                lbluname.Text = "Enter Username";
                return;
            }
            if (txtpass.Text == "")
            {
                lblpword.ForeColor = Color.Red;
                lblpword.Text = "Enter password";
                return;
            }
            if (txtpass.Text == "")
            {
                lblcpword.ForeColor = Color.Red;
                lblcpword.Text = "Confirm password";
                return;
            }
            if (txtpass.Text !=txtcpword.Text)
            {
                lblmessage.Text = "Your Password does not match";
                return;
            }
            else
            {
                string en = encript(txtpass.Text);
                con = new MySqlConnection(connection);
                 string query = "insert into workers values('','" + txtrole.Text + "','" + txtemail.Text + "','" + txtidno.Text + "','" + txttelno.Text + "','" + txtuname.Text + "','" + en + "')";
                try
                {
                    con.Open();
                    cmd = new MySqlCommand(query, con);
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        lblmessage.Text = "You have successifully added new " + txtrole.Text;
                        clear();                        
                      }
                    else
                    {
                        lblmessage.Text = "Failed to add new user";
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clear();
        }
    }
}
