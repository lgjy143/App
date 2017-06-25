using System;
using System.Collections.Generic;
using System.Text;

namespace App.Framework.PlugIns
{
    public interface IAppPlugInManager
    {
        PlugInSourceList PlugInSources { get; }
    }
}
