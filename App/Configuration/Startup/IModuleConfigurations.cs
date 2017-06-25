namespace App.Framework.Configuration.Startup
{
    /// <summary>
    /// Used to provide a way to configure modules.
    /// Create entension methods to this class to be used over <see cref="IAppStartupConfiguration.Modules"/> object.
    /// </summary>
    public interface IModuleConfigurations
    {
        /// <summary>
        /// Gets the App configuration object.
        /// </summary>
        IAppStartupConfiguration AppConfiguration { get; }
    }
}
