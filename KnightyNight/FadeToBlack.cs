IEnumerator FadeIn()                                        //fades from black to clear
{
    AudioManager.instance.StartMusic();                     //start music
    float time;
    if (!_paused)
        time = 0;
    else
        time = fadeTime;
    Color wantedColor = _fadeScreen.color;



    while (time < fadeTime)
    {
        yield return new WaitForSeconds(fadeUpdateTime);

        wantedColor = Color.Lerp(blackColor, transparentColor, time);
        _fadeScreen.color = wantedColor;
        time += fadeUpdateTime;

        if (isLoading)
        {
            _fadeScreen.color = transparentColor;
            time = fadeTime + 1;
        }
    }


}

IEnumerator FadeOut()                                       //fades to black
{
    float time;
    if (!_paused)
        time = 0;
    else
        time = fadeTime;
    _fadeScreen.color = transparentColor;

    Color wantedColor = transparentColor;

    while (time < fadeTime)
    {
        yield return new WaitForSeconds(fadeUpdateTime);

        wantedColor = Color.Lerp(transparentColor, blackColor, time);
        _fadeScreen.color = wantedColor;
        time += fadeUpdateTime;
    }
}