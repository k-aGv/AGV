using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Threading;//For Sleep command

namespace WindowsFormsApplication1
{
    public partial class ATEI_SplashScreen : Form
    {
        string resources_path = System.IO.Directory.GetCurrentDirectory() + "\\agv_resources";
        public ATEI_SplashScreen()
        {
            InitializeComponent();
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            //Same BackColor & TransparencyKey returns a transparent form.Transparent Key is
            //supposed to be the color which u want to be transparent.So backcolor=transparentkey
            this.BackColor = Color.Gray;
            this.TransparencyKey = Color.Gray;
            //1sec=1000ms
            Thread.Sleep(1000);
        }

    }
}
