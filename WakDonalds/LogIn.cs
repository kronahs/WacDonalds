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
    public partial class LogIn : Form
    {
        int userID;
        string conStr = "Server=ILRIETICIPETTEF;Database=BillingApp;Integrated Security=true;";
        public LogIn()
        {
            InitializeComponent();
        }

        private void btnBurger_Load(object sender, EventArgs e)
        {

        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(conStr))
                {
                    conn.Open();
                    string query = "SELECT empID FROM Employee WHERE username = '" + txtUserName.Text.Trim() + "' AND password_ = '" + txtPassword.Text.Trim() + "'";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        userID = Convert.ToInt32(result);
                        WaiterForm wf = new WaiterForm(userID);
                        wf.Show();

                    }
                    else
                    {
                        MessageBox.Show("Check your username and password");
                    }
                }
            }
            catch(SqlException sq)
            {
                MessageBox.Show(sq.Message, "Sql Error");
            }

        }
    }
}
