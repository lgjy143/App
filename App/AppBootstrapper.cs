using App.Framework.Configuration.Startup;
using App.Framework.Dependency;
using App.Framework.Dependency.Installers;
using App.Framework.Modules;
using App.Framework.PlugIns;
using Castle.Core.Logging;
using Castle.MicroKernel.Registration;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace App.Framework
{
    /// <summary>
    /// This is the main class that is responsible to start entire App system.
    /// Prepares dependency injection and registers core components needed for startup.
    /// It must be instantiated and initialized (see <see cref="Initialize"/>) first in an application.
    /// </summary>
    public class AppBootstrapper : IDisposable
    {
        /// <summary>
        /// Get the startup module of the application which depends on other used modules.
        /// </summary>
        public Type StartupModule { get; }

        /// <summary>
        /// A list of plug in folders.
        /// </summary>
        public PlugInSourceList PlugInSources { get; }

        /// <summary>
        /// Gets IIocManager object used by this class.
        /// </summary>
        public IIocManager IocManager { get; }

        /// <summary>
        /// Is this object disposed before?
        /// </summary>
        protected bool IsDisposed;

        private AppModuleManager _moduleManager;
        private ILogger _logger;

        /// <summary>
        /// Creates a new <see cref="AppBootstrapper"/> instance.
        /// </summary>
        /// <param name="startupModule">Startup module of the application which depends on other used modules. Should be derived from <see cref="AppModule"/>.</param>
        private AppBootstrapper([NotNull] Type startupModule)
            : this(startupModule, Dependency.IocManager.Instance)
        {

        }

        /// <summary>
        /// Creates a new <see cref="AppBootstrapper"/> instance.
        /// </summary>
        /// <param name="startupModule">Startup module of the application which depends on other used modules. Should be derived from <see cref="AppModule"/>.</param>
        /// <param name="iocManager">IIocManager that is used to bootstrap the App system</param>
        private AppBootstrapper([NotNull] Type startupModule, [NotNull] IIocManager iocManager)
        {
            Check.NotNull(startupModule, nameof(startupModule));
            Check.NotNull(iocManager, nameof(iocManager));

            if (!typeof(AppModule).GetTypeInfo().IsAssignableFrom(startupModule))
            {
                throw new ArgumentException($"{nameof(startupModule)} should be derived from {nameof(AppModule)}.");
            }

            StartupModule = startupModule;
            IocManager = iocManager;

            //PlugInSources = new PlugInSourceList();
            _logger = NullLogger.Instance;

            AddInterceptorRegistrars();
        }

        /// <summary>
        /// Creates a new <see cref="AppBootstrapper"/> instance.
        /// </summary>
        /// <typeparam name="TStartupModule">Startup module of the application which depends on other used modules. Should be derived from <see cref="AppModule"/>.</typeparam>
        public static AppBootstrapper Create<TStartupModule>()
            where TStartupModule : AppModule
        {
            return new AppBootstrapper(typeof(TStartupModule));
        }

        /// <summary>
        /// Creates a new <see cref="AppBootstrapper"/> instance.
        /// </summary>
        /// <typeparam name="TStartupModule">Startup module of the application which depends on other used modules. Should be derived from <see cref="AppModule"/>.</typeparam>
        /// <param name="iocManager">IIocManager that is used to bootstrap the App system</param>
        public static AppBootstrapper Create<TStartupModule>([NotNull] IIocManager iocManager)
            where TStartupModule : AppModule
        {
            return new AppBootstrapper(typeof(TStartupModule), iocManager);
        }

        /// <summary>
        /// Creates a new <see cref="AppBootstrapper"/> instance.
        /// </summary>
        /// <param name="startupModule">Startup module of the application which depends on other used modules. Should be derived from <see cref="AppModule"/>.</param>
        public static AppBootstrapper Create([NotNull] Type startupModule)
        {
            return new AppBootstrapper(startupModule);
        }

        /// <summary>
        /// Creates a new <see cref="AppBootstrapper"/> instance.
        /// </summary>
        /// <param name="startupModule">Startup module of the application which depends on other used modules. Should be derived from <see cref="AppModule"/>.</param>
        /// <param name="iocManager">IIocManager that is used to bootstrap the App system</param>
        public static AppBootstrapper Create([NotNull] Type startupModule, [NotNull] IIocManager iocManager)
        {
            return new AppBootstrapper(startupModule, iocManager);
        }

        private void AddInterceptorRegistrars()
        {
            //ValidationInterceptorRegistrar.Initialize(IocManager);
            //AuditingInterceptorRegistrar.Initialize(IocManager);
            //UnitOfWorkRegistrar.Initialize(IocManager);
            //AuthorizationInterceptorRegistrar.Initialize(IocManager);
        }

        /// <summary>
        /// Initializes the App system.
        /// </summary>
        public virtual void Initialize()
        {
            ResolveLogger();

            try
            {
                RegisterBootstrapper();
                IocManager.IocContainer.Install(new AppCoreInstaller());

                //IocManager.Resolve<AppPlugInManager>().PlugInSources.AddRange(PlugInSources);
                IocManager.Resolve<AppStartupConfiguration>().Initialize();

                _moduleManager = IocManager.Resolve<AppModuleManager>();
                _moduleManager.Initialize(StartupModule);
                _moduleManager.StartModules();
            }
            catch (Exception ex)
            {
                _logger.Fatal(ex.ToString(), ex);
                throw;
            }
        }

        private void ResolveLogger()
        {
            if (IocManager.IsRegistered<ILoggerFactory>())
            {
                _logger = IocManager.Resolve<ILoggerFactory>().Create(typeof(AppBootstrapper));
            }
        }

        private void RegisterBootstrapper()
        {
            if (!IocManager.IsRegistered<AppBootstrapper>())
            {
                IocManager.IocContainer.Register(
                    Component.For<AppBootstrapper>().Instance(this)
                    );
            }
        }

        /// <summary>
        /// Disposes the App system.
        /// </summary>
        public virtual void Dispose()
        {
            if (IsDisposed)
            {
                return;
            }

            IsDisposed = true;

            _moduleManager?.ShutdownModules();
        }
    }
}
