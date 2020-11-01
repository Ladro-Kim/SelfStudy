using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager
{
    public T Load<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }

    public GameObject Instantiate(string path)
    {
        GameObject prefeb = Load<GameObject>($"Prefebs/{path}");
        if (prefeb == null)
        {
            Debug.Log($"Failed to load prefeb : prefebs/{path}");
            return null;
        }

        return Object.Instantiate(prefeb);
    }

    public void Destroy(GameObject go)
    {
        if (go == null)
        {
            return;
        }
        else
        {
            Object.Destroy(go);
        }
    }


}
