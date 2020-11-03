using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseScene : MonoBehaviour
{
    Define.Scene _sceneType = Define.Scene.Unkown;

    void Start()
    {
        
    }

    protected virtual void Init()
    {

    }

    public abstract void Clear();

}
