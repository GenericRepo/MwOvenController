using MicrowaveOvenController.Interfaces;

namespace MicrowaveOvenController
{
    class Program
    {
        static void Main(string[] args)
        {
            IApplication application = new Application();
            application.Run();
        }
    }
}
