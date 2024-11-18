using UnityEngine;

namespace MyVrSample
{
    public class VR_Singleton<T> : MonoBehaviour where T : VR_Singleton<T>
    {
        private static T instance;

        public static T Instance
        {
            get { return instance; }
        }

        public static bool InstancExist
        {
            get { return instance != null; }
        }

        protected virtual void Awake()
        {
            if (InstancExist)
            {
                Destroy(this.gameObject);
                return;
            }
            instance = (T)this;            
        }

        protected virtual void OnDestroy()
        {
            if(instance == this)
            {
                instance = null;
            }
        }
    }
}
