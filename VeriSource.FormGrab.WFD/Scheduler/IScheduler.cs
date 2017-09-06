using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeriSource.FormGrab.WFD.Scheduler
{
    public interface IScheduler
    {
        event EventHandler<EventArgs> Run;

        int Interval { set; }

        void Start();

        void Stop();

        bool Prepare();

        void DirectoryCopy();
    }
}
