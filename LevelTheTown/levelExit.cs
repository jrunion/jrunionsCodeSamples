using UnityEngine;

public class levelExit : MonoBehaviour {

    
    bool aliengrabbed;

    public void Start()
    {
        aliengrabbed = false;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && aliengrabbed == true)
        {
            Application.LoadLevel("LevelComplete");

        }

    }


    public void nextLevel()
    {
        aliengrabbed = true;

    }


}
