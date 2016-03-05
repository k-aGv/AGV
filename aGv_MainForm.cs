using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Threading;
namespace WindowsFormsApplication1
{
    public partial class aGv_MainForm : Form
    {
        //initialize our classes
        AGV myagv = new AGV();
        Grid myGrid = new Grid();

        public aGv_MainForm()
        {
            ATEI_SplashScreen Splash = new ATEI_SplashScreen();
            Splash.Show();
            Splash.Dispose();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            //Dynamically create a shadow of this form , to the classes we made
            Grid.Form = this;
            AGV.Form = this;
            
            //example shit
            myagv.AGV_speed = 1; //1block per sec
            myagv.name = "Test value";
            myagv.owner = "Test value";

            grid_status_updater.Start();


        }

        private void gridBtn_Click(object sender, EventArgs e)
        {
            myGrid.drawGrid(this,300, 300,200,20,10);
        }

     
        private void grid_status_updater_Tick(object sender, EventArgs e)
        {
            string status =
             myGrid.x_size + " blocks on X axes.\r\n" +
             myGrid.y_size + " blocks on Y axes.\r\n" +
             myGrid.grid_res + " pixels per block/step.\r\n" +
            "Grid's location:(" + myGrid.location_x+","+myGrid.location_y+")";
            if (status != grid_status.Text)
            {
                grid_status.Text = status;
            }
            //propably a memory leak if timer is enabled for much time(low ram)
        }
        
    }
}
