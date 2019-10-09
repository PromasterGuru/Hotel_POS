using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace Home
{
    public partial class fmorder : Form
    {
        public fmorder(string uname)
        {
            InitializeComponent();
            lbluname.Text = uname;
           string cashier = lbluname.Text;
             timer1.Start();
            //DataGridView Properties
            dgvmenu3.ColumnCount = 4;
            dgvmenu3.Columns[0].Name = "ID";
            dgvmenu3.Columns[1].Name = "Name";
            dgvmenu3.Columns[2].Name = "Quantity";
            dgvmenu3.Columns[3].Name = "Price";
            dgvmenu3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //DataGridView Selection mode
            dgvmenu3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvmenu3.MultiSelect = false;
        }
     /*   public class PCPrint : System.Drawing.Printing.PrintDocument
        {
            #region  Property Variables
            /// <summary>
            /// Property variable for the Font the user wishes to use
            /// </summary>
            /// <remarks></remarks>
            private Font _font;
            /// <summary>
            /// Property variable for the text to be printed
            /// </summary>
            /// <remarks></remarks>
            private string _text;
            #endregion

            #region  Class Properties
            /// <summary>
            /// Property to hold the text that is to be printed
            /// </summary>
            /// <value></value>
            /// <returns>A string</returns>
            /// <remarks></remarks>
            public string TextToPrint
            {
                get { return _text; }
                set { _text = value; }
            }

            /// <summary>
            /// Property to hold the font the users wishes to use
            /// </summary>
            /// <value></value>
            /// <returns></returns>
            /// <remarks></remarks>
            public Font PrinterFont
            {
                // Allows the user to override the default font
                get { return _font; }
                set { _font = value; }
            }
            #endregion

            #region Static Local Variables
            /// <summary>
            /// Static variable to hold the current character
            /// we're currently dealing with.
            /// </summary>
            static int curChar;
            #endregion

            #region  Class Constructors
            /// <summary>
            /// Empty constructor
            /// </summary>
            /// <remarks></remarks>
            public PCPrint()
                : base()
            {
                //Set the file stream
                //Instantiate out Text property to an empty string
                _text = string.Empty;
            }

            /// <summary>
            /// Constructor to initialize our printing object
            /// and the text it's supposed to be printing
            /// </summary>
            /// <param name=str>Text that will be printed</param>
            /// <remarks></remarks>
            public PCPrint(string str)
                : base()
            {
                //Set the file stream
                //Set our Text property value
                _text = str;
            }
            #endregion
            #region  onbeginPrint
            /// <summary>
            /// Override the default onbeginPrint method of the PrintDocument Object
            /// </summary>
            /// <param name=e></param>
            /// <remarks></remarks>
            protected override void OnBeginPrint(System.Drawing.Printing.PrintEventArgs e)
            {
                // Run base code
                base.OnBeginPrint(e);

                //Check to see if the user provided a font
                //if they didn't then we default to Times New Roman
                if (_font == null)
                {
                    //Create the font we need
                    _font = new Font("Times New Roman", 10);
                }
            }
            #endregion
            #region  OnPrintPage
            /// <summary>
            /// Override the default OnPrintPage method of the PrintDocument
            /// </summary>
            /// <param name=e></param>
            /// <remarks>This provides the print logic for our document</remarks>
            protected override void OnPrintPage(System.Drawing.Printing.PrintPageEventArgs e)
            {
                // Run base code
                base.OnPrintPage(e);

                //Declare local variables needed

                int printHeight;
                int printWidth;
                int leftMargin;
                int rightMargin;
                Int32 lines;
                Int32 chars;

                //Set print area size and margins
                {
                    printHeight = base.DefaultPageSettings.PaperSize.Height - base.DefaultPageSettings.Margins.Top - base.DefaultPageSettings.Margins.Bottom;
                    printWidth = base.DefaultPageSettings.PaperSize.Width - base.DefaultPageSettings.Margins.Left - base.DefaultPageSettings.Margins.Right;
                    leftMargin = base.DefaultPageSettings.Margins.Left;  //X
                    rightMargin = base.DefaultPageSettings.Margins.Top;  //Y
                }

                //Check if the user selected to print in Landscape mode
                //if they did then we need to swap height/width parameters
                if (base.DefaultPageSettings.Landscape)
                {
                    int tmp;
                    tmp = printHeight;
                    printHeight = printWidth;
                    printWidth = tmp;
                }

                //Now we need to determine the total number of lines
                //we're going to be printing
                Int32 numLines = (int)printHeight / PrinterFont.Height;

                //Create a rectangle printing are for our document
                RectangleF printArea = new RectangleF(leftMargin, rightMargin, printWidth, printHeight);

                //Use the StringFormat class for the text layout of our document
                StringFormat format = new StringFormat(StringFormatFlags.LineLimit);

                //Fit as many characters as we can into the print area      

                e.Graphics.MeasureString(_text.Substring(RemoveZeros(curChar)), PrinterFont, new SizeF(printWidth, printHeight), format, out chars, out lines);

                //Print the page
                e.Graphics.DrawString(_text.Substring(RemoveZeros(curChar)), PrinterFont, Brushes.Black, printArea, format);

                //Increase current char count
                curChar += chars;

                //Detemine if there is more text to print, if
                //there is the tell the printer there is more coming
                if (curChar < _text.Length)
                {
                    e.HasMorePages = true;
                }
                else
                {
                    e.HasMorePages = false;
                    curChar = 0;
                }
            }

            #endregion
            #region  RemoveZeros
            /// <summary>
            /// Function to replace any zeros in the size to a 1
            /// Zero's will mess up the printing area
            /// </summary>
            /// <param name=value>Value to check</param>
            /// <returns></returns>
            /// <remarks></remarks>
            public int RemoveZeros(int value)
            {
                //Check the value passed into the function,
                //if the value is a 0 (zero) then return a 1,
                //otherwise return the value passed in
                switch (value)
                {
                    case 0:
                        return 1;
                    default:
                        return value;
                }
            }
            #endregion

            #region  PrintDocument
            public void PrintDocument()
            {
                //Create an instance of our printer class
                PCPrint printer = new PCPrint();
                //Set the font we want to use
                printer.PrinterFont = new Font("Verdana", 10);
                //Set the TextToPrint property
                printer.TextToPrint = "Thankyou fo visiting Gelian Hotel";
                //Issue print command
                printer.Print();
            }
            #endregion
        }*/
          
        string str = "Server=localhost;Database=promaster;Uid=promaster;Pwd=promaster2016";
        MySqlConnection con;
        MySqlCommand cmd;
        DataTable dt = new DataTable();
        MySqlDataAdapter adapter;
        //Retrieve data from database to DataGridView
        private void populate(string id, string name, string quantity, string price) {
            dgvmenu3.Rows.Add(id,name,quantity,price);
       }
        private void print() {
            DVPrintPreviewDialog.Document = DVPrintDocument;
            DVPrintPreviewDialog.ShowDialog();

        
        }
       private void retrieve()
        {
            con = new MySqlConnection(str);
            string sql = "select*from menu";
            cmd = new MySqlCommand(sql,con);
            try {
                con.Open();
                adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
                foreach (DataRow row in dt.Rows) {
                    populate(row[0].ToString(),row[1].ToString(),row[2].ToString(),row[3].ToString());
                }
                    
                con.Close();
                dt.Rows.Clear();

            }
            catch(Exception ex){
                MessageBox.Show(ex.Message);
            }


        }
        private void frmmain_Load(object sender, EventArgs e)
        {            try
            {
                retrieve();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

              private void button2_Click(object sender, EventArgs e)
        {
            calculator fm = new calculator();
            fm.StartPosition = FormStartPosition.CenterScreen;
               fm.Show();
            }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                lbltcost.Text = (Double.Parse(txtqty.Text) * Double.Parse(lblprice.Text)).ToString();
                dgvmenu4.Rows.Add(lblfood.Text, txtqty.Text,lblprice.Text,lbltcost.Text);
                lblhold.Text = lbltotal.Text + "+";
                lblcalculate.Text = lbltcost.Text;
                lbltotal.Text = (Double.Parse(lbltotal.Text) + Double.Parse(lblcalculate.Text)).ToString();
                     }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
             }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string removed = dgvmenu4.SelectedRows[0].Cells[2].Value.ToString();
                lbltotal.Text = (Double.Parse(lbltotal.Text) - Double.Parse(removed)).ToString();
                dgvmenu4.Rows.Remove(dgvmenu4.SelectedRows[0]);
                 // lbltotal.Text = (Double.Parse(lbltotal.Text) - Double.Parse(dgvmenu4.SelectedRows[0].Cells[3])).ToString();
            }
           catch(Exception ex){
               MessageBox.Show(ex.Message);
           }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtcash.Text=="")
                {
                    lblmore.Text = "Please enter cash";
                    txtcash.Focus();
                }
                else
                {
                    string msg = (Double.Parse(txtcash.Text) - Double.Parse(lbltotal.Text)).ToString();
                    if (Double.Parse(txtcash.Text) < Double.Parse(lbltotal.Text))
                    {
                        lblnot.Text = "Required";
                        lblmore.Text = msg + "/=";
                    }
                    else
                    {
                        lblmore.Text = "";
                        lblnot.Text = "Payment successifull";
                        lblmore.Text =  msg + "/=";
                        lblcash.Text = msg;
                        /*string fname, fqty, ftotal;
                         fname=dgvmenu4.Rows[1].Cells[1].Value.ToString();
                         fqty = dgvmenu4.Rows[1].Cells[2].Value.ToString();
                         ftotal = dgvmenu4.Rows[1].Cells[3].Value.ToString();
                         */
                        string cashier = lbluname.Text;
                        con = new MySqlConnection(str);
                        PrintDocument pd = new PrintDocument();
                        con.Open();
                        for (int i = 0; i <= dgvmenu4.Rows.Count - 1; i++)
                        {
                            string sql = "insert into sales values('','" + lbluname.Text + "','" + dgvmenu4.Rows[i].Cells[0].Value.ToString() + "','" + dgvmenu4.Rows[i].Cells[1].Value.ToString() + "','" + dgvmenu4.Rows[i].Cells[3].Value.ToString() + "',Now())";
                        cmd = new MySqlCommand(sql,con);
                        cmd.ExecuteNonQuery();
                      }
                        con.Close();
                        print();
                  }
                }
            }
            catch(Exception ex){
                MessageBox.Show(ex.Message);
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void dgvmenu_CellClick(object sender, EventArgs e)
        {
            try
            {
                lblfood.Text = dgvmenu3.SelectedRows[0].Cells[1].Value.ToString();
                txtqty.Text = "1";
                lblprice.Text = dgvmenu3.SelectedRows[0].Cells[3].Value.ToString();
                lbltcost.Text = (Double.Parse(txtqty.Text) * Double.Parse(lblprice.Text)).ToString();
                txtqty.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("This row is empty", "Empty selection"+ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void DVPrintDocument_PrintPage(object sender,PrintPageEventArgs e)
        {
           int starty = 285;
           /* int x = 20;
           int y = 220;
           int offsety = 40;
          string offset = "                              ";*/
            try { 
         Bitmap bmp = Properties.Resources.gelian1;
            Image img = bmp;
         e.Graphics.DrawImage(bmp,20,15,img.Width,img.Height);
         /*   Bitmap bm = new Bitmap(this.dgvmenu4.Width, this.dgvmenu4.Height);
         dgvmenu4.DrawToBitmap(bm, new Rectangle(0, 0, this.dgvmenu4.Width, this.dgvmenu4.Height));
         e.Graphics.DrawImage(bm, 0, 0);*/
           // e.Graphics.DrawString("ITEMS"+offset+"QTY"+offset+"PRICE"+"AMOUNT",new Font("Arial",20,FontStyle.Regular),Brushes.Black, new Point(x,y));
         e.Graphics.DrawString("--------------------------------------------------------------------------------------", new Font("Arial", 18, FontStyle.Regular), Brushes.Black, new Point(20, 210));
         e.Graphics.DrawString("FOOD NAME", new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(20, 235));
         e.Graphics.DrawString("QTY", new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(320, 235));
         e.Graphics.DrawString("PRICE", new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(480,235));
         e.Graphics.DrawString("AMOUNT", new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(620, 235));
         e.Graphics.DrawString("--------------------------------------------------------------------------------------", new Font("Arial", 18, FontStyle.Regular), Brushes.Black, new Point(20, 255));
          
            for (int i = 0; i <= dgvmenu4.Rows.Count - 1; i++)
            {
               // e.Graphics.DrawString("" + dgvmenu4.Rows[i].Cells[0].Value.ToString()+offset+dgvmenu4.Rows[i].Cells[1].Value.ToString()+offset+ dgvmenu4.Rows[i].Cells[2].Value.ToString(), new Font("Arial", 15, FontStyle.Regular), Brushes.Black,x,y+offsety);
               // e.Graphics.DrawString("" + dgvmenu4.Rows[i].Cells[1].Value.ToString(), new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(350, 260));
               // e.Graphics.DrawString("" + dgvmenu4.Rows[i].Cells[2].Value.ToString() + "/=", new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(650, 260));
                 e.Graphics.DrawString("" + dgvmenu4.Rows[i].Cells[0].Value.ToString(), new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(20, starty));
                e.Graphics.DrawString("" + dgvmenu4.Rows[i].Cells[1].Value.ToString(), new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(320, starty));
                e.Graphics.DrawString("" + dgvmenu4.Rows[i].Cells[2].Value.ToString() + ".00", new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(480, starty));
                e.Graphics.DrawString("" + dgvmenu4.Rows[i].Cells[3].Value.ToString() + ".00", new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(620, starty));
               //offsety = offsety + 20;
                starty = starty + 40;
            }
            e.Graphics.DrawString("--------------------------------------------------------------------------------------", new Font("Arial", 18, FontStyle.Regular), Brushes.Black, new Point(20, starty));
            starty = starty + 30;
            e.Graphics.DrawString("TOTAL",new Font("Arial",18,FontStyle.Bold),Brushes.Black,new Point(20,starty));
            e.Graphics.DrawString("" + lbltotal.Text + ".00", new Font("Arial", 18, FontStyle.Bold), Brushes.Black, new Point(620, starty));
            starty = starty + 35;
            e.Graphics.DrawString("CASH", new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(20, starty));
            e.Graphics.DrawString("" + txtcash.Text + ".00", new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(620, starty));
            starty = starty + 35;
            e.Graphics.DrawString("CHANGE", new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(20, starty));
            e.Graphics.DrawString("" + lblcash.Text + ".00", new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(620, starty));
            starty = starty + 30;
            e.Graphics.DrawString("--------------------------------------------------------------------------------------", new Font("Arial", 18, FontStyle.Regular), Brushes.Black, new Point(20, starty));
            starty = starty + 35;
            e.Graphics.DrawString("YOU WEERE SERVED BY:", new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(20, starty));
            e.Graphics.DrawString(""+lbluname.Text.ToUpper(), new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(480, starty));
            starty = starty + 35;
            e.Graphics.DrawString("=========================================================================", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(20, starty));
            starty = starty + 30;
            e.Graphics.DrawString("Designed & Developed by PROMASTER:    +254700456439 ", new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(20, starty));
            starty = starty + 30;
            e.Graphics.DrawString("=========================================================================", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(20, starty));
            starty = starty + 30;
            // e.Graphics.DrawString("" + lbluname.Text, new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(210, starty));
            e.Graphics.DrawString("THANK YOU FOR VISITING GELIAN HOTEL, WELCOME AGAIN", new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(20, starty));
        }
            catch(Exception ex){
                MessageBox.Show(""+ex);
            }
        }
 }
}