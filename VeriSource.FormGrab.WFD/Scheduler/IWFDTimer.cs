using System;

namespace WFD.Scheduler
{
    internal interface IWFDTimer
    {
        event EventHandler<WFDTimerEvent> Tick;

    }

    public class WFDTimerEvent : EventArgs { }
}