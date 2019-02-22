using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {
    public GameObject coinPoofPrefab;
    
    public void OnCoinClicked()
    {
       
        Debug.Log("'Coin.OnCoinClicked()' was called");

       
        Instantiate(coinPoofPrefab, transform.position ,Quaternion.identity);
        Destroy(gameObject, 0.5f);
    }
    


    void Update () {
        transform.Rotate(0, 10, 0);
	}


	
}
