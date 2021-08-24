using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinPicker : MonoBehaviour
{
    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // Update is called once per frame
    // void Update()
    // {
        
    // }

    private float coin = 1;
    // public AudoClip coinPickupSound;

    public TextMeshProUGUI textCoins;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.tag == "Coin") {
            textCoins.text = coin.ToString();
            coin++;
            // AudioSource.PlayClipAtPoint(coinPickupSound, transform.position);

            FindObjectOfType<AudioManager>().Play("CoinPicker");

            Destroy(other.gameObject);
            Debug.Log("Collider with " + other.name);
           
        }
    }   

}
