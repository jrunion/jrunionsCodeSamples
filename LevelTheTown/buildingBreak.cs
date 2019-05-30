using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildingBreak : MonoBehaviour {
    public GameObject buildingA;
    public GameObject buildingB;
    public GameObject buildingC;
    public GameObject buildingD;
    public float buildingMaxHealth;
    float currentHealth;
    float hits = 0;

	// Use this for initialization
	void Start () {
        buildingA.SetActive(true);
        buildingB.SetActive(false);
        buildingC.SetActive(false);
        buildingD.SetActive(false);



        currentHealth = buildingMaxHealth; currentHealth = buildingMaxHealth;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "playershot")
        {
            hits++;
            Destroy(other.gameObject);
        }
    }

    public void Update()
    {
        if (hits ==2 || hits == 3)
        {
            buildingA.SetActive(false);
            buildingB.SetActive(true);
        }
        if (hits == 4 || hits == 5)
        {
            buildingB.SetActive(false);
            buildingC.SetActive(true);
        }
        if (hits >= 6)
        {
            GetComponent<BoxCollider2D>().enabled = false;
            buildingC.SetActive(false);
            buildingD.SetActive(true);
        }
    }

    public void damagebuilding(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0) destroyBuilding();
    }

    void destroyBuilding()
    {
        Destroy(gameObject);
    }
}
