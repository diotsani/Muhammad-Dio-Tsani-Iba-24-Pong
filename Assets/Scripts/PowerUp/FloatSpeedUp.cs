using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatSpeedUp : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 1f);
        transform.localPosition += new Vector3(0, 0.5f, 0);
    }

    void Update()
    {
        
    }
}
