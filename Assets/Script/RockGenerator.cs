using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockGenerator : MonoBehaviour {

    public GameObject rockPrefab;
    public GameObject bonusrockPrefab;

	// Use this for initialization
	void Update ()
    {
        if (UIController.FeaverTime != false && UIController.FeaverEnd != true )
        {
            if(IsInvoking("GenRock")==true)
            {
                CancelInvoke("GenRock");
            }

            if (IsInvoking("BonusGenRock") == false)
            {
                InvokeRepeating("BonusGenRock", 0f, 0.1f);
            }
            
        
            
        }
        else
        {
            if(IsInvoking("BonusGenRock")==true)
            {
                CancelInvoke("BonusGenRock");
            }

            if(IsInvoking("GenRock")==false)
            {
                InvokeRepeating("GenRock", 2f, 0.8f);
            }
        }
        
    }
	
    void GenRock()
    {


       if(UIController.GameOverCount!=0)
        {
            Instantiate(rockPrefab, new Vector3(-2.3f + 5 * Random.value, 6, 0), Quaternion.identity);
        }

    }
    void BonusGenRock()
    {
        if (UIController.GameOverCount != 0)
        {
            Instantiate(bonusrockPrefab, new Vector3(-2.3f + 5 * Random.value, 6, 0), Quaternion.identity);
        }

    }
}
