﻿using App.Framework.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Framework
{
    /// <summary>
    /// Kernel (core) module of the App system.
    /// No need to depend on this, it's automatically the first module always.
    /// </summary>
    public sealed class AppKernelModule : AppModule
    {
        public override void PreInitialize()
        {
            //IocManager.AddConventionalRegistrar(new BasicConventionalRegistrar());

            //IocManager.Register<IScopedIocResolver, ScopedIocResolver>(DependencyLifeStyle.Transient);
            //IocManager.Register(typeof(IAmbientScopeProvider<>), typeof(DataContextAmbientScopeProvider<>), DependencyLifeStyle.Transient);

            //AddAuditingSelectors();
            //AddLocalizationSources();
            //AddSettingProviders();
            //AddUnitOfWorkFilters();
            //ConfigureCaches();
            //AddIgnoredTypes();
        }

        public override void Initialize()
        {
            //foreach (var replaceAction in ((AppStartupConfiguration)Configuration).ServiceReplaceActions.Values)
            //{
            //    replaceAction();
            //}

            //IocManager.IocContainer.Install(new EventBusInstaller(IocManager));

            //IocManager.RegisterAssemblyByConvention(typeof(AppKernelModule).GetAssembly(),
            //    new ConventionalRegistrationConfig
            //    {
            //        InstallInstallers = false
            //    });
        }

        public override void PostInitialize()
        {
            //RegisterMissingComponents();

            //IocManager.Resolve<SettingDefinitionManager>().Initialize();
            //IocManager.Resolve<FeatureManager>().Initialize();
            //IocManager.Resolve<PermissionManager>().Initialize();
            //IocManager.Resolve<LocalizationManager>().Initialize();
            //IocManager.Resolve<NotificationDefinitionManager>().Initialize();
            //IocManager.Resolve<NavigationManager>().Initialize();

            //if (Configuration.BackgroundJobs.IsJobExecutionEnabled)
            //{
            //    var workerManager = IocManager.Resolve<IBackgroundWorkerManager>();
            //    workerManager.Start();
            //    workerManager.Add(IocManager.Resolve<IBackgroundJobManager>());
            //}
        }

        public override void Shutdown()
        {
            //if (Configuration.BackgroundJobs.IsJobExecutionEnabled)
            //{
            //    IocManager.Resolve<IBackgroundWorkerManager>().StopAndWaitToStop();
            //}
        }

        private void AddUnitOfWorkFilters()
        {
            //Configuration.UnitOfWork.RegisterFilter(AppDataFilters.SoftDelete, true);
            //Configuration.UnitOfWork.RegisterFilter(AppDataFilters.MustHaveTenant, true);
            //Configuration.UnitOfWork.RegisterFilter(AppDataFilters.MayHaveTenant, true);
        }

        private void AddSettingProviders()
        {
            //Configuration.Settings.Providers.Add<LocalizationSettingProvider>();
            //Configuration.Settings.Providers.Add<EmailSettingProvider>();
            //Configuration.Settings.Providers.Add<NotificationSettingProvider>();
            //Configuration.Settings.Providers.Add<TimingSettingProvider>();
        }

        private void AddAuditingSelectors()
        {
            //Configuration.Auditing.Selectors.Add(
            //    new NamedTypeSelector(
            //        "App.ApplicationServices",
            //        type => typeof(IApplicationService).IsAssignableFrom(type)
            //    )
            //);
        }

        private void AddLocalizationSources()
        {
            //Configuration.Localization.Sources.Add(
            //    new DictionaryBasedLocalizationSource(
            //        AppConsts.LocalizationSourceName,
            //        new XmlEmbeddedFileLocalizationDictionaryProvider(
            //            typeof(AppKernelModule).GetAssembly(), "App.Localization.Sources.AppXmlSource"
            //        )));
        }

        private void ConfigureCaches()
        {
            //Configuration.Caching.Configure(AppCacheNames.ApplicationSettings, cache =>
            //{
            //    cache.DefaultSlidingExpireTime = TimeSpan.FromHours(8);
            //});

            //Configuration.Caching.Configure(AppCacheNames.TenantSettings, cache =>
            //{
            //    cache.DefaultSlidingExpireTime = TimeSpan.FromMinutes(60);
            //});

            //Configuration.Caching.Configure(AppCacheNames.UserSettings, cache =>
            //{
            //    cache.DefaultSlidingExpireTime = TimeSpan.FromMinutes(20);
            //});
        }

        private void AddIgnoredTypes()
        {
            //var commonIgnoredTypes = new[]
            //{
            //    typeof(Stream),
            //    typeof(Expression)
            //};

            //foreach (var ignoredType in commonIgnoredTypes)
            //{
            //    Configuration.Auditing.IgnoredTypes.AddIfNotContains(ignoredType);
            //    Configuration.Validation.IgnoredTypes.AddIfNotContains(ignoredType);
            //}

            //var validationIgnoredTypes = new[] { typeof(Type) };
            //foreach (var ignoredType in validationIgnoredTypes)
            //{
            //    Configuration.Validation.IgnoredTypes.AddIfNotContains(ignoredType);
            //}
        }

        private void RegisterMissingComponents()
        {
            //if (!IocManager.IsRegistered<IGuidGenerator>())
            //{
            //    IocManager.IocContainer.Register(
            //        Component
            //            .For<IGuidGenerator, SequentialGuidGenerator>()
            //            .Instance(SequentialGuidGenerator.Instance)
            //    );
            //}

            //IocManager.RegisterIfNot<IUnitOfWork, NullUnitOfWork>(DependencyLifeStyle.Transient);
            //IocManager.RegisterIfNot<IAuditingStore, SimpleLogAuditingStore>(DependencyLifeStyle.Singleton);
            //IocManager.RegisterIfNot<IPermissionChecker, NullPermissionChecker>(DependencyLifeStyle.Singleton);
            //IocManager.RegisterIfNot<IRealTimeNotifier, NullRealTimeNotifier>(DependencyLifeStyle.Singleton);
            //IocManager.RegisterIfNot<INotificationStore, NullNotificationStore>(DependencyLifeStyle.Singleton);
            //IocManager.RegisterIfNot<IUnitOfWorkFilterExecuter, NullUnitOfWorkFilterExecuter>(DependencyLifeStyle.Singleton);
            //IocManager.RegisterIfNot<IClientInfoProvider, NullClientInfoProvider>(DependencyLifeStyle.Singleton);
            //IocManager.RegisterIfNot<ITenantStore, NullTenantStore>(DependencyLifeStyle.Singleton);
            //IocManager.RegisterIfNot<ITenantResolverCache, NullTenantResolverCache>(DependencyLifeStyle.Singleton);

            //if (Configuration.BackgroundJobs.IsJobExecutionEnabled)
            //{
            //    IocManager.RegisterIfNot<IBackgroundJobStore, InMemoryBackgroundJobStore>(DependencyLifeStyle.Singleton);
            //}
            //else
            //{
            //    IocManager.RegisterIfNot<IBackgroundJobStore, NullBackgroundJobStore>(DependencyLifeStyle.Singleton);
            //}
        }
    }
}
