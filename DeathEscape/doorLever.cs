using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorLever : MonoBehaviour {

    [SerializeField]
    private Transform player;
    [SerializeField]
    private Transform door;
    [SerializeField]
    private Transform doorEnd;
    [SerializeField]
    private Transform lever2;
    [SerializeField]
    private Transform buttonPress;
    public float liftSpeed = 5.0f;
    private bool activate = false;


    private void OnTriggerStay(Collider other)                 //when another object collides
    {
        buttonPress.gameObject.active = true;
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.E))                                              //if the other object has the tag player
        {
            activate = true;
            transform.position = new Vector3(transform.position.x, -100000, transform.position.z);
            lever2.gameObject.active = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        buttonPress.gameObject.active = false;
    }
    private void Update()
    {
        if (activate == true)
        {
            door.transform.Translate(0, Time.deltaTime * liftSpeed, 0);

        }
        if (activate == true && door.position.y >= doorEnd.position.y)
        {
            door.transform.position = doorEnd.transform.position;
        }
    }
}
