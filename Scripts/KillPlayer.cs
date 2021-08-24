using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KillPlayer : MonoBehaviour
{

    public GameObject coinsPrefab;

    void Awake()
        {
            if (coinsPrefab == null) {
                coinsPrefab = new GameObject();
            } 
            
        }

    public void KillPlayerPlz() {

        GameObject player;
        player = GameObject.Find("PLAYER");

        GameObject playerPrefab;
        playerPrefab = this.gameObject;

        if (player) {
            Destroy(player);
            Instantiate(playerPrefab);
        }
    }

    

    public void KillCoinsPlz() {

        GameObject coinsObj = new GameObject();
        GameObject coins;

        coins = GameObject.Find("COINS");

        if(coins == null) {
            coins = GameObject.Find("COINS(Clone)");
        }

        coinsObj = coinsPrefab.gameObject;
        

        // GameObject coinsPrefab;
        // coinsPrefab = coins.gameObject;

        if (coins && coinsObj) {
            Destroy(coins);
            Instantiate(coinsObj);
        }
    }
}
