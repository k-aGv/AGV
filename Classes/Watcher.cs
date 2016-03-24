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
    class Watcher
    {
        public static aGv_MainForm Form { get; set; }
        protected int i = 1;
        public string[] agvNames;
        public Timer agvWatcher = new Timer();

        public AGV _a;
        protected Point Location;
        public Form cameFrom;

        public void initialize(Form f, AGV a)
        {
            _a = a;
            cameFrom = f;
        }

        public void setNames(string agv_name)
        {

            agvNames = new string[i];
            agvNames[i] = agv_name;
            i++;
        }
        public Point agvLocation(AGV agvInfo)
        {
            Location = new Point(agvInfo.LocationX, agvInfo.LocationY);
            return Location;
        }
        public void _Start()
        {
            agvWatcher.Interval = 100;
            //agvWatcher.
            agvWatcher.Tick += new EventHandler(agvWatcher_Tick);
            agvWatcher.Start();

        }
        public void Stop()
        {
            agvWatcher.Stop();
        }

        protected void agvWatcher_Tick(object sender, EventArgs e)
        {
            Label watcherLabel = new Label();
            Point L = new Point(600, 287);
            watcherLabel.Location = L;
            watcherLabel.Text = agvLocation(_a) + " ";
            //MessageBox.Show(_a.LocationX + " " + _a.LocationY);
            cameFrom.Controls.Add(watcherLabel);
        }
    }
}

