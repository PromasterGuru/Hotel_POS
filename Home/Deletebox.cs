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
namespace Home
{
    public partial class Deletebox : Form
    {
        public Deletebox(string message)
        {
            InitializeComponent();
            message = lblmessage.Text;
        }
      //  String str = "Server=localhost;Database=promaster;Uid=promaster;Pwd=promaster2016";
        string str = "Server=localhost;Database=promaster;Uid=promaster;Pwd=promaster2016";
        MySqlConnection con;
        MySqlCommand cmd;
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con = new MySqlConnection(str);
            string query = "delete from sales";
            try
            {
                con.Open();
                cmd = new MySqlCommand(query,con);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    lblmessage.ForeColor = Color.Blue;
                    lblmessage.Text = "You have successifully deleted all previous sales Records";
                    button1.Hide();
                    button2.Text = "EXIT";
                }
                else if (cmd.ExecuteNonQuery() == 0)
                {
                    lblmessage.ForeColor = Color.Red;
                    lblmessage.Text = "No sales record found to delete";
                    button1.Hide();
                    button2.Text = "EXIT";
                }
                else {
                    lblmessage.Text = "An error occured when deleting sales records";
                    button1.Text="Try Again";
                    button2.Text = "EXIT";
                }
                con.Close();
            }
            catch(Exception ex){
                MessageBox.Show(ex.Message);
            }
                  }
    }
}
