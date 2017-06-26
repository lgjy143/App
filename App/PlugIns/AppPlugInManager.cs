using System;
using System.Collections.Generic;
using System.Text;

namespace App.Framework.PlugIns
{
    public class AppPlugInManager : IAppPlugInManager
    {
        public PlugInSourceList PlugInSources { get; }

#if NET46
        private static readonly object SyncObj = new object();
        private static bool _isRegisteredToAssemblyResolve;
#endif

        public AppPlugInManager()
        {
            PlugInSources = new PlugInSourceList();

            //TODO: Try to use AssemblyLoadContext.Default!
#if NET46
            RegisterToAssemblyResolve(PlugInSources);
#endif
        }

#if NET46
        private static void RegisterToAssemblyResolve(PlugInSourceList plugInSources)
        {
            if (_isRegisteredToAssemblyResolve)
            {
                return;
            }

            lock (SyncObj)
            {
                if (_isRegisteredToAssemblyResolve)
                {
                    return;
                }

                _isRegisteredToAssemblyResolve = true;

                AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
                {
                    return plugInSources.GetAllAssemblies().FirstOrDefault(a => a.FullName == args.Name);
                };
            }
        }

#endif
    }
}
