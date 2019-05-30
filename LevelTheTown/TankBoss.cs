using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankBoss : MonoBehaviour {

    public Slider enemyHealthBar;

    public float maxDistance = 4.0f;
    public float speed = 10.0f;
    Transform player;
    Vector2 currentPosition = new Vector2();
    public float enemyMaxHealth;
    float currentHealth;
    public GameObject alien;
    public GameObject enemyLaser1;
    public GameObject enemyLaser2;
    public GameObject enemyLaser3;
    public GameObject frontGun;
    public GameObject backGun;
    public Transform tank1fire;
    public Transform tank2fire;
    public Transform tank3fire;
    public Transform tank4fire;
    float time = 1.25f;

    bool chooseGun1 = true;
    void Start()
    {
        currentHealth = enemyMaxHealth;
        enemyHealthBar.value = CalculatedHealth();


        
    }

    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        currentPosition.x = transform.position.x;
        if (player.position.x <= currentPosition.x + maxDistance && player.position.x >= currentPosition.x - (maxDistance))
        {
            transform.position += transform.right * speed * Time.deltaTime;
            if (time >= 0)
            {
                time -= Time.deltaTime;
                return;
            }
            else
            {
                Instantiate(enemyLaser3, tank4fire.position, tank4fire.rotation);

                time = 0.75f;
            }
        }
        else if (player.position.x >= currentPosition.x + maxDistance)
        {
            Vector2 newScale = transform.localScale;
            newScale.x = -1;
            transform.localScale = newScale;
            transform.position += transform.right * speed * Time.deltaTime;
            if (time >= 0)
            {
                time -= Time.deltaTime;
                return;
            }
            else
            {
                transform.position = transform.position;
                Instantiate(enemyLaser2, tank1fire.position, tank1fire.rotation);
                shootSmallGun();
                time = 0.75f;
            }
        }
        else if (player.position.x <= currentPosition.x - maxDistance)
        {
            Vector2 newScale = transform.localScale;
            newScale.x = 1;
            transform.localScale = newScale;
            transform.position += transform.right * -speed * Time.deltaTime;
            if (time >= 0)
            {
                time -= Time.deltaTime;
                return;
            }
            else
            {
                transform.position = transform.position;
                Instantiate(enemyLaser1, tank1fire.position, tank1fire.rotation);
                shootSmallGun();
                time = 0.75f;
            }
        }


    }

    public void damageEnemy(float damage)
    {
        enemyHealthBar.value = CalculatedHealth();
        currentHealth -= damage;
        if (currentHealth <= 0) killEnemy();
    }

    void killEnemy()
    {
        enemyHealthBar.gameObject.SetActive(false);
        alien.SetActive(true);
        Destroy(gameObject);
    }

    float CalculatedHealth()
    {
        return currentHealth / enemyMaxHealth;
    }

    void shootSmallGun()
    {
        if (time >= 0)
        {
            time -= Time.deltaTime;
            return;
        }
        else
        {
            if (chooseGun1 == true)
            {
                Instantiate(enemyLaser1, tank2fire.position, tank2fire.rotation);
                chooseGun1 = false;
            }
            else if (chooseGun1 == false)
            {
                Instantiate(enemyLaser1, tank3fire.position, tank2fire.rotation);
                chooseGun1 = true;
            }
        }
    }
}
