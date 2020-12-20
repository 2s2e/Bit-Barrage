using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Canvas mainMenu;
    public Canvas settingsMenu;
    public Canvas helpMenu;
    public Texture2D empty;

    public Text highScore;

    public void ChangeToSettings()
    {
        mainMenu.enabled = false;
        settingsMenu.enabled = true;
        helpMenu.enabled = false;
    }

    public void ChangeToMain()
    {
        mainMenu.enabled = true;
        settingsMenu.enabled = false;
        helpMenu.enabled = false;
    }
    public void ChangeToHelp() {
        mainMenu.enabled = false;
        settingsMenu.enabled = false;
        helpMenu.enabled = true;
    }
    public void StartGame()
    {
        ChangeToMain();
        Cursor.visible = false;
        SceneManager.LoadScene(sceneName: "Main");
    }

    public void ResetHighScore()
    {
        PlayerPrefs.SetInt("HS", 0);
        //highScore = GameObject.FindGameObjectWithTag("HighScore").GetComponent<Text>();
        highScore.text = "High Score: " + PlayerPrefs.GetInt("HS", 0);
    }
   
    
    public void SetVolume(Slider s)
    {
        AudioListener.volume = s.value;
    }
}
