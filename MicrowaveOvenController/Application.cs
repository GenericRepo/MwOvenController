using System;
using MicrowaveOvenController.Utilities;
using MicrowaveOvenController.Interfaces;

namespace MicrowaveOvenController
{
    public class Application : IApplication
    {
        private Utilities.MicrowaveOvenController controller;

        public Application()
        {
            IMicrowaveOvenHW microwaveOvenHW = new MicrowaveOvenHW();
            controller = new Utilities.MicrowaveOvenController(microwaveOvenHW);
        }

        public void Run()
        {
            //throw new NotImplementedException();
        }
    }
}
