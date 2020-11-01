using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefebTest : MonoBehaviour
{
    public GameObject prefeb;

    void Start()
    {
        // Instantiate(prefeb);
        prefeb = Managers.resource.Instantiate("Tank");
        Destroy(prefeb, 3);

        
        // Instantiate(Resources.Load<GameObject>("Prefebs/Tank"));
    }

    void Update()
    {
        
    }
}
