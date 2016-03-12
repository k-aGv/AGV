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

        public Point[,] array_of_points ;
        public int resolution;
        public Panel myPanel;


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
                myPanel = new Panel();

                //Dynamically handle new click event to the detached Panel we created
                myPanel.MouseClick += new MouseEventHandler(myPanel_MouseClick);

                Point panel_points = new Point(locationX, locationY);
                myPanel.Location = panel_points;
                myPanel.Width = Grid_Width + 1 ;//fixes the right border of panel
                myPanel.Height = Grid_Height +1 ;//fixed the bottom border of panel
                myPanel.BackColor = Color.LightGray;
                //myPanel.Cursor = Cursors.Hand;
                location_x = locationX;
                location_y = locationY;

                //send it to our Main form
                Handled_Form.Controls.Add(myPanel);

                //Create the graphics interface and create the rectangle-step
                Graphics gp = myPanel.CreateGraphics();
                Pen p = new Pen(Color.Black);

                //We dont need rectangle...at the moment.
                //Rectangle myRec = new Rectangle();
                //myRec.Height = res;
                //myRec.Width = res;

                resolution = res;
                //Faster grid creation.All we do care about is just a visual presentation.
                int a, b;
                for ( a = 0; a < Grid_Width; a += res)
                {
                    gp.DrawLine(p, a,0, a,Grid_Width);
                }
                for ( b = 0; b < Grid_Height; b += res)
                {
                    gp.DrawLine(p, 0,b ,Grid_Height,b);
                }
                //Fix the known bug of left and bottom borders
                gp.DrawLine(p, a, 0, a, Grid_Width-1);
                gp.DrawLine(p, 0, b, Grid_Height, b-1);

                //Since myPanel is handled we can make changes in real time
                /*
                for (int i = 0; i < Grid_Width; i += res)
                {
                    for (int j = 0; j < Grid_Height; j += res)
                    {
                        myRec.X = i;
                        myRec.Y = j;
                        gp.DrawRectangle(p, myRec);
                    }
                }
               

                /*
                 * dynamically declare an array fulled with Points(x,y)
                 * (x*y)/res is produced to return the exact number of grid's blocks
                 */
                array_of_points = new Point[Grid_Width, Grid_Height];

                
                //MessageBox.Show("Size of array:" + array_of_points.Length);
                //supposed to be 9000...30x30 cells ..*10 for 10 pixels per block


                /*
                 * !WARNING!
                 * Array sorcery ahead
                 * --------------------
                 * Swap i and j just to make array be filled like:
                 * First row of array --> points of first row of grid
                 * Second row of array --> points of second row of grid
                 * THOSE POINTS ARE THE POINTS OF THE TOPLEFT CORNER OF EACH BLOCK!
                 */
                Point _tempPoint = new Point(0, 0);
                for (int j = 0; j < Grid_Height; j = j + res)
                {
                    for (int i = 0; i < Grid_Width; i = i + res)
                    {
                        _tempPoint.X = i;
                        _tempPoint.Y = j;
                        array_of_points[i,j] = _tempPoint;                        
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

        //protected functions are used to prevent any call of the functions FROM the form
        //protected actually means : this functions is a 'private' function used only by the class where is declared
        protected void myPanel_MouseClick(object sender, MouseEventArgs e)
        {
            //initialize the sender
            Panel myPanel = sender as Panel;
            Point clickedPoint;

            //Debug-Purpose messagebox
           // MessageBox.Show("Clicked on panel");

            clickedPoint=getClickPoint(e.X, e.Y);
            Graphics gp = myPanel.CreateGraphics();
            SolidBrush b = new SolidBrush(Color.Black);
            gp.FillRectangle(b, clickedPoint.X, clickedPoint.Y, resolution,resolution);

        }


        /*
         * tricky way to break the nested loop.
         * -Why no break?because a single break will break only the nested for.
         * -why no goto?because 2016.
         */
        protected Point getClickPoint(int _x,int _y)
        {
            int i, j;
            for (j = 0; j < 300; j += resolution)
            {
                for (i =0; i < 300; i += resolution)
                {
                    //sorcery coding ahead!
                    //====================
                    //get only the .X of the point. we cant use the operator '<' between Point class objects
                    if (_x <= array_of_points[i, j].X && _y <= array_of_points[i, j].Y)
                    {
                        //MessageBox.Show(array_of_points[i, j] + "");

                       /*For a strange reason it cant accept: =new Point (array_of_points[i,j])
                        *even our array is declared as Point. 
                        *Failure on Point structure.Microsoft please
                        */

                        //more sorcery: -resolution is used for balancing the topleft point
                        Point _p = new Point(array_of_points[i, j].X-resolution,array_of_points[i,j].Y-resolution);
                        return _p;
                    }

                }

            }
            //....just in case
            Point failPoint = new Point(-1, -1);
            return failPoint;
        }


    }
}
