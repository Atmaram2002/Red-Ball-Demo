using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager inst;
    
    [Header("UI Feedback")]
    public Text timeFeedback;
    public Text coinFeedback;

    int coinCounter;
    int totalCoins;
    // Start is called before the first frame update
    void Start()
    {
       if(inst) Debug.LogWarning("There is more than 1 LevelManager in the scene");
       inst = this; 
       StartCoroutine(TimeTick());
       totalCoins = CoinPickup.CountNumberInScene();
       coinFeedback.text = coinCounter + "/" + totalCoins;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateCoinCounter(int value)
    {
        coinCounter += value;
        coinFeedback.text = coinCounter + "/" + totalCoins;
    }

    //Timer
    //Calculates only in-game time

    IEnumerator TimeTick(int sec = 0, int min = 0)
    {
        while(Time.timeScale !=0)
        {
            yield return new WaitForSeconds(1);
            //update seconds and minutes
            if (sec == 59)
            {
                sec=0;
                min++;
            }
            else{
                sec++;
            }

            if(sec < 10)
            {
                timeFeedback.text = min + ":0"+ sec;
            }
            else{
                timeFeedback.text = min + ":"+ sec;
            }
            
        }
        StopCoroutine(TimeTick());
    }
}
