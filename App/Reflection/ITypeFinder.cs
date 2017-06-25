﻿using System;
using System.Collections.Generic;
using System.Text;

namespace App.Framework.Reflection
{
    public interface ITypeFinder
    {
        Type[] Find(Func<Type, bool> predicate);

        Type[] FindAll();
    }
}
