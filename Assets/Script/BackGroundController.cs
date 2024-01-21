using UnityEngine;
using System.Collections;

public class BackGroundController : MonoBehaviour
{

    void Update()
    {
       
    }

    void FixedUpdate()
    {
        transform.Translate(-0.03f, 0, 0);
        if (transform.position.x < -16.29f)
        {
            transform.position = new Vector3(37.5f, 0, 0);
        }
    }
}