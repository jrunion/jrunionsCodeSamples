using UnityEngine;

public class TrapTile : MonoBehaviour
{
    public Rigidbody rb;                    //rigid body becomes variable
    public Collider coll;                   //collider becomes variable

    void Start()    
    {
        rb = GetComponent<Rigidbody>();     //gets rigid body component
        coll = GetComponent<Collider>();    //gets collider component
        coll.isTrigger = true;              //collider is a trigger
        
    }

    void OnTriggerEnter(Collider other)     //when an object collides
    {
        if (other.attachedRigidbody)        //if the other object has a rigidbody
        rb.useGravity = true;               //turn on gravity for this object
    }
}