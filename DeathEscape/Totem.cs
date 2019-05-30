using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Totem : MonoBehaviour {

    public Transform ButtonHUD;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)                 //when another object collides
    {
        ButtonHUD.gameObject.active = true;
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.E))                                              //if the other object has the tag player
        {
            GameObject Health = GameObject.Find("FallTrigger Death Trigger");
            Respawn addHealth= (Respawn)Health.GetComponent(typeof(Respawn));
            addHealth.AddHealth();
            ButtonHUD.gameObject.active = false;
            Destroy(transform.parent.gameObject);

        }


    }

    private void OnTriggerExit(Collider other)
    {
        ButtonHUD.gameObject.active = false;
    }

}
