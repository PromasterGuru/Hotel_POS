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
using System.Security.Cryptography;
using MySql.Data.MySqlClient;
namespace Home
{
    public partial class MDImain : Form
    {
        private int childFormNumber = 0;
        Double value = 0.00;
        String operation = "";
        Boolean operation_pressed = false;

        public MDImain()
        {
            InitializeComponent();
           string role = cborole.Text;
            string uname = txtuname.Text;
            timer1.Start();
            //DataGridView Properties
            dgvmenu.ColumnCount = 4;
            dgvmenu.Columns[0].Name = "ID";
            dgvmenu.Columns[1].Name = "NAME";
            dgvmenu.Columns[2].Name = "Qty";
            dgvmenu.Columns[3].Name = "PRICE";
            dgvmenu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //DataGridView Selection mode
            dgvmenu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvmenu.MultiSelect = false;
            cborole.Items.Add("User");
            cborole.Items.Add("Admin");
        }
        static string encrypt(string value)
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] data = md5.ComputeHash(utf8.GetBytes(value));
                return Convert.ToBase64String(data);
            }
        }
        string str = "Server=localhost;Database=promaster;Uid=promaster;Pwd=promaster2016";
        MySqlConnection con;
        MySqlCommand cmd;
        DataTable dt = new DataTable();
        MySqlDataAdapter adapter;
        //Retrieve data from database to DataGridView
        private void populate(string id, string name, string quantity, string price)
        {
            dgvmenu.Rows.Add(id, name, quantity, price);
        }
        private void retrieve()
        {
            con = new MySqlConnection(str);
            string sql = "select*from menu";
            cmd = new MySqlCommand(sql, con);
            try
            {
                con.Open();
                adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    populate(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString());
                }

                con.Close();
                dt.Rows.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
            private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void MDImain_Load(object sender, EventArgs e)
        {
            cborole.SelectedIndex = 0;
            try
            {
                retrieve();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnlog_Click(object sender, EventArgs e)
        {
            if (txtuname.Text == "")
            {
                MessageBox.Show("Please fill in your username");
                txtuname.Focus();
                return;
            }
            /*if (txtpword.Text == "")
            {
                MessageBox.Show("Please fill in your password");
                txtpword.Focus();
                return;
            }*/
            else
            {
                con = new MySqlConnection(str);
                string en = encrypt(txtpword.Text);
                string q = "select*from workers where(Role='" + cborole.Text + "' && Username='" + txtuname.Text + "' && Password='" + en + "')";
                 try
                {
                    con.Open();
                    cmd = new MySqlCommand(q, con);
                    adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                     if (dt.Rows.Count == 1)
                    {
                     lblmessage.Text = "";
                     MessageBox.Show("Login Successifull");
                     MDImain mdi = new MDImain();
                     fmmanage frm = new fmmanage(txtuname.Text,cborole.Text);
                        frm.StartPosition = FormStartPosition.CenterScreen;
                       mdi.Show();
                       this.Hide();
                         frm.Show();
                        txtuname.Clear();
                        txtpword.Clear();
                    }
                    else if (dt.Rows.Count > 1) {
                        lblmessage.ForeColor = Color.Red;
                        lblmessage.Text = "Your account is hacked";
                    }
                    else
                    {
                        lblmessage.ForeColor = Color.Red;
                        lblmessage.Text = "Wrong Username or Password";
                        txtpword.Clear();
                        return;
                    }
                    con.Close();
                }
                catch (Exception x)
                {
                    MessageBox.Show("Table not found" + x.Message);
                }
            }
        }
            private void btncancel_Click(object sender, EventArgs e)
        {
            txtuname.Clear();
            txtpword.Clear();
        }
        private void button12_Click(object sender, EventArgs e)
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
                    lblequation.Text = value + "" +operation;
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


        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            this.lbltime2.Text = time.ToString();
            Random rand = new Random();
            int A = rand.Next(0, 255);
            int R = rand.Next(0, 255);
            int G = rand.Next(0, 255);
            int B = rand.Next(0, 255);
            this.lblblink.ForeColor = Color.FromArgb(A, R, G, B);
        }
        private void clear_Click(object sender, EventArgs e)
        {

            txtresult.Text = "0";
            value = 0;
        }


        private void btnbutton(object sender, EventArgs e)
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

        private void button6_Click(object sender, EventArgs e)
        {
            fmorder fm = new fmorder(txtuname.Text);
            fm.StartPosition = FormStartPosition.CenterScreen;
            fm.Show();
          }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void gpblogin_Enter(object sender, EventArgs e)
        {

        }
    }
}