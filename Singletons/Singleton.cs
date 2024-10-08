using UnityEngine;

/// <summary> Simple and Generic Singleton Class </summary>
/// <typeparam name="T">Component type to make singleton instance</typeparam>
public class Singleton<T> : MonoBehaviour where T : Component
{
    public static T _instance;

    /// <summary> Retrives Singleton instance. If there is none, creates a new GO and class component. </summary>
    /// <value> Returns class instance </value>
    public static T Instance
    {
        get
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
        private set { }
    }
}
