using System;
using System.Timers;
using MicrowaveOvenController.Interfaces;

namespace MicrowaveOvenController.Utilities
{
    class MicrowaveOvenTimer : ITimer
    {
        private const int timeToAdd = 60; // time to add in seconds

        public int TimeToFinish { get; private set; }

        public event EventHandler Finished;

        private Timer timer;

        public bool IsEnabled
        {
            get { return timer.Enabled; }
        }

        public MicrowaveOvenTimer()
        {
            timer = new Timer(1000);
            timer.Elapsed += OnElapsed;
        }

        public void Start()
        {
            TimeToFinish = timeToAdd;
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
        }

        public void AddTime()
        {
            TimeToFinish += timeToAdd;
        }

        public void InvokeFinished() => Finish();

        private void Finish()
        {
            Finished?.Invoke(this, EventArgs.Empty);
        }

        private void OnElapsed(object sender, ElapsedEventArgs args)
        {
            TimeToFinish--;
            if (TimeToFinish <= 0)
            {
                Finish();
            }
        }
    }
}
