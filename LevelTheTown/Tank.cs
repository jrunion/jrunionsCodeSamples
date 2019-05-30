using UnityEngine;

public class Tank : MonoBehaviour {

    public float maxDistance = 4.0f;
   
    public float speed = 10.0f;
    Transform player;
    Vector2 currentPosition = new Vector2();
    public float enemyMaxHealth;
    float currentHealth;
    public GameObject enemyLaser;
    public Transform tank1fire;
    float time = 0.75f;
 
    void Start () {
        currentHealth = enemyMaxHealth;
        
	}
	
	void Update () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        currentPosition.x = transform.position.x;
        if (player.position.x >= currentPosition.x - maxDistance && player.position.x <= currentPosition.x - (maxDistance/2))
        {
            if (time >= 0)
            {
                time -= Time.deltaTime;
                return;
            }
            else
            {
                transform.position = transform.position;
                Instantiate(enemyLaser, tank1fire.position, tank1fire.rotation);
                time = 0.75f;
            }
            
        }
        else if (player.position.x >= currentPosition.x -maxDistance)
        transform.position += transform.right * speed * Time.deltaTime;
        else if (player.position.x <= currentPosition.x - maxDistance)
            transform.position += transform.right * -speed * Time.deltaTime;
    }

    public void damageEnemy(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0) killEnemy();
    }

    void killEnemy()
    {
        Destroy(gameObject);
    }
}
