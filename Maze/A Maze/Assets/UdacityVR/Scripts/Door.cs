using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Door : MonoBehaviour {
    public GameObject leftDoor;
    public GameObject rightDoor;
    public AudioSource audioSource;
    public AudioClip locksound;
        
    bool locked = true;
    bool opened = false;

    Quaternion leftDoorStartRotation;
    Quaternion leftDoorEndRotation;
    Quaternion rightDoorStartRotation;
    Quaternion rightDoorEndRotation;

    
    float timer = 0f;
    float rotationTime = 10f;
    

    void Start () {
        
        audioSource = GetComponent<AudioSource>();
        
        leftDoorStartRotation = Quaternion.Euler(-90f,0f,90f);
        leftDoorEndRotation = leftDoorStartRotation * Quaternion.Euler(0f, 0f, -90f);
        rightDoorStartRotation = Quaternion.Euler(-90f,0f,-90f);
        rightDoorEndRotation = rightDoorStartRotation * Quaternion.Euler(0f, 0f, 90f);
       
    }


    void Update()
    {
        if (opened)
        {
            leftDoor.transform.rotation = Quaternion.Slerp(leftDoorStartRotation, leftDoorEndRotation, timer / rotationTime);
            rightDoor.transform.rotation = Quaternion.Slerp(rightDoorStartRotation, rightDoorEndRotation, timer / rotationTime);
            timer += Time.deltaTime;
        }

    }

	public void OnDoorClicked () {
		
		Debug.Log ("'Door.OnDoorClicked()' was called");


        if (!locked)
        {
            opened = true;
            audioSource.Play();
            Destroy(GetComponent<EventTrigger>());
        }

        else if (locked)
        {
            AudioSource.PlayClipAtPoint(locksound,new Vector3(0,0,0));
        }

		
	}


	public void Unlock () {
		
		Debug.Log ("'Door.Unlock()' was called");
        locked = false;
		
	}
}

