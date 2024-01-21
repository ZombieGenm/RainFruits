using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyGenerator : MonoBehaviour {

    public GameObject skyPrefab;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("GenSky", 10.71f, 10.71f);
    }

    void GenSky()
    {
        Instantiate(skyPrefab, new Vector3(-21.42f, 0, 0), Quaternion.identity);

    }
}
