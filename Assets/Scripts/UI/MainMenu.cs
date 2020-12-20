using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject settingsMenu;
    public GameObject helpMenu;
    public Texture2D empty;

    public Text highScore;

    public void ChangeToSettings()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
        helpMenu.SetActive(false);
        FindObjectOfType<AudioManager>().Play("MenuClick");
    }

    public void ChangeToMain()
    {
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
        helpMenu.SetActive(false);
        FindObjectOfType<AudioManager>().Play("MenuClick");
    }
    public void ChangeToHelp() {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(false);
        helpMenu.SetActive(true);
        FindObjectOfType<AudioManager>().Play("MenuClick");
    }
    public void StartGame()
    {
        ChangeToMain();
        Cursor.visible = false;
        SceneManager.LoadScene(sceneName: "Main");
        FindObjectOfType<AudioManager>().Play("MenuClick");
    }

    public void ResetHighScore()
    {
        PlayerPrefs.SetInt("HS", 0);
        //highScore = GameObject.FindGameObjectWithTag("HighScore").GetComponent<Text>();
        highScore.text = "High Score: " + PlayerPrefs.GetInt("HS", 0);
    }
    
    public void Quit()
    {
        Application.Quit();
    }

    public void SetVolume(Slider s)
    {
        AudioListener.volume = s.value;
    }
}
