using UnityEngine;
public abstract class Singleton<T> : MonoBehaviour where T : Component
{
    public static T Instance;
    public abstract void AwakeFunction();
    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this as T;
            DontDestroyOnLoad(gameObject);
            AwakeFunction();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}