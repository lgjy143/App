using System;
using System.Collections.Generic;
using System.Text;

namespace App.Framework.Modules
{
    public interface IAppModuleManager
    {
        AppModuleInfo StartupModule { get; }

        IReadOnlyList<AppModuleInfo> Modules { get; }

        void Initialize(Type startupModule);

        void StartModules();

        void ShutdownModules();
    }
}
