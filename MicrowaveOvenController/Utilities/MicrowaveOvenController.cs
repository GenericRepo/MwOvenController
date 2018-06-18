using MicrowaveOvenController.Interfaces;
using System;

namespace MicrowaveOvenController.Utilities
{
    public enum MicrowaveOvenState
    {
        OPENED, CLOSED, RUNNING
    }

    public class MicrowaveOvenController
    {

        private MicrowaveOvenState microwaveState = MicrowaveOvenState.CLOSED;

        public MicrowaveOvenState MicrowaveState
        {
            get { return microwaveState; }
            private set {
                microwaveState = value; }
        }

        private readonly IMicrowaveOvenHW microwaveOvenHW;

        private ITimer timer;
        public ITimer Timer { get { return timer; } }

        private bool heaterOn;

        public bool HeaterOn
        {
            get { return heaterOn; }
            private set {
                heaterOn = value;
                if (heaterOn) { microwaveOvenHW.TurnOnHeater(); }
                else { microwaveOvenHW.TurnOffHeater(); }
            }
        }

        private bool lightOn;

        public bool LightOn
        {
            get { return lightOn; }
            private set { lightOn = value; }
        }

        public MicrowaveOvenController(IMicrowaveOvenHW microwaveOvenHW, MicrowaveOvenState startingState = MicrowaveOvenState.CLOSED)
        {
            this.microwaveOvenHW = microwaveOvenHW ?? throw new Exception("No microwave oven hardware passed!");

            microwaveOvenHW.StartButtonPressed += OnStartButtonPressed;
            microwaveOvenHW.DoorOpenChanged += OnDoorOpenedChanged;

            timer = new MicrowaveOvenTimer();
            timer.Finished += OnTimerFinished;

            SetInitialState(startingState);
        }

        private void SetInitialState(MicrowaveOvenState startingState)
        {
            MicrowaveState = startingState;
            LightOn = MicrowaveState == MicrowaveOvenState.OPENED;
            HeaterOn = MicrowaveState == MicrowaveOvenState.RUNNING;
        }

        private void OnStartButtonPressed(object sender, EventArgs e)
        {
            switch (microwaveState)
            {
                case MicrowaveOvenState.CLOSED:
                    microwaveState = MicrowaveOvenState.RUNNING;
                    timer.Start();
                    HeaterOn = true;
                    break;
                case MicrowaveOvenState.OPENED:
                    break;
                case MicrowaveOvenState.RUNNING:
                    timer.AddTime();
                    break;
                default:
                    throw new Exception("Unhandled state: " + microwaveState);
            }
        }

        private void OnDoorOpenedChanged(bool doorOpened)
        {
            switch (microwaveState)
            {
                case MicrowaveOvenState.OPENED:
                    if (!microwaveOvenHW.DoorOpen)
                    {
                        microwaveState = MicrowaveOvenState.CLOSED;
                        LightOn = false;
                    }
                    break;
                case MicrowaveOvenState.CLOSED:
                    if (microwaveOvenHW.DoorOpen)
                    {
                        microwaveState = MicrowaveOvenState.OPENED;
                        LightOn = true;
                    }
                    break;
                case MicrowaveOvenState.RUNNING:
                    if (microwaveOvenHW.DoorOpen)
                    {
                        microwaveState = MicrowaveOvenState.OPENED;
                        timer.Stop();
                        HeaterOn = false;
                        LightOn = true;
                    }
                    break;
                default:
                    throw new Exception("Unhandled state: " + microwaveState);
            }
        }

        private void OnTimerFinished(object sender, EventArgs e)
        {
            microwaveState = MicrowaveOvenState.CLOSED;
            timer.Stop();
            HeaterOn = false;
        }
    }
}