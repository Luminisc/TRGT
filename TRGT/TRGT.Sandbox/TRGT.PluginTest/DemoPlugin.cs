using TRGT.PluginCore;

namespace TRGT.PluginTest
{
    public class DemoPlugin : IPlugin
    {
        public string GetName()
        {
            return "DemoPlugin";
        }

        public IView GetView()
        {
            // potentially this could be changed - to not create control each time, but to send same instance.
            // but same instance might be bad practice, as we need to reinitialize it with new data, and maybe we need to clean up it.
            return new DemoControl();
        }

        public bool Initialize()
        {
            return true;
        }
    }
}