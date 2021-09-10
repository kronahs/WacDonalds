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
    public partial class foodContainer : UserControl
    {
        public foodContainer()
        {
            InitializeComponent();
        }

        private string _title;
        private double _price;
        private int _available;

        [Category("Custom Props")]

        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value; lblTitle.Text = value;
            }
        }


        public double Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value; lblPrice.Text =  value.ToString();
            }
        }

        public int Availablity
        {
            get
            {
                return _available;
            }
            set
            {
                _available = value;
                if(value == 0)//means available 
                {
                    lblAvailable.BackColor = Color.LightGreen;
                }
                else if(value == 1)//food is not available
                {
                    lblAvailable.BackColor = Color.IndianRed;
                }
            }
        }

        //Gettter and Setter Labels



        //Hover Effect
        private void ucRequest_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(217, 229, 242);
        }

        private void ucRequest_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(255, 255, 255);
        }

        private void foodContainer_Click(object sender, EventArgs e)
        {
            
        }
    }
}
