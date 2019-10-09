using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
namespace Home
{
    public partial class fmmanage : Form
    {
              
        public fmmanage(string uname,string role)
        {
            InitializeComponent();
            lblrole.Text = role;
            lbluname.Text = uname;
            if (lblrole.Text == "User")
            {
                button5.Enabled = false;
                button8.Enabled = false;
            }
            timer1.Start();
            }
        static string encrypt(string value){
            using (MD5CryptoServiceProvider mdp = new MD5CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] data = mdp.ComputeHash(utf8.GetBytes(value));
                return Convert.ToBase64String(data);
            }
        
        }
        string str = "Server=localhost;Database=promaster;Uid=promaster;Pwd=promaster2016";
        MySqlConnection con;
        MySqlCommand cmd;
        DataTable dt = new DataTable();
        MySqlDataAdapter adapter;
        private void clear()
        {
            txtname.Clear();
            txtquantity.Clear();
            txtprice.Clear();
            lblname.Text= "";
            lblprice.Text = "";
            lblquantity.Text="";
        }
       private void retrieve()
        {
            con = new MySqlConnection(str);
            string sql = "select*from menu";
                       try
            {
                con.Open();
                cmd = new MySqlCommand(sql,con);
                adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
                dgvmenu2.DataSource = dt;
                con.Close();
            }
           catch(Exception ex){
               MessageBox.Show(ex.Message);
           }
        }
        public void update()
       {

           if (txtname.Text == "")
           {
               lblname.ForeColor = Color.Red;
               lblname.Text = "enter food name";
               txtname.Focus();
               return;
           }
           else
           {
               lblmessage.Text="";
               }
           if (txtquantity.Text == "")
           {
               lblname.Text = "";
               lblquantity.ForeColor = Color.Red;
               lblquantity.Text = "enter food quantity";
               txtquantity.Focus();
               return;
           }
           if (txtprice.Text == "")
           {
               lblquantity.Text = "";
               lblprice.ForeColor = Color.Red;
               lblprice.Text = "enter food price";
               txtprice.Focus();
               return;
           }
           else
           {
               string selected = dgvmenu2.SelectedRows[0].Cells[0].Value.ToString();
               int id = Convert.ToInt32(selected);
               string sql = "Update menu set NAME='" + txtname.Text + "',QUANTITY='" + txtquantity.Text + "',PRICE='" + txtprice.Text + "' where ID='" + id + "'";
               con = new MySqlConnection(str);
               try
               {
                   con.Open();
                   cmd = new MySqlCommand(sql, con);
                   if (cmd.ExecuteNonQuery() > 0)
                   {

                       dt.Rows.Clear();
                       retrieve();
                       lblmessage.ForeColor = Color.Blue;
                       lblmessage.Text = "Record successifully updated";
                       clear();
                   }
                   con.Close();
               }
               catch (Exception ex)
               {
                   MessageBox.Show(ex.Message);
               }
           }
       }
              private void add()
        {

            if (txtname.Text == "")
            {
                lblname.ForeColor = Color.Red;
                lblname.Text = "enter food name";
                txtname.Focus();
                return;
            }
            if (txtquantity.Text == "")
            {
                lblname.Text = "";
                lblquantity.ForeColor = Color.Red;
                lblquantity.Text = "enter food quantity";
                txtquantity.Focus();
                return;
            }
            if (txtprice.Text == "")
            {
                lblquantity.Text = "";
                lblprice.ForeColor = Color.Red;
                lblprice.Text = "enter food price";
                txtprice.Focus();
                return;
            }
            else
            {
                try
                {
                    con = new MySqlConnection(str);
                    con.Open();
                    //String dn = txtname.Text;
                   // string en = encrypt(dn);
                    string q = "insert into menu values('','" +txtname.Text + "','" +txtquantity.Text+ "','" + txtprice.Text + "')";
                    cmd = new MySqlCommand(q, con);
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        dt.Rows.Clear();
                        retrieve();
                        lblmessage.ForeColor = Color.Green;
                        lblmessage.Text = "Record added";
                        clear();
                    }

                }
                catch (Exception x)
                {
                    MessageBox.Show("Record not added" + x.Message);
                }
            }
        }        private void frmmain_Load(object sender, EventArgs e)
        {
            try
            {
                retrieve();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
           add();
        }

        private void txtname_KeyPress(object sender, KeyPressEventArgs e)
        {
            lblmessage.Text = "";
        }
        private void button4_Click_1(object sender, EventArgs e)
        {
            con = new MySqlConnection(str);
            try
            {
            string selected=dgvmenu2.SelectedRows[0].Cells[0].Value.ToString();
            int id=Convert.ToInt32(selected);
            string query = "Delete from menu where ID='"+id+"'";
            dt.Rows.Clear();
            con.Open();
            cmd = new MySqlCommand(query,con);
            if (cmd.ExecuteNonQuery()>0)
            {
                retrieve();
                lblmessage.ForeColor = Color.Blue;
                lblmessage.Text = "Record deleted";
                clear();
            }
            else
            {
                lblmessage.ForeColor = Color.Red;
                lblmessage.Text = "Failed to deleted";
                            }
            cmd = new MySqlCommand();
            con.Close();
                }
            catch(Exception ex){
                MessageBox.Show("Empty row selected" + ex.Message);
            }
           
        }
         private void button3_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void button2_Click(object sender, EventArgs e)
         {
           update();
        }

        private void dgvmenu2_MouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtname.Text = dgvmenu2.SelectedRows[0].Cells[1].Value.ToString();
            txtquantity.Text = dgvmenu2.SelectedRows[0].Cells[2].Value.ToString();
            txtprice.Text = dgvmenu2.SelectedRows[0].Cells[3].Value.ToString();
        }

      /*  private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime time =DateTime.Now;
            this.lbltime.Text = time.ToString();
            Random rand = new Random();
            int A = rand.Next(0, 255);
            int R = rand.Next(0, 255);
            int G = rand.Next(0, 255);
            int B = rand.Next(0, 255);
           this.lblblink.ForeColor=Color.FromArgb(A,R,G,B);
        }*/

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            fmorder frm = new fmorder(lbluname.Text);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
            this.Dispose();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AddUsers fm = new AddUsers();
            fm.StartPosition = FormStartPosition.CenterScreen;
            fm.Show();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            AddAdmins fm = new AddAdmins();
            fm.StartPosition = FormStartPosition.CenterScreen;
            fm.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ViewWorkers fm = new ViewWorkers();
            fm.StartPosition = FormStartPosition.CenterScreen;
            fm.Show();
        }

        private void btnsales_Click(object sender, EventArgs e)
        {
            sales sl = new sales(lbluname.Text,lblrole.Text,lblmessage.Text);
            sl.StartPosition = FormStartPosition.CenterScreen;
            sl.Show();
                              }

        private void button7_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            fmorder fm = new fmorder(lbluname.Text);
            fm.StartPosition = FormStartPosition.CenterScreen;
            fm.Show();
            this.Dispose();
        }

        private void button6_Click_2(object sender, EventArgs e)
        {
            fmorder fm = new fmorder(lbluname.Text);
            fm.StartPosition = FormStartPosition.CenterScreen;
            fm.Show();
                  }
                    }

          }