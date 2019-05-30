using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingCeiling : MonoBehaviour {

    [SerializeField]
    private Transform player;
    [SerializeField]
    private Transform ceiling;
    [SerializeField]
    private Transform floor;
    [SerializeField]
    private Transform ceilingStart;

    public float fallSpeed = 1.5f;
    private bool activate = false;
    private bool end = false;

    private void Update()
    {
        if (activate == true && end == true)
            ceiling.transform.Translate(0, Time.deltaTime * fallSpeed, 0);

        if (activate == true && end == false)
            ceiling.transform.Translate(0, -Time.deltaTime * fallSpeed, 0);

        if (activate == true && ceiling.position.y <= floor.position.y)
            end = true;

        if (activate == true && end == true && ceiling.position.y >= ceilingStart.position.y)
            ceiling.transform.position = ceilingStart.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
        if (activate == false)
        {
            activate = true;
        }
    }
}
