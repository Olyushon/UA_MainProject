using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigProviderService
{
    private readonly Dictionary<Type, object> _configs = new();

    public T GetConfig<T>() where T : class
    {
        if (_configs.ContainsKey(typeof(T)) == false)
            throw new InvalidOperationException($"Config not found by {typeof(T)}");

        return _configs[typeof(T)] as T;
    }
}
