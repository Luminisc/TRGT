namespace TRGT.PluginCore
{
    public interface IPlugin
    {
        public bool Initialize();
        public string GetName();
        public IView GetView();
    }
}