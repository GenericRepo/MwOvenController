using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrowaveOvenController.Utilities
{
    public class Door
    {
        public event EventHandler Opened;
        public event EventHandler Closed;

        public void Open()
        {
            Opened?.Invoke(this, EventArgs.Empty);
        }

        public void Close()
        {
            Closed?.Invoke(this, EventArgs.Empty);
        }
    }
}
