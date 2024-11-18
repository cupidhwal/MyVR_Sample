using UnityEngine;

namespace MyVrSample
{
    public class VR_PersistentSingleton<T> : VR_Singleton<T> where T : VR_Singleton<T>
    {
        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(gameObject);
        }
    }
}
