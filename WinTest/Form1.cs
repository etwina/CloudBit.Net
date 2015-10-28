using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LittleBits;

namespace WinTest
{
    public partial class Form1 : Form
    {
        CloudBit cloud = new CloudBit("00e04c223422","s");

        public Form1()
        {
            InitializeComponent();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            cloud.SetOutput(trackBar1.Value);
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            cloud.SetOutput(trackBar1.Value);

        }
    }
}
