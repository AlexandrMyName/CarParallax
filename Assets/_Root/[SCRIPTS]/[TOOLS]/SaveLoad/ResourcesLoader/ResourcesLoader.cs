using UnityEngine;


namespace Tools
{
    public static class ResourcesLoader 
    {
        public static T LoadPrefab<T>(ResourcesPath path) where T : Object => Resources.Load<T>(path.Path);
        
        public static T LoadView<T>(ResourcesPath path) where T : Object => Resources.Load<GameObject>(path.Path).GetComponent<T>();
        
    }
}
