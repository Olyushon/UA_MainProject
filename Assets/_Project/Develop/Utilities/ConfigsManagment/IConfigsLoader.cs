using System.Collections;
using System.Collections.Generic;
using System;

namespace Utilities.ConfigsManagment
{
    public interface IConfigsLoader
    {
        IEnumerator LoadAsync(Action<Dictionary<Type, object>> onConfigsLoaded);
    }
}