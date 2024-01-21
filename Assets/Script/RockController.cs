using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class RockController : MonoBehaviour
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
        this.fallSpeed = 0.04f + 0.045f * Random.value;
        //回る速度設定
        this.rotSpeed = 5f + 3f * Random.value;
        this.windSpeed = -0.001f + -0.003f * Random.value;


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(windSpeed, -fallSpeed, 0, Space.World);
        transform.Rotate(0, 0, rotSpeed);

        if (transform.position.y < -5.5f)
        {
            //落とした音を鳴らす
            fallCoin.PlayOneShot(fallCoin.clip);

            if (this.gameObject.tag != "BonusCoin")
            {
                //ゲームオーバーカウントダウン
                GameObject.Find("UI").GetComponent<UIController>().GameOver();
            }

            Destroy(gameObject);
        }
    }
}