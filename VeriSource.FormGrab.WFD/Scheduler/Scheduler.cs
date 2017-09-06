using System;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace VeriSource.FormGrab.WFD.Scheduler
{
    public class Scheduler : IScheduler
    {
        private Timer _timer;

        public Scheduler()
        {
            _timer = new Timer();
        }

        public event EventHandler<EventArgs> Run;

        public void Start()
        {
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }

        public int Interval
        {
            set
            {
                _timer.Interval = value;
            }
        }

        public void DirectoryCopy()
        {
            throw new NotImplementedException();
        }

        public bool Prepare()
        {
            throw new NotImplementedException();
        }

    }
}