using UnityEngine;

public class ResourcesLoader
{
    public T Load<T>(string resourcePath) where T : Object
        => Resources.Load<T>(resourcePath);
}
