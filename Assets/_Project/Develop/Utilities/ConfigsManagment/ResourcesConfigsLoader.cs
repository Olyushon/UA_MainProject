using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ResourcesConfigsLoader : IConfigsLoader
{
    private readonly ResourcesLoader _resources;

    private readonly Dictionary<Type, string> _configsResourcesPaths = new()
    {

    };

    public ResourcesConfigsLoader(ResourcesLoader resources)
    {
        _resources = resources;
    }

    public IEnumerator LoadAsync(Action<Dictionary<Type, object>> onConfigsLoaded)
    {
        Dictionary<Type, object> loadedConfigs = new();

        foreach (KeyValuePair<Type, string> configResourcesPath in _configsResourcesPaths)
        {
            ScriptableObject config = _resources.Load<ScriptableObject>(configResourcesPath.Value);
            loadedConfigs.Add(configResourcesPath.Key, config);
            yield return null;
        }

        onConfigsLoaded?.Invoke(loadedConfigs);
    }
}