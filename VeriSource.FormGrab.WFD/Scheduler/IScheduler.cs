using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeriSource.FormGrab.WFD.Scheduler
{
    public interface IScheduler
    {
        bool Prepare();

        void DirectoryCopy();
    }
}
