using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_Instance;
    static Managers Instance { get { Init(); return s_Instance; } }

    InputManager _input = new InputManager();
    public static InputManager input { get { return Instance._input; } }

    ResourcesManager _resourcesManager = new ResourcesManager();
    public static ResourcesManager resource { get { return Instance._resourcesManager; } }


    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        input.OnUpdate();
    }

    static void Init()
    {
        if (s_Instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if (go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }
            DontDestroyOnLoad(go);
            s_Instance = go.GetComponent<Managers>();
        }



    }

}
