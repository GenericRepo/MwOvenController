using System;
using MicrowaveOvenController.Interfaces;

namespace MicrowaveOvenController.Utilities
{
    class MicrowaveOvenHW : IMicrowaveOvenHW
    {
        public void TurnOnHeater()
        {
            Console.WriteLine("Heater ON");
        }

        public void TurnOffHeater()
        {
            Console.WriteLine("Heater OFF");
        }

        private bool doorOpen = false;
        public bool DoorOpen
        {
            get { return doorOpen; }
        }

        public event Action<bool> DoorOpenChanged;

        public event EventHandler StartButtonPressed;
    }
}
