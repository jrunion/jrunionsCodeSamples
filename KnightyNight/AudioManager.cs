using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour {

    [SerializeField]
    AudioSource SFXPlayer;          //Audio Source That Plays SFX

    [SerializeField]
    AudioSource MusicPlayer;        //Audio Source That Plays Music


    //Serialized Field is used so Level Design can choose what music/ sound FX can be used

    //Original SFX
    [Header("Original SFX")]
    [SerializeField]
    AudioClip SwingClip;
    [SerializeField]
    AudioClip GateOpenClip;
    [SerializeField]
    AudioClip GateCloseClip;
    [SerializeField]
    AudioClip FireClip;

    //Player SFX
    [Header("Player SFX")]
    [SerializeField]
    AudioClip PlayerDamageClip;

    [SerializeField]
    AudioClip PlayerDead;


    //Sewer SFX
    [Header("Sewer SFX")]
    [SerializeField]
    AudioClip BubblesClip;




    //General SFX
    [SerializeField]
    AudioClip RoomCompleteClip;

    [SerializeField]
    AudioClip ButtonPressedClip;

    [SerializeField]
    AudioClip ButtonMovedClip;


    //Ghost SFX
    [Header("Ghost SFX")]

    [SerializeField]
    AudioClip ColorGhostCorrectClip;




    //BackGround Music
    [Header("Music")]
    [SerializeField]
    AudioClip BGMDungeon;
    [SerializeField]
    AudioClip BGMSewer;
    [SerializeField]
    AudioClip BGMGraveyard;
    [SerializeField]
    AudioClip BGMCathedral;
    [SerializeField]
    AudioClip BGMMenu;
    [SerializeField]
    AudioClip BGMBoss;
    [SerializeField]
    AudioClip BGMChase;
    [SerializeField]
    AudioClip BGMSecretBoss;

    //master volume value
    public float volMaster = 10;                //default master volume
    //music volume value
    public float volMusic = 10;                 //default music volume
    //sfx music volume
    public float volSFX = 10;                   //default SFX Volume

    bool boss;                                  // boss bool
    bool chase;                                 //chase bool
    bool secretBoss;                            //secret boss bool

    public static AudioManager instance = null;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }



        MusicPlayer = this.transform.GetChild(0).GetComponent<AudioSource>();       //music player is the child of the parent audio source


        RestartMusic();                             //start the music at start

        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if(volMaster<=volMusic)                     //keeps the music volume equal to the master if master is lower than the music
        {
            volMusic = volMaster;
        }
        if(volMaster<=volSFX)                       //keeps the SFX volume equal to the master if master is lower than the SFX
        {
            volSFX = volMaster;
        }

        ChooseMusic();
    }

    //Volume Control
    public virtual void MasterVolume(float value) //changes master volume
    {
        volMaster = value;
        volMusic = value;
        volSFX = value;
        RestartMusic();
    }

    public virtual void MusicVolume(float value)            //changes just music volume
    {
        volMusic = value;
        RestartMusic();
    }
        
    public virtual void SFXVolume(float value)              //changes SFX Volume
    {
        volSFX = value;
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////

    //Original SFX Functions 
    public virtual void Swing()                                 //plays sword swing
    {
        SFXPlayer.PlayOneShot(SwingClip, volSFX);
    }

    public virtual void GateOpen()                              //plays gate open (I believe this is no longer called)
    {
            SFXPlayer.PlayOneShot(GateOpenClip, volSFX);
    }

    public virtual void GateClose()                              //plays gate close (I believe this is no longer called)
    {
            SFXPlayer.PlayOneShot(GateCloseClip, volSFX);
    }

    public virtual void FireAttack()                            //plays fire attack noise
    {
            SFXPlayer.PlayOneShot(FireClip, volSFX);
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////

    //Player SFX Functions
    public virtual void PlayerDamaged()                         //plays player damage noise
    {
            SFXPlayer.PlayOneShot(PlayerDamageClip, volSFX);
    }

    public virtual void PlayerDied()                            //plays pleyer death
    {
        SFXPlayer.PlayOneShot(PlayerDead, volSFX);
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////


    //Sewer SFX Functions
    public virtual void Bubbling()                              //plays bubbling
    {
            SFXPlayer.PlayOneShot(BubblesClip, volSFX);
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////


    //General SFX


    public virtual void RoomComplete()                          //plays room complete noise
    {
        if (!SFXPlayer.isPlaying)
            SFXPlayer.PlayOneShot(RoomCompleteClip, volSFX);
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////


    //Ghost SFX Functions
    public virtual void GhostColorCorrect()                     //plays noise when ghost hits correct pillar
    {
            SFXPlayer.PlayOneShot(ColorGhostCorrectClip, volSFX);
    }

    public virtual void ButtonPressed()                         //plays noise when button is pressed
    {
        SFXPlayer.PlayOneShot(ButtonPressedClip, volSFX);
    }

    public virtual void ButtonMoving()                          //plays noise when player moves to new button
    {
        SFXPlayer.PlayOneShot(ButtonMovedClip, volSFX);
    }


    /////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////


    public virtual void ChooseMusic()                               //chooses music
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;            //finds current scene

        if (MusicPlayer.enabled)                                    //if theres a music player
        {


            if (!boss && !chase && !secretBoss)                     //if player is not in a boss fight or chase scene
            {

                if (currentScene > 0 && currentScene <= 4)          //world 1 music
                {
                    if (!MusicPlayer.isPlaying)
                        MusicPlayer.PlayOneShot(BGMDungeon, volMusic / 10);
                }

                else if (currentScene > 4 && currentScene <= 7)     //world 2 music
                {
                    if (!MusicPlayer.isPlaying)
                        MusicPlayer.PlayOneShot(BGMSewer, volMusic / 10);
                }

                else if (currentScene > 7 && currentScene <= 10)        //world 3 music
                {
                    if (!MusicPlayer.isPlaying)
                        MusicPlayer.PlayOneShot(BGMGraveyard, volMusic / 10);
                }

                else if (currentScene > 10 && currentScene <= 13)       //world 4 music
                {
                    if (!MusicPlayer.isPlaying)
                        MusicPlayer.PlayOneShot(BGMCathedral, volMusic / 10);
                }

                else if (currentScene == 0)                         //main menu music
                    if (!MusicPlayer.isPlaying)
                        MusicPlayer.PlayOneShot(BGMMenu, volMusic / 10);
            }

            else if (boss && !chase && !secretBoss)             //boss music
            {
                if (!MusicPlayer.isPlaying)
                    MusicPlayer.PlayOneShot(BGMBoss, volMusic / 10);
            }

            else if (!boss && chase && !secretBoss)             //chase music
            {
                if (!MusicPlayer.isPlaying)
                    MusicPlayer.PlayOneShot(BGMChase, volMusic / 10);
            }

            else if (!boss && !chase && secretBoss)             //secret boss music
            {
                if (!MusicPlayer.isPlaying)
                    MusicPlayer.PlayOneShot(BGMSecretBoss, volMusic / 10);
            }


        }


    }

    public virtual void StartMusic()           //start music function (called coroutine)
    {
        StartCoroutine(MusicStart());
    }

    public virtual void RestartMusic()          //restart music
    {
        MusicPlayer.Stop();                     //stop music
        if(volMusic>0)
            ChooseMusic();                      //if there is music volume, choose music
    }



    IEnumerator MusicStart()                        //music start coroutine
    {
        float fadeTime = 0;
        RestartMusic();
        MusicPlayer.volume = 0;
        yield return new WaitForSeconds(1.8f);
        MusicPlayer.volume = volSFX;

    }


    public virtual void ChaseStart() { chase = true; RestartMusic(); }                  //starts chase music
    public virtual void ChaseStop() { chase = false; RestartMusic(); }                  //stops chase music
    public virtual void BossStart() { boss = true; RestartMusic(); }                    //starts boss music
    public virtual void SecretBossStart() { secretBoss = true; RestartMusic(); }        //starts secret boss music
    public virtual void BossStop() { boss = false; secretBoss = false; RestartMusic(); }        //stops all boss music
}
