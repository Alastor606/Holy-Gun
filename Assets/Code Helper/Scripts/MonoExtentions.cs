namespace CodeHelper.Unity
{
    using System;
    using UnityEngine;
    using System.Collections;

    internal static class MonoExtentions
    {

        /// <summary>Starts local coroutine, wait given time and invoke action </summary>
        /// <param name="delay">Delay</param>
        internal static void WaitAndDo(this MonoBehaviour self, float delay, Action<MonoBehaviour> toDo)
        {
            self.StartCoroutine(Waiter());
            IEnumerator Waiter()
            {
                yield return new WaitForSeconds(delay);
                toDo.Invoke(self);
            }
        }

        /// <summary>Starts local coroutine, wait given time and invoke action </summary>
        /// <param name="delay">Delay</param>
        internal static void WaitAndDo<T>(this T self, float delay, Action<T> toDo) where T : UnityEngine.Object
        {
            var go = Camera.main.gameObject.GetComponent<MonoBehaviour>();
            go.StartCoroutine(Waiter());
            IEnumerator Waiter()
            {
                yield return new WaitForSeconds(delay);
                toDo.Invoke(self);
            }
        }

        internal static T WaitAndDoWithReturn<T>(this T self, float delay, Action<T> toDo) where T : UnityEngine.Object
        {
            var go = Camera.main.gameObject.GetComponent<MonoBehaviour>();
            
            go.StartCoroutine(Waiter());
            IEnumerator Waiter()
            {
                yield return new WaitForSeconds(delay);
                toDo.Invoke(self);
            }
            return self;
        }


        /// <summary>Instanse object with given params</summary>
        internal static T Instance<T>(this MonoBehaviour self, T prefab, Vector3 position, Transform parent = null, Quaternion rotation = default) where T : UnityEngine.Object
        {
            var rot = rotation == default ? Quaternion.identity : rotation;
            var obj = parent == null ? UnityEngine.Object.Instantiate(prefab, position, rot) : UnityEngine.Object.Instantiate(prefab, parent);
            return obj;
        }

        /// <summary> Log the object value to unity console</summary>
        internal static void Print<T>(this T self) => Debug.Log(self);

        /// <summary> Log error the object value to unity console</summary>
        internal static void PrintError<T>(this T self) => Debug.LogError(self);

        /// <summary> Log the all objects to unity console</summary>
        /// <param name="withIndex">If true log the index of every objet</param>
        internal static void PrintAll<T>(this T[] self, bool withIndex = false)
        {
            for (int i = 0; i < self.Length; i++)
                Debug.Log(withIndex == true ? $"Index - {i} \n Value - " + self[i] : self[i]) ;
            
        }


        /// <summary> Log error the all objects to unity console</summary>
        internal static void PrintErrorAll<T>(this T[] self) => self.AllDo((x) => Debug.LogError(x));

        /// <summary> Log object from collection by index to unity console</summary>
        internal static void Print<T>(this T[] self, int index) => Debug.Log(self[index]);

        internal static void Destroy<T>(this T self) where T : UnityEngine.Object => UnityEngine.Object.Destroy(self);

        internal static void Destroy<T>(this T self, float time) where T : UnityEngine.Object => UnityEngine.Object.Destroy(self, time);

        internal static T Instance<T>(this T self, Vector3 pos, Quaternion rot = default, float time = 0) where T : UnityEngine.Object =>
            UnityEngine.Object.Instantiate(self,pos, rot);

        internal static void Instance<T>(this T self, Vector3 pos,out T obj, Quaternion rot = default, float time = 0) where T : UnityEngine.Object =>
            obj = UnityEngine.Object.Instantiate(self, pos, rot);


        /// <summary> Log`s the object name, message prints after the name</summary>
        internal static void PrintName<T>(this T self, string message = null) where T : UnityEngine.Object => Debug.Log(self.name + message);

        internal static T[] ToArray<T>(this T self, params T[] additional) where T : UnityEngine.Object
        {
            T[] array = new T[additional.Length + 1];
            array[0] = self;
            for(int i = 0; i < additional.Length; i++) array[i + 1] = additional[i];
            return array;
        }
    }
}

