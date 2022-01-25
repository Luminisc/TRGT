using TRGT.PluginCore;

namespace TRGT.PluginTest
{
    public class DemoPlugin : IPlugin
    {
        public string GetName()
        {
            return "DemoPlugin";
        }

        public bool Initialize()
        {
            return true;
        }
    }
}