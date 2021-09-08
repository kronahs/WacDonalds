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
    public partial class WaiterForm : Form
    {
        int size = 5;
        string[] title = new string[5] {"Big Mac","McDouble","Cheeseburger","Hamburger","Quarter Pounder"};
        double[] price = new double[5] { 184.2, 64.11, 114.84, 114.84, 168.3 };
        int[] available = new int[5] {0,1,1,0,0};
        public WaiterForm(int userID)
        {
            InitializeComponent();
        }

        private void GenerateDynamicControl()
        {
            flowLayoutPanel1.Controls.Clear();

            foodContainer[] listItems = new foodContainer[size];




            for (int i = 0; i < listItems.Length; i++)
            {
                listItems[i] = new foodContainer();

                listItems[i].Title = title[i];
                listItems[i].Price = price[i];
                listItems[i].Availablity = available[i];

                flowLayoutPanel1.Controls.Add(listItems[i]);
                //listItems[i].Click += new System.EventHandler(this.UserControl_Click);
            }
        }

/*        private void UserControl_Click(object sender, EventArgs e)
        {
            foodContainer obj = (foodContainer)sender;

            pb_icon.Image = obj.Icon;
            lblTitle.Text = obj.Title;
            lblSubTitle.Text = obj.SubTitle;
            showPanel();
        }*/

        private void btnBreakfast_Click(object sender, EventArgs e)
        {
            GenerateDynamicControl();
        }


    }
}
