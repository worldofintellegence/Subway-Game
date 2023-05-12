using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if !(UNITY_WINRT || UNITY_WINRT_8_1 || UNITY_WINRT_10_0)
//using Facebook.MiniJSON;
#endif

public static class DictionaryExtensions {

    public static bool TryGetValue<T>(this Dictionary<string, object> dict, string key, out T value)
    {
        if (dict != null && dict.ContainsKey(key))
        {
            if (dict[key].GetType() == typeof(T))
            {
                value = (T)dict[key];
                return true;
            }
            else
            {
                //Debug.Log("Trying to get " + typeof(T).ToString() + " but the item is " + dict[key].GetType().ToString() + ", trying to convert");

                try
                {
                    value = (T)System.Convert.ChangeType(dict[key], typeof(T));
                    return true;
                }
                catch { }
            }
        }
        value = default(T);
        return false;
    }
/*#if !(UNITY_WINRT || UNITY_WINRT_8_1 || UNITY_WINRT_10_0)
    public static Dictionary<string, object> JsonToDictionary(string json)
    {
        if (json != null && json.Length > 0)
        {
            return Json.Deserialize(json) as Dictionary<string, object>;
        }
        return null;
    }
#endif*/
}
