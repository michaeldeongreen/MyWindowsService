using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService1
{
    public partial class Service1 : ServiceBase
    {
        private System.Timers.Timer timer;
        private static int _counter = 0;
        public Service1()
        {
            this.ServiceName = "Service1";
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            this.timer = new System.Timers.Timer(120000);
            this.timer.AutoReset = true;
            this.timer.Elapsed += new System.Timers.ElapsedEventHandler(this.timer_Elapsed);
            this.timer.Start();
        }

        private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"c:\temp\service1.txt", true))
            {
                file.WriteLine(string.Format("Counter is: {0}", _counter));
            }
            _counter++;
        }

        protected override void OnStop()
        {
            this.timer.Stop();
            this.timer = null;
        }
    }
}
