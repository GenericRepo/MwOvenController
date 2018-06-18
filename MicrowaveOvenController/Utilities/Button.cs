using System;
using MicrowaveOvenController.Interfaces;

namespace MicrowaveOvenController.Utilities
{
    public class StartButton : IButton
    {
        public event EventHandler ButtonPressed;

        public void PressButton()
        {
            ButtonPressed?.Invoke(this, EventArgs.Empty);
        }
    }
}
