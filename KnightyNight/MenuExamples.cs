//video Settings
private void ChangeResolution(int width, int height, bool fullscreen)
{
    AudioManager.instance.ButtonPressed();
    Screen.SetResolution(width, height, fullscreen);

}


public void ChangeWindow()
{
    AudioManager.instance.ButtonPressed();
    if (Screen.fullScreen == true)
    {
        Screen.fullScreen = false;
        isFullscreen = false;
        currentWindow.text = "Windowed";
    }
    else
    {
        Screen.fullScreen = true;
        isFullscreen = true;
        currentWindow.text = "FullScreen";

    }
}


//audio Settings
public void MuteAll()
{
    AudioManager.instance.ButtonPressed();
    _audioManager.MasterVolume(0);
}

private void ChangeMasterVolume(float vol)
{
    AudioManager.instance.ButtonPressed();
    _audioManager.MasterVolume(vol);
}
public void MasterUp()
{
    AudioManager.instance.ButtonPressed();
    float currentVol = _audioManager.volMaster;
    if (currentVol < 10)
        ChangeMasterVolume(currentVol + 1);
    changedMaster.text = _audioManager.volMaster.ToString();
}

public void MasterDown()
{
    AudioManager.instance.ButtonPressed();
    float currentVol = _audioManager.volMaster;
    if (currentVol > 0)
        ChangeMasterVolume(currentVol - 1);
    changedMaster.text = _audioManager.volMaster.ToString();
}

private void CheckBack()                //B button settings
{

    Scene m_Scene;

    m_Scene = SceneManager.GetActiveScene();


    if (Input.GetKeyDown("joystick button 1"))
    {
        switch (whichUI)
        {
            case WhichUIMenu.AUDIO:
                ToOptions();
                break;
            case WhichUIMenu.VIDEO:
                ToOptions();
                break;
            case WhichUIMenu.OPTIONS:
                if (m_Scene.buildIndex == 0)
                    MenuBack();
                else
                    SetMenu(WhichUIMenu.PAUSE);
                break;
            case WhichUIMenu.PAUSE:
                Pause();
                break;
            case WhichUIMenu.RESOLUTION:
                ToVideo();
                break;
            case WhichUIMenu.MASTER:
                ToMusic();
                break;
            case WhichUIMenu.MUSIC:
                ToMusic();
                break;
            case WhichUIMenu.SFX:
                ToMusic();
                break;
            case WhichUIMenu.LEVELSELECT:
                MenuBack();
                break;
            case WhichUIMenu.AREYOUSURE:
                ToPause();
                break;

        }
    }

}


public void SetStart()                              //Changes start button sprite to say continue if the player has started the game
{
    Button startButton = _menus[0].transform.GetChild(1).GetComponent<Button>();
    Image startImage = _menus[0].transform.GetChild(1).GetComponent<Image>();

    SpriteState ss = new SpriteState();

    if (GameManager._lastLevelIndex > 0)
    {
        startImage.sprite = continueNH;
        ss.highlightedSprite = continueHL;
        ss.pressedSprite = continueHL;
    }
    else
    {
        startImage.sprite = startNH;
        ss.highlightedSprite = startHL;
        ss.pressedSprite = startHL;
    }
    startButton.spriteState = ss;

}
