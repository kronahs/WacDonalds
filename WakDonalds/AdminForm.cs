using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WakDonalds
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }


        private void btnFood_Click(object sender, EventArgs e)
        {
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {

        }

        private void btnFood_Click_1(object sender, EventArgs e)
        {

        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            LogIn b = new LogIn();
            this.MdiParent = b;
        }
    }
}
