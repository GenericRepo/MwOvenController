using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrowaveOvenController.Interfaces
{
    public interface IDoor
    {
        event EventHandler DoorOpened;

        event EventHandler DoorClosed;

        void OpenDoor();

        void CloseDoor();
    }
}
