using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    [SerializeField]
    public Transform player;
    [SerializeField]
    private Transform arrow;
    [SerializeField]
    private Transform arrowEnd;
    public float speed = 1.5f;
    private bool activate = false;
    private bool end = false;

    private void Update()
    {
        if (activate == true && end == true)
            arrow.transform.position = arrowEnd.transform.position;

        if (activate == true && end == false)
            arrow.transform.position = Vector3.MoveTowards(arrow.transform.position, arrowEnd.transform.position, speed);

        if (activate == true && arrow.transform.position == arrowEnd.transform.position)
            end = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
        if (activate == false)
            activate = true;
    }
}