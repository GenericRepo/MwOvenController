using System;

namespace MicrowaveOvenController.Interfaces
{
    public interface ITimer
    {
        event EventHandler Finished;

        bool IsEnabled { get; }

        void Start();

        void Stop();

        void AddTime();

        void InvokeFinished();

    }
}