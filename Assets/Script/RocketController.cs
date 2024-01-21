using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketController : MonoBehaviour {

    public AudioSource SoundGet;    //コインゲット音


    int GameOverCount;

    // Use this for initialization
    void Start () {
        SoundGet = GetComponent<AudioSource>();
        
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        //移動
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (transform.position.x > -2.3)
            {
                //左へ移動
                transform.Translate(-0.1f, 0, 0);
                this.GetComponent<SpriteRenderer>().flipX = true;
            }
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //右へ移動
            if (transform.position.x < 2.3)
            {
                transform.Translate(0.1f, 0, 0);
                this.GetComponent<SpriteRenderer>().flipX = false;
            }
        }

    }


    void OnTriggerEnter2D(Collider2D coll)
    {

        if (UIController.GameOverCount != 0)
        {
            //ゲットした音を鳴らす
            SoundGet.PlayOneShot(SoundGet.clip);
            if(coll.gameObject.tag=="BonusCoin")
            {
                //UIコントローラーへスコアの加算を要請
                GameObject.Find("UI").GetComponent<UIController>().BonusAddScore();
                Debug.Log("BonusCoinGet");
            }
            else
            {
                //UIコントローラーへスコアの加算を要請
                GameObject.Find("UI").GetComponent<UIController>().AddScore();
            }
            //コイン削除
            Destroy(coll.gameObject);
        }
    }
}