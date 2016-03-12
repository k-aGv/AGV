using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms; //same imports as form1.cs.who cares for memory


namespace WindowsFormsApplication1
{
    class AGV
    {
        /*
         *get;set; method
         *Used to dynamically declare a Form UI to a non-GUIed class.
         *HAS TO BE IMPLEMENTED TO FORM_LOAD OF PARENT FORM
         * 
         */
        public static aGv_MainForm Form { get; set; }


        /*
         * Random vars just to be tested
         */
        public string name;
        public string owner;
        public int AGV_speed;
        //public int ID ;


        /*
         * class functions
         */
        public int GetLocationX(int AGV_ID)
        {
            int x = 0;//cant be null
            return x;
        }
        public int GetLocationY(int AGV_ID)
        {
            int y = 0;//cant be null
            return y;
        }

        //Declaration of CreateAGV()
        public bool CreateAGV(Grid handledGrid, Point StartPoint)
        {
            if (handledGrid==null)
            {
                MessageBox.Show("DEBUG:Unhandled Grid.Did you create it ?");
                return false;
            }
            SolidBrush b = new SolidBrush(Color.Red);
            handledGrid.gridGraphics.FillRectangle(b
                , StartPoint.X
                , StartPoint.Y
                , handledGrid.resolution
                , handledGrid.resolution);
            return true;

        }
        //Overload CreateAGV()
        public bool CreateAGV(Grid handledGrid, int start_x,int start_y)
        {
            if (handledGrid.gridPanel==null)
            {
                MessageBox.Show("DEBUG:Unhandled Grid.Did you create it ?");
                return false;
            }
            SolidBrush b = new SolidBrush(Color.Red);
            handledGrid.gridGraphics.FillRectangle(b, start_x, start_y, handledGrid.resolution, handledGrid.resolution);
            return true;

        }

        //declaration of moveToEnd()
        public bool moveToEnd(Grid handledGrid,Point endPoint)
        {
            if (handledGrid.gridPanel == null)
            {
                MessageBox.Show("DEBUG:Unhandled Grid.Did you create it ?");
                return false;
            }
            SolidBrush b = new SolidBrush(Color.Red);
            handledGrid.gridGraphics.FillRectangle(b
                ,endPoint.X - handledGrid.resolution
                ,endPoint.Y - handledGrid.resolution
                ,handledGrid.x_blocks 
                ,handledGrid.y_blocks 
                );
            return true;
        }
        //Overload of moveToEnd()
        public bool moveToEnd(Grid handledGrid, int x_end, int y_end)
        {
            if (handledGrid.gridPanel == null)
            {
                MessageBox.Show("DEBUG:Unhandled Grid.Did you create it ?");
                return false;
            }
            SolidBrush b = new SolidBrush(Color.Red);
            
            handledGrid.gridGraphics.FillRectangle(b
                ,x_end - handledGrid.resolution
                ,y_end - handledGrid.resolution
                ,handledGrid.x_blocks 
                ,handledGrid.y_blocks
                );
            return true;
        }

    }
}
