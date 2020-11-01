using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollision : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        // GameObject.FindGameObjectsWithTag("Player");

        if (Input.GetMouseButtonDown(0))
        {
            // int mask = (1 << 8 | 1 << 9); // 8번째 비트를 On.
            LayerMask mask = LayerMask.GetMask("Monster") | LayerMask.GetMask("Wall");

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 10f, mask))
            {
                Debug.Log(hit.collider.gameObject.tag); 
                Debug.DrawRay(Camera.main.transform.position, ray.direction * 10f, Color.red, 1f) ;
                Debug.Log(hit.collider.gameObject.name);
            }
        }
    }
}
