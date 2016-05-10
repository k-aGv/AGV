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
        

        AGV youragv = new AGV();

        Watcher myagvWatcher = new Watcher();
        Watcher youragvWatcher = new Watcher();

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
            //just in case
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.UserPaint |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.ResizeRedraw |
                          ControlStyles.ContainerControl |
                          ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.SupportsTransparentBackColor
                          , true);

            button1.Visible = false;
            Point_array.Visible = false;
            //Dynamically create a shadow of this form , to the classes we made
            Grid.Form = this;
            AGV.Form = this;
            
            
            //example shit
            myagv.AGV_speed = 1; //1block per sec
            myagv.name = "Test value";
            
            grid_status_updater.Start();
            this.Text = "k-aGv Emulator project";


        }

        private void gridBtn_Click(object sender, EventArgs e)
        {
            //just to see the animation
            myGrid.drawGrid(this,300, 300,200,20,10);
            
            button1.Visible = true;
            Point_array.Visible = true;
            
        }

     
        private void grid_status_updater_Tick(object sender, EventArgs e)
        {
            string status =
             myGrid.x_size + " blocks on X axes.\r\n" +
             myGrid.y_size + " blocks on Y axes.\r\n" +
             myGrid.resolution + " pixels per block/step.\r\n" +
            "Grid's location:(" + myGrid.location_x+","+myGrid.location_y+")";
            if (status != grid_status.Text)
            {
                grid_status.Text = status;
            }
            //propably a memory leak if timer is enabled for much time(low ram)
        }

     
        private void button1_Click(object sender, EventArgs e)
        {
            
            //label:just for debug 
            int i=0, j;
            int row = 1;
            for (j = 0; j < 300; j += 10)
            {
                
                Point_array.Text += "Row:" + row+"\r\n";
                
                for ( i = 0; i < 300; i += 10)
                {
                    Point_array.Text += myGrid.array_of_points[i, j] + " ";
                }
                Point_array.Text += "\r\n"+"\r\n";
                row++;
            }
            //end of label
        }

        private void button2_Click(object sender, EventArgs e)
        {
            myagv.CreateAGV(myGrid,"tsipras", 30,30,1);
           
            
            
        }


        private void start_Click(object sender, EventArgs e)
        {
            Point _end = new Point(300, 300);


            Point _start = new Point(myagv.startX, myagv.startY);
            myagvWatcher.initialize(this, myagv);

            myagvWatcher._Start(); //tixenei to .Start() na exei idio onoma me to kanoniko-official event
            
            myagv.moveToEnd(myGrid,_start, _end);
           

            Point _start2 = new Point(youragv.startX, youragv.startY);
            youragv.moveToEnd(myGrid, _start2,_end);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            youragv.CreateAGV(myGrid, "mitsotakis", 30, 150,1);
        }

        

    }
}
