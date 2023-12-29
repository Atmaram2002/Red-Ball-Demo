using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : Pickup
{
    [Header("Coin Pickup")]
    //coin value
    public int value = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<PlayerMovement>())
        {
            FindObjectOfType<AudioManager>().PlaySound("PickUpCoin");

            //update  counter 
            LevelManager.inst.UpdateCoinCounter(value);

            //Destroy the  coin
            Destroy(gameObject);
        }
    }
    //total no of coin pickups in scene
    public new static int CountNumberInScene()
    {
       int totalCoinValue = 0;
       CoinPickup[] coins = FindObjectsOfType<CoinPickup>();
       //calculate  total amount of coin  value 
       foreach(CoinPickup c in coins)
       {
        totalCoinValue += c.value;
       }
        return totalCoinValue; 
    }

     

}
