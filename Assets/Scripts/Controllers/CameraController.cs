using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CameraController : MonoBehaviour
{
    public Define.CameraMode _mode = Define.CameraMode.QuaterView;
    public Vector3 _delta = new Vector3(0, 6, -5);
    public GameObject player = null;

    void Update()
    {
        
    }

    void LateUpdate()
    {
        if (_mode == Define.CameraMode.QuaterView)
        {
            RaycastHit hit;
            if (Physics.Raycast(player.transform.position, _delta, out hit, _delta.magnitude, LayerMask.GetMask("Wall")))
            {
                float dist = (hit.point - player.transform.position).magnitude * 0.8f;
                transform.position = player.transform.position + _delta.normalized * dist;
            }
            else
            {
                transform.position = player.transform.position + _delta;
                transform.LookAt(player.transform);
            }
        }

    }

    public void SetQuaterView(Vector3 delta)
    {
        _mode = Define.CameraMode.QuaterView;
        _delta = delta;

    }

}
