using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusCoinController : MonoBehaviour
{

    public AudioSource fallCoin;
    float fallSpeed;
    float rotSpeed;
    float windSpeed;

    // Use this for initialization
    void Start()
    {
        //コインの落ちる音
        fallCoin = GetComponent<AudioSource>();
        //落ちる速度の設定
        this.fallSpeed = 0.05f + 0.075f * Random.value;
        //回る速度設定
        this.rotSpeed = 5f + 3f * Random.value;
        this.windSpeed = -0.001f + -0.003f * Random.value;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(windSpeed, -fallSpeed, 0, Space.World);
        transform.Rotate(0, 0, rotSpeed);

        if (transform.position.y < -5.5f)
        {
            Destroy(gameObject);
        }
    }
}
