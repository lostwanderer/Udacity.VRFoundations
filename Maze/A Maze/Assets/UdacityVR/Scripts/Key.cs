using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {
    public GameObject keyPoofPrefab;
    public Door door;
    

    void Update () {
        transform.Rotate(0, 0, 10);
	}


	public void OnKeyClicked () {
		
		Debug.Log ("'Key.OnKeyClicked()' was called");

       
        door.Unlock();
        Instantiate(keyPoofPrefab, transform.position , Quaternion.identity);
      
        Destroy(gameObject, 0.5f);
        
    }
}
