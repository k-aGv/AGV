using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



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
            int x=0;//cant be null
            return x;
        }
        public int GetLocationY(int AGV_ID)
        {
            int y=0;//cant be null
            return y;
        }
    }
}
