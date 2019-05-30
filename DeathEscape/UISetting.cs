public void TogglePauseMenu()
{
    if (UI.gameObject.activeInHierarchy == false)
    {
        UI.gameObject.SetActive(true);
        Time.timeScale = 0f;
        Camera.GetComponent<mouseLook>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    else
    {
        UI.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
        Camera.GetComponent<mouseLook>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}

public void resumeButtom()
{
    if (UI.gameObject.activeInHierarchy == false)
    {
        UI.gameObject.SetActive(true);
        Time.timeScale = 0f;
        Camera.GetComponent<mouseLook>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    else
    {
        UI.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
        Camera.GetComponent<mouseLook>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}