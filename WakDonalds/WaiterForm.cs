using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WakDonalds
{
    public partial class WaiterForm : Form
    {
        //int size = 5;
        int currentEmpID;
        string conStr = "Server=ILRIETICIPETTEF;Database=BillingApp;Integrated Security=true;";
        double total = 0.0;
        /*        string[] title = new string[5] {"Big Mac","McDouble","Cheeseburger","Hamburger","Quarter Pounder"};
                double[] price = new double[5] { 184.2, 64.11, 114.84, 114.84, 168.3 };
                int[] available = new int[5] {0,1,1,0,0};*/
        public WaiterForm(int userID)
        {
            InitializeComponent();
            timer1.Start();
            currentEmpID = userID;
        }

        private void GenerateDynamicControl(int categNumber)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(conStr))
                {
                    conn.Open();

                    DataTable dataTable = new DataTable();

                    string query = "SELECT Food,Price,Available FROM Food WHERE Category = "+categNumber;
                    SqlCommand cmd = new SqlCommand(query,conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    da.Fill(dataTable);
                    conn.Close();
                    da.Dispose();

                    flowLayoutPanel1.Controls.Clear();

                    foodContainer[] listItems = new foodContainer[dataTable.Rows.Count];

                    for (int i=0;i<1;i++)
                    {
                       foreach(DataRow row in dataTable.Rows)
                        {
                            listItems[i] = new foodContainer();

                            listItems[i].Title = row["Food"].ToString();
                            listItems[i].Price = double.Parse(row["Price"].ToString());
                            listItems[i].Availablity = Int32.Parse(row["Available"].ToString());

                           
                            flowLayoutPanel1.Controls.Add(listItems[i]);
                            listItems[i].Click += new System.EventHandler(this.UserControl_Click);
                        }
                    }
                }
            }
            catch (SqlException sq)
            {
                MessageBox.Show(sq.Message, "Sql Error");
            }
        }

        private void UserControl_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Button Click");
            foodContainer obj = (foodContainer)sender;

            DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
            row.Cells[0].Value = obj.Title;
            row.Cells[1].Value = obj.Price;
            row.Cells[2].Value = obj.Availablity;
            dataGridView1.Rows.Add(row);

            total += obj.Price;
            lblTotal.Text = total.ToString();
        }

        private void btnBreakfast_Click(object sender, EventArgs e)
        {
            GenerateDynamicControl(1);
        }

        private void btnBurger_Click(object sender, EventArgs e)
        {
            GenerateDynamicControl(2);
        }

        private void btnPizza_Click(object sender, EventArgs e)
        {
            GenerateDynamicControl(3);
        }

        private void btnSandwich_Click(object sender, EventArgs e)
        {
            GenerateDynamicControl(4);
        }

        private void btnChicken_Click(object sender, EventArgs e)
        {
            GenerateDynamicControl(5);
        }

        private void btnSides_Click(object sender, EventArgs e)
        {
            GenerateDynamicControl(6);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            total = 0.0;
            lblTotal.Text = total.ToString();
        }

        Bitmap bmp;
        private void btnPrint_Click(object sender, EventArgs e)
        {
            int height = dataGridView1.Height;
            dataGridView1.Height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height * 2;
            bmp = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            dataGridView1.DrawToBitmap(bmp, new Rectangle(0, 0,dataGridView1.Width,dataGridView1.Height));

            dataGridView1.Height = height;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp,0,0);
        }

        private void WaiterForm_Load(object sender, EventArgs e)
        {
            //lblDate.Text = DateTime
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            lblDate.Text = dateTime.ToShortTimeString();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {

        }
    }
}
