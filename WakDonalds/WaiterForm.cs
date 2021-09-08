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
        int size = 5;
        string conStr = "Server=ILRIETICIPETTEF;Database=BillingApp;Integrated Security=true;";
        /*        string[] title = new string[5] {"Big Mac","McDouble","Cheeseburger","Hamburger","Quarter Pounder"};
                double[] price = new double[5] { 184.2, 64.11, 114.84, 114.84, 168.3 };
                int[] available = new int[5] {0,1,1,0,0};*/
        public WaiterForm(int userID)
        {
            InitializeComponent();
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
            foodContainer obj = (foodContainer)sender;

            pb_icon.Image = obj.Icon;
            lblTitle.Text = obj.Title;
            lblSubTitle.Text = obj.SubTitle;
            showPanel();
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
    }
}
