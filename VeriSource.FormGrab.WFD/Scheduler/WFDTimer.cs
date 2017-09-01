using System;

namespace WFD.Scheduler
{
    public class WFDTimer : IWFDTimer
    {
        public event EventHandler<WFDTimerEvent> Tick;

        public void OnTick()
        {
            Tick?.Invoke(this, new WFDTimerEvent());
        }

        //public void Interval(double interval)
        //{
        //    timer.Interval = interval;
        //}

        //public void Start()
        //{
        //    timer.Start();
        //}

        //public void Stop()
        //{
        //    timer.Stop();
        //}
    }
}