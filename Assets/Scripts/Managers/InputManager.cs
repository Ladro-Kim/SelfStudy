using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager
{
    public Action KeyAction = null; 
    public Action<Define.MouseEvent> MouseAction = null; 

    bool _isPressed = false;

    public void OnUpdate()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (Input.anyKey && KeyAction != null) // 구독한 사람이 있다면.
        {
            KeyAction.Invoke();
        }

        if (MouseAction != null) // 구독한 사람이 있다면.
        {
            if(Input.GetMouseButton(0))
            {
                MouseAction.Invoke(Define.MouseEvent.Press);
                _isPressed = true;
            }
            else
            {
                if (_isPressed)
                {
                    MouseAction.Invoke(Define.MouseEvent.Click);
                }
                _isPressed = false;
            }
        }

    }
}
