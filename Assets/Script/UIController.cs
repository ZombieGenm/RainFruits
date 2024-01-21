using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;




    public class UIController : MonoBehaviour
{
    //変数
    public static int GameOverCount = 3;    //ミスカウント変数
    public static bool BackToTitle = false; //タイトルに戻る変数
    static int score = 0;                   //スコア変数
    public static bool FeaverTime = false;  //フィーバータイム変数
    public static bool FeaverEnd = false;
    static float FeaverGauge = 0.0f;        //フィーバーゲージ管理変数

    //ゲームオブジェクト
    GameObject scoreTextA;      //スコアテキスト
    GameObject outText;         //アウトテキスト
    GameObject gameoverText;    //ゲームオーバーテキスト
    GameObject HighScoreText;   //ハイスコアテキスト
    GameObject FeverGaugeText;  //フィーバーゲージテキスト
    public GameObject[] bonusCoin;




    public void GameOver()
    {
        if (FeaverTime == true || GameOverCount == 0) 
        {
            ;//ゲームオーバー or フィーバータイムなので減らさない
        }
        else
        {
            GameOverCount--;//ゲームオーバーカウントを1減らす
        }
    }

    public void AddScore()
    {
        //ゲームオーバーじゃないか確認
       if(GameOverCount!=0)
        {
            //スコア加算
            score += 1;
            Debug.Log("Fluits:" + score);
            if(FeaverTime == false)
            {
               //FeaverGauge += 100.0f;   //デバッグ用
                FeaverGauge += 2.5f;  //本実装用
               //Debug.Log("Fever:" + FeaverGauge);
            }

        }
    }
    public void BonusAddScore()
    {
        score++;
    }

    public static int OutputReturn()
    {
        return GameOverCount;
    }

    void Start()
    {
        //テキストをゲームオブジェクトに紐付け
        this.scoreTextA = GameObject.Find("ScoreA");          //スコアA(緑のとこ）
        this.gameoverText = GameObject.Find("GameOver");    //ゲームオーバー
        this.outText = GameObject.Find("Out");              //アウト回数
        this.HighScoreText = GameObject.Find("highScore");  //ハイスコア
        this.FeverGaugeText = GameObject.Find("Fever");     //フィーバーゲージ
    }

    void FixedUpdate()
    {

        //タイトルから復帰した時にデータをリセットする。
        if(BackToTitle==true)
        {
            GameOverCount = 3;
            score = 0;
            BackToTitle = false;
            FeaverGauge = 0.0f;
        }
        //フィーバーゲージ
        if (FeaverTime == true)
        {
           
            if(FeaverGauge<=0||FeaverEnd==true)
            {
                FeaverEnd = true;
                FeaverGauge = 0.0f;

                int coinCount = GameObject.FindGameObjectsWithTag("BonusCoin").Length;
                // Prefab Cloneが残っているかどうかを判定する
                if (bonusCoin.Length==0)
                {
                    FeaverTime = false;
                    FeaverEnd = false;
                    Debug.Log("Fever End!");// Prefab Cloneは残っていない
                }
                else
                {
                    Debug.Log("BonusCoin:" + coinCount);
                }



            }else{
                FeaverGauge -= 0.2f;
            }

        }
        //フィーバーモード突入確認
        if (FeaverGauge>=100.0f)
        {
            FeaverTime = true;
            Debug.Log("Fever!!");
        }


        //アウトの残り回数表示
        outText.GetComponent<Text>().text = "OUT\n" + GameOverCount.ToString("D1");
        //スコア表示
        scoreTextA.GetComponent<Text>().text = "Fruits\n" + score.ToString("D3");
        FeverGaugeText.GetComponent<Text>().text = "Fever:" + FeaverGauge.ToString("F3");
        //Debug.Log("Fever" + FeaverGauge);

        //ゲームオーバーカウントが０ならゲームオーバーと表示
        if (GameOverCount == 0)
        {
            this.gameoverText.GetComponent<Text>().text = "GameOver\nPushClick\nTitle";
            this.HighScoreText.GetComponent<Text>().text="GetFruits\n"+ score.ToString("D3");
            if(Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("Title");
                BackToTitle = true;
            }
        }
    }
}