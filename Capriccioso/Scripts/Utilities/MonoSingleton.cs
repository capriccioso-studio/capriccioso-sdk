using UnityEngine;

namespace Capriccioso
{
    /// <summary>
    /// Allows mono behavior to become singleton class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MonoSingleton<T> : MonoBehaviour
                            where T : MonoBehaviour
    {
        #region Fields
        
        private static T s_instance;
        private static readonly object LOCK = new object();
        private static bool s_applicationQuitting = false;
        
        private bool _isPurged = false;
        
        #endregion

        #region Properties

        /// <summary>
        /// Instance of this singleton class
        /// </summary>
        /// <value></value>
        public static T Instance
        {
            get
            {
                if (s_applicationQuitting)
                {
                    lock (LOCK)
                    {
                        return s_instance ? s_instance : null;
                    }
                }

                lock (LOCK)
                {
                    if (s_instance == null)
                    {
                        LazyInitialize();
                    }
                }

                lock (LOCK)
                {
                    return s_instance;
                }
            }
        }

        #endregion

        #region Unity Events
        
        protected virtual bool Awake()
        {
            return Init();
        }
        
        protected virtual void OnDestroy()
        {
            if (!_isPurged)
            {
                s_applicationQuitting = true;
            }
        }

        #endregion

        #region Private Methods
        /// <summary>
        /// Initializes the singleton class
        /// </summary>
        /// <returns></returns>
        protected virtual bool Init()
        {
            if (s_instance == null)
            {
                LazyInitialize();
            }
            else
            {
                if (s_instance == this)
                {
                    return true;
                }

                Destroy(this.gameObject);
                return false; 
            }

            return true;
        }
        
        /// <summary>
        /// Lazy initialization of the singleton class, if there is no instance of this class in the scene, it will create one
        /// </summary>
        private static void LazyInitialize()
        {
            var type = typeof(T);

            var instances = (T[])FindObjectsOfType(type);
            switch (instances.Length)
            {
                case 0:
                    var go = new GameObject($"[{type}]");
                    s_instance = go.AddComponent<T>();
                    DontDestroyOnLoad(go);
                    break;
                case > 1:
                    Debug.LogError("There is more than 1 instance of this class in scene view , please check it");
                    s_instance = instances[0];
                    DontDestroyOnLoad(s_instance.gameObject);
                    return;
                default:
                    s_instance = instances[0];
                    DontDestroyOnLoad(s_instance.gameObject);
                    break;
            }
        }
        
        #endregion
    }   
}