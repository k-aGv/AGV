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

    class Grid
    {
        /*
        *get;set; method
        *Used to dynamically clone a Form UI to a non-GUIed class.
        *HAS TO BE IMPLEMENTED TO FORM_LOAD OF PARENT FORM
        * 
        */
        public static aGv_MainForm Form { get; set; }


        /*
         * Random vars just to be tested
         */
        public int x_size = 0;
        public int y_size = 0;
        public int grid_res = 0;
        public int location_x = 0;
        public int location_y = 0;




        //class functions


        /*
         * drawGrid(
         *          Handled Form to be painted
         *          ,x size of grid
         *          ,y size of grid
         *          ,locationX location X of panel
         *          ,locationY location Y of panel
         *          ,pixels per block of grid)
         */
        public bool drawGrid(Form Handled_Form, int Grid_Width, int Grid_Height, int locationX, int locationY, int res)
        {
            if (Handled_Form == null)
            {
                MessageBox.Show("Invalid arguments at drawGrid() function");
                return false;
            }
            else
            {
                //Create panel and add it's properties
                Panel myPanel = new Panel();
                Point panel_points = new Point(locationX, locationY);
                myPanel.Location = panel_points;
                myPanel.Width = Grid_Width + 1;//fixes the right border of panel
                myPanel.Height = Grid_Height + 1;//fixed the bottom border of panel
                myPanel.BackColor = Color.LightGray;
                myPanel.Cursor = Cursors.Hand;
                location_x = locationX;
                location_y = locationY;

                //send it to our Main form
                Handled_Form.Controls.Add(myPanel);

                //Create the graphics interface and create the rectangle-step
                Graphics gp = myPanel.CreateGraphics();
                Pen p = new Pen(Color.Red);
                Rectangle myRec = new Rectangle();
                myRec.Height = res;
                myRec.Width = res;


                //Since myPanel is handled we can make changes in real time
                for (int i = 0; i < Grid_Width; i = i + res)
                {
                    for (int j = 0; j < Grid_Height; j = j + res)
                    {
                        myRec.X = i;
                        myRec.Y = j;
                        gp.DrawRectangle(p, myRec);
                    }
                }
                //if f.Controls.Add(myPanel); being here, graphics will be Cleared."Losing handle?"


                /*
                 * dynamically declare an array fulled with Points(x,y)
                 * (x*y)/res is produced to return the exact number of grid's blocks
                 */

                Point[] array_of_points = new Point[(Grid_Width * Grid_Height) / res];


                //Debug Comment: MessageBox.Show("Size of array:" + array_of_points.Length);
                Point _tempPoint;//a temp point to lock
                int cell_counter; //counter of array's cells
                cell_counter = 0;//first block (top left)

                for (int i = 0; i < Grid_Width; i = i + res)
                {
                    for (int j = 0; j < Grid_Height; j = j + res)
                    {
                        _tempPoint = new Point(i, j);
                        array_of_points[cell_counter] = _tempPoint;
                        cell_counter++;
                        //Debug Comment: MessageBox.Show(array_of_points[cell_counter] + "");
                    }
                }

                //Update class' variables
                x_size = Grid_Width / res;
                y_size = Grid_Height / res;
                grid_res = res;

                //everything done as we'd liked to.
                return true;
            }

        }



    }
}
