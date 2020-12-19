using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Canvas mainMenu;
    public Canvas settingsMenu;

    public Texture2D empty;

    public void ChangeToSettings()
    {
        mainMenu.enabled = false;
        settingsMenu.enabled = true;
    }

    public void ChangeToMain()
    {
        mainMenu.enabled = true;
        settingsMenu.enabled = false;
    }

    public void StartGame()
    {
        ChangeToMain();
        Cursor.visible = false;
        SceneManager.LoadScene(sceneName: "Main");
    }
}
