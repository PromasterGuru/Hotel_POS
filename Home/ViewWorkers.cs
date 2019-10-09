using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Home
{
    public partial class ViewWorkers : Form
    {
        public ViewWorkers()
        {
            InitializeComponent();
              cborole.Items.Add("User");
              cborole.Items.Add("Admin");
           
        }
        string connection = "Server=localhost;Database=promaster;Uid=promaster;Pwd=promaster2016";
        MySqlConnection con;
        MySqlCommand cmd;
        DataTable dt = new DataTable();
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        private void retrieve()
        {
            con = new MySqlConnection(connection);
            string query = "select ID,Role,Email,IDNo,TelNo,Username from workers";
            try
            {
                con.Open();
                cmd = new MySqlCommand(query, con);
                dt = new DataTable();
                adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
                dgvworkers.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ViewWorkers_Load(object sender, EventArgs e)
        {
            retrieve();
        }
        private void clear()
        {
            cborole.SelectedText = "";
            txtemail.Text = "";
            txtidno.Text = "";
            txtuname.Text = "";
            txttelno.Text = "";
        }

        private void dgvworkers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblmessage.Text = "";
           cborole.Text =dgvworkers.SelectedRows[0].Cells[1].Value.ToString();
            txtemail.Text = dgvworkers.SelectedRows[0].Cells[2].Value.ToString();
            txtidno.Text = dgvworkers.SelectedRows[0].Cells[3].Value.ToString();
            txtuname.Text = dgvworkers.SelectedRows[0].Cells[4].Value.ToString();
            txttelno.Text = dgvworkers.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dgvworkers.Rows.Remove(dgvworkers.SelectedRows[0]);
                clear();
            }
            catch(Exception ex){
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string selected = dgvworkers.SelectedRows[0].Cells[0].Value.ToString();
            int getst = Convert.ToInt32(selected);
            string str = "update workers set Role='" + cborole.Text + "',Email='" + txtemail.Text + "',IDNo='" + txtidno.Text + "',TelNo='" + txttelno.Text + "',Username='" + txtuname.Text + "' where ID='"+getst+"'";
            con =new  MySqlConnection(connection);
            try
            {
                con.Open();
                cmd = new MySqlCommand(str,con);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    lblmessage.ForeColor = Color.Red;
                    lblmessage.Text = "Record Successifully updated";
                    dt.Rows.Clear();
                    retrieve();
                    clear();
                }
                con.Close();
            }
            catch(Exception ex){
                MessageBox.Show(ex.Message);
            }
        }
    }
}
