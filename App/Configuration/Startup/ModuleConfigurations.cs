namespace App.Framework.Configuration.Startup
{
    internal class ModuleConfigurations : IModuleConfigurations
    {
        public IAppStartupConfiguration AppConfiguration { get; private set; }

        public ModuleConfigurations(IAppStartupConfiguration appConfiguration)
        {
            AppConfiguration = appConfiguration;
        }
    }
}
