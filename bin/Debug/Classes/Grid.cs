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
        

        //size at blocks
        public int x_blocks = 0;
        public int y_blocks = 0;

        //size at pixels
        public int x_size = 0;
        public int y_size = 0; 

        public int location_x = 0;
        public int location_y = 0;

        public Point[,] array_of_points ;
        public int resolution;
        public Panel gridPanel;

        public int[,] block_type;

        protected CheckBox cb;
        protected bool drawingObstacle = false;

        protected Label drawStateLabel;


        /*
         * Create 2 instances of graphics.
         * Why?
         * 1 instance is only for the grid...the lines.
         * other instance will be the agv movement.
         * This will help us use the .Clear() method safely
         */
        public Graphics gridGraphics;
        protected Pen gridpen = new Pen(Color.Black);




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

        /// <summary>
        /// madafaka my shit
        /// </summary>
        /// <param name="Handled_Form">Handled form to be used </param>
        /// <param name="Grid_Width">Desired grid's width</param>
        /// <param name="Grid_Height"></param>
        /// <param name="locationX"></param>
        /// <param name="locationY"></param>
        /// <param name="res"></param>
        /// <returns></returns>
        public bool drawGrid(Form Handled_Form, int Grid_Width, int Grid_Height, int locationX, int locationY, int res)
        {
            if (Handled_Form == null)
            {
                MessageBox.Show("Invalid arguments at drawGrid() function");
                return false;
            }
            else
            {
                block_type = new int[Grid_Width/res, Grid_Height/res];
                int k=0,l=0;
                for ( k = 0; k < Grid_Width / res; k ++)
                {
                    for ( l = 0; l < Grid_Height / res; l ++)
                    {
                            block_type[k,l] = 0;
                    }
                }
                block_type[k-1,l-1] = 2;



                //Create panel and add it's properties
                gridPanel = new Panel();
                gridPanel.SendToBack();
                //Create the Checkbox.Why here?cuz we want to handle it's event."just a fast solution"
                cb = new CheckBox();
                //Create the label.Why?Same reason as above
                drawStateLabel = new Label();

                //Dynamically handle new click event to the detached Panel we created
                gridPanel.MouseClick += new MouseEventHandler(myPanel_MouseClick);
                cb.CheckedChanged += new EventHandler(cb_CheckedChanged);

                
                //Checkbox's Properties
                //combobox's location = 234, 75
                Point cbLocation = new Point(526, 263);
                cb.Location = cbLocation;
                cb.Text = "Draw Obstacle";
                
               
                //Label's Properties
                Point labelLocation = new Point(526, 300);
                drawStateLabel.Location = labelLocation;
                drawStateLabel.Text = "Nothing";
                


                //Grid's Properties
                Point panel_points = new Point(locationX, locationY);
                gridPanel.Location = panel_points;
                gridPanel.Width = Grid_Width + 1;//fixes the right border of panel
                gridPanel.Height = Grid_Height + 1;//fixed the bottom border of panel
                gridPanel.BackColor = Color.LightGray;
                //myPanel.Cursor = Cursors.Hand;
                location_x = locationX;
                location_y = locationY;

                //send Panel to Main Form
                Handled_Form.Controls.Add(gridPanel);
                //send Checkbox to Main Form
                Handled_Form.Controls.Add(cb);
                //send Label to Main Form
                Handled_Form.Controls.Add(drawStateLabel);

                //Create the graphics interface and create the rectangle-step
                gridGraphics = gridPanel.CreateGraphics();
                
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
                    gridGraphics.DrawLine(p, a, 0, a, Grid_Width);
                }
                for ( b = 0; b < Grid_Height; b += res)
                {
                    gridGraphics.DrawLine(p, 0, b, Grid_Height, b);
                }
                //Fix the known bug of left and bottom borders
                gridGraphics.DrawLine(p, a, 0, a, Grid_Width - 1);
                gridGraphics.DrawLine(p, 0, b, Grid_Height, b - 1);

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
                x_size = Grid_Width;
                y_size = Grid_Height;
                x_blocks = Grid_Width / res;
                y_blocks = Grid_Height / res;
                

                //everything done as we'd liked to.
                return true;
            }

        }

        //protected functions are used to prevent any call of the functions FROM the form
        //protected actually means : this functions is a 'private' function used only by the class where is declared
        protected void cb_CheckedChanged(object sender, EventArgs e)
        {
            drawingObstacle = cb.Checked;
            if (cb.Checked)
                drawStateLabel.Text = "Obstacle";
            else
                drawStateLabel.Text = "Nothing";
            
        }
        protected void myPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (drawingObstacle)
            {
                //initialize the sender
                Panel myPanel = sender as Panel;
                Point clickedPoint;
               // block_type=new int[x_blocks,y_blocks];

                clickedPoint = getClickPoint(e.X, e.Y);
                gridGraphics = myPanel.CreateGraphics();
                SolidBrush b = new SolidBrush(Color.Black);
                gridGraphics.FillRectangle(b, clickedPoint.X, clickedPoint.Y, resolution, resolution);

                block_type[clickedPoint.X/resolution, clickedPoint.Y/resolution] = 3;
                
            } 
        }


        /*
         * tricky way to break the nested loop.
         * -Why no break?because a single break will break only the nested for.
         * -why no goto?because 2016.
         */
        protected Point getClickPoint(int _x,int _y)
        {
            int i, j;
            for (j = 0; j < y_size; j += resolution)
            {
                for (i =0; i <x_size; i += resolution)
                {
                    //sorcery coding ahead!
                    //====================
                    //get only the .X of the point. we cant use the operator '<' between Point class objects
                    if (_x <= array_of_points[i, j].X+resolution && _y <= array_of_points[i, j].Y+resolution)
                    {
                        //MessageBox.Show(array_of_points[i, j] + "");

                       /*For a strange reason it cant accept: =new Point (array_of_points[i,j])
                        *even our array is declared as Point. 
                        *Failure on Point structure.Microsoft please
                        */

                        //more sorcery: -resolution is used for balancing the topleft point
                        Point _p = new Point(array_of_points[i, j].X,array_of_points[i,j].Y);
                        return _p;
                    }

                }

            }
            //....just in case
            Point failPoint = new Point(-1, -1);
            return failPoint;
        }
        public void refreshGrid()
        {
            gridGraphics.Clear(gridPanel.BackColor);
            int a, b;
            for (a = 0; a < x_size; a += resolution)
            {
                gridGraphics.DrawLine(gridpen, a, 0, a, x_size);
            }
            for (b = 0; b < y_size; b += resolution)
            {
                gridGraphics.DrawLine(gridpen, 0, b, y_size, b);
            }
        }
       


    }
}
