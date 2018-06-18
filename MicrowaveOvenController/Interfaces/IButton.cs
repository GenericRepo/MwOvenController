using System;

namespace MicrowaveOvenController.Interfaces
{
    public interface IButton
    {
        event EventHandler ButtonPressed;

        void PressButton();
    }
}
