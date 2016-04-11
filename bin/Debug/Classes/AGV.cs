using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms; //same imports as form1.cs.who cares for memory
using System.IO;


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
        public int AGV_speed;
        public int LocationX;
        public int LocationY;
        public int endLocationX;
        public int endLocationY;

        public bool isFinished = false;
        protected SolidBrush anim_brush = new SolidBrush(Color.Green);


        protected PictureBox pb = new PictureBox(); 
        string agv_pic = Directory.GetCurrentDirectory() + "\\klark.png";


        public int startX;
        public int startY;
        public Graphics agvGraphics;



        /*
         * class functions
         */

        //Declaration of CreateAGV()
        public bool CreateAGV(Grid handledGrid, string agvName, int startx, int starty)
        {
            if (handledGrid == null)
            {
                MessageBox.Show("DEBUG:Unhandled Grid.Did you create it ?");
                return false;
            }

            SolidBrush b = new SolidBrush(Color.Red);
            agvGraphics = handledGrid.gridGraphics;
            agvGraphics.FillRectangle(b
                , startx
                , starty
                , handledGrid.resolution
                , handledGrid.resolution);



            startX = startx;
            startY = starty;
            name = agvName;

            return true;

        }


        //declaration of moveToEnd()
        public bool moveToEnd(Grid handledGrid, Point startPoint, Point endPoint)
        {
            
            int i = startPoint.X / handledGrid.resolution, j = startPoint.Y / handledGrid.resolution;
            endLocationX = endPoint.X;
            endLocationY = endPoint.Y;
            //0 -> keli  = keno
            //3 -> keli  = empodio
            //2 -> exit
            //1 -> current


            bool ob_left_found = false;
            bool ob_down_found = false;
            bool failed_down = false;
            bool found = false;

            while (!found)
            {
                if (i < handledGrid.x_blocks - 1 && ob_down_found == false) //an exeis perithwrio na pas 1 keli deksia prin vgeis ektos
                {
                    if (handledGrid.block_type[i + 1, j] != 3 && failed_down == false) //an sta deksia den vreis empodio
                    {
                        if (handledGrid.block_type[i + 1, j] == 2) //des an to deksi keli einai i eksodos
                        {

                            found = true;
                        }
                        else
                        {
                            handledGrid.block_type[i + 1, j] = 1; //pigaine
                            handledGrid.block_type[i, j] = 0;
                            i++;
                            agv_anim(handledGrid, i, j);
                        }
                    }
                    else //an vreis empodio sta deksia
                    {
                        if (j < handledGrid.y_blocks - 1) //an exeis perithwrio na kateveis xwris na vgeis ektos oriwn
                        {
                            if (handledGrid.block_type[i, j + 1] != 3 && ob_left_found == false) //an sto katw keli de vreis empodio
                            {
                                if (handledGrid.block_type[i, j + 1] == 2) //des an to katw keli einai i eksodos
                                {

                                    found = true;
                                }
                                else
                                {
                                    handledGrid.block_type[i, j + 1] = 1;//pigaine
                                    handledGrid.block_type[i, j] = 0;
                                    j++;
                                    failed_down = false;
                                    agv_anim(handledGrid, i, j);
                                }
                            }
                            else //an vreis empodio pros ta katw
                            {
                                if (handledGrid.block_type[i - 1, j] == 3)
                                {
                                    ob_left_found = true;
                                    handledGrid.block_type[i, j - 1] = 1;
                                    handledGrid.block_type[i, j] = 0;
                                    j--;
                                    agv_anim(handledGrid, i, j);
                                }
                                else
                                {
                                    ob_left_found = false;
                                    handledGrid.block_type[i - 1, j] = 1; //pigaine ena keli aristera
                                    handledGrid.block_type[i, j] = 0;
                                    i--;
                                    failed_down = true;
                                    agv_anim(handledGrid, i, j);
                                }
                                if (handledGrid.block_type[i, j + 1] != 3 && ob_left_found == false) //kai des an mporeis na pas pros ta katw
                                {
                                    if (handledGrid.block_type[i, j + 1] == 2) //des an to katw keli einai i eksodos
                                    {

                                        found = true;
                                    }
                                    else
                                    {
                                        handledGrid.block_type[i, j + 1] = 1; //an ginetai, pigaine
                                        handledGrid.block_type[i, j] = 0;
                                        j++;
                                        failed_down = false;
                                        agv_anim(handledGrid, i, j);
                                    }
                                }
                            }
                        }
                        else //an den exeis perithwrio na kateveis kai allo (vgaineis ektos oriwn)
                        {
                            if (handledGrid.block_type[i, j - 1] != 3) //an sto panw keli den uparxei empodio
                            {
                                handledGrid.block_type[i, j - 1] = 1;
                                handledGrid.block_type[i, j] = 0;
                                j--;
                                agv_anim(handledGrid, i, j);
                            }
                            //na valw logiki gia "else"
                        }
                    }
                }
                else //an den exeis perithwrio na pas allo deksia - vgaineis ektos oriwn
                {
                    if (j < handledGrid.y_blocks - 1) //an exeis perithwrio na kateveis xwris na vgeis ektos oriwn
                    {
                        if (handledGrid.block_type[i, j + 1] != 3) //an mporeis na pas pros ta katw
                        {
                            if (handledGrid.block_type[i, j + 1] == 2) //des an to katw keli einai i eksodos
                            {
                                //MessageBox.Show("sdcs");
                                found = true;
                            }
                            else
                            {
                                handledGrid.block_type[i, j + 1] = 1; //pigaine
                                handledGrid.block_type[i, j] = 0;
                                j++;
                                agv_anim(handledGrid, i, j);
                            }
                        }
                        else //an den mporeis na pas pros ta katw
                        {
                            failed_down = true;
                            if (j < handledGrid.y_blocks - 1)
                            {
                                if (ob_down_found == false)
                                {
                                    handledGrid.block_type[i - 1, j] = 1; //pigaine ena keli aristera
                                    handledGrid.block_type[i, j] = 0;
                                    i--;
                                    agv_anim(handledGrid, i, j);
                                    if (handledGrid.block_type[i, j + 1] != 3) //kai des an mporeis na pas pros ta katw
                                    {
                                        if (handledGrid.block_type[i, j + 1] == 2) //des an to katw keli einai i eksodos
                                            found = true;
                                        else
                                        {
                                            handledGrid.block_type[i, j + 1] = 1; //pigaine
                                            handledGrid.block_type[i, j] = 0;
                                            j++;
                                            failed_down = false;
                                            agv_anim(handledGrid, i, j);
                                        }
                                    }
                                    else
                                    {
                                        handledGrid.block_type[i - 1, j] = 1;
                                        handledGrid.block_type[i, j] = 0;
                                        i--;
                                        failed_down = true;
                                        agv_anim(handledGrid, i, j);
                                    }
                                }
                                else
                                {
                                    ob_down_found = false;
                                    handledGrid.block_type[i + 1, j] = 1;
                                    handledGrid.block_type[i, j] = 0;
                                    i++;
                                    agv_anim(handledGrid, i, j);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (handledGrid.block_type[i + 1, j] == 2)
                        {

                            found = true;
                        }
                    }
                }
            }
            
            handledGrid.gridGraphics.FillRectangle(anim_brush,
                handledGrid.x_size - handledGrid.resolution,
                handledGrid.y_size - handledGrid.resolution,
                handledGrid.resolution, handledGrid.resolution);
             



            isFinished = true;
            

            return true;
        }


        private void agv_anim(Grid _grid, int cellx, int celly) //int xsize, int ysize, int res)
        {
            LocationX = cellx;
            LocationY = celly;
            for (int j = 0; j < _grid.x_size; j = j + _grid.resolution)
            {
                for (int i = 0; i < _grid.y_size; i = i + _grid.resolution)
                {
                    if (cellx * _grid.resolution == i && celly * _grid.resolution == j)
                    {
                        /*
                        _grid.gridGraphics.FillRectangle(
                            anim_brush,
                            _grid.array_of_points[i, j].X,
                            _grid.array_of_points[i, j].Y, 
                            _grid.resolution,
                            _grid.resolution);
                        */

                        
                        Form.Controls.Add(pb);
                        pb.BringToFront();
                        _grid.gridPanel.SendToBack();
                        pb.Image = new Bitmap(agv_pic);
                        pb.Width = _grid.resolution;
                        pb.Height = _grid.resolution;
                        pb.SizeMode = PictureBoxSizeMode.StretchImage;
                        pb.Location = new Point(
                            _grid.location_x + _grid.array_of_points[i, j].X,
                            _grid.location_y + _grid.array_of_points[i, j].Y);
                    }
                    

                }
            }
            Application.DoEvents();
            System.Threading.Thread.Sleep(50);
            Application.DoEvents();
        }

       
    }


}
