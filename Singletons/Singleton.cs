using UnityEngine;

/// <summary> Simple and Generic Singleton Class </summary>
/// <typeparam name="T">Component type to make singleton instance</typeparam>
public class Singleton<T> : MonoBehaviour where T : Component
{
    private static readonly object _lock = new object();

    public static T _instance;

    /// <summary> Retrives Singleton instance. If there is none, creates a new GO and class component. </summary>
    /// <value> Returns class instance </value>
    public static T Instance
    {
        get
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    GameObject go = new GameObject();
                    go.name = typeof(T).Name;
                    go.hideFlags = HideFlags.HideAndDontSave;
                    _instance = go.AddComponent<T>();
                }
                return _instance;
            }
        }
        private set { }
    }

    /// <summary> Returns if instance already exists </summary>
    public static bool HasInstance => _instance != null;

    /// <summary> Destroys desired singleton </summary>
    public static void DestroySingleton()
    {
        if (_instance != null)
        {
            Destroy(_instance.gameObject);
            _instance = null;
        }
    }

    /// <summary> Initializes singleton with a saved instance </summary>
    /// <param name="newInstance"> Instance that will be saved in the singleton class </param>
    public static void InitializeWithDependencies(T newInstance)
    {
        if (_instance == null)
        {
            _instance = newInstance;
        }
    }


#if UNITY_EDITOR
    /// <summary> Sets singleton instance to null, but don't destroy it's GameObject </summary>
    public static void ResetInstance()
    {
        _instance = null;
    }

    /// <summary> Logs if singleton is null or instantiated </summary>
    public static void LogSingletonState()
    {
        Debug.Log($"Singleton is currently {(_instance == null ? "Null" : "Instantiated")}");
    }
#endif
}
