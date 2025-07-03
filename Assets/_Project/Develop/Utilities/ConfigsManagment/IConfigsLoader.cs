using System.Collections;
using System.Collections.Generic;
using System;

public interface IConfigsLoader
{
    IEnumerator LoadAsync(Action<Dictionary<Type, object>> onConfigsLoaded);
}
