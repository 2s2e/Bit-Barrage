using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        ScreenUtils.Initialize();
        DontDestroyOnLoad(gameObject);
    }

    public void setMouseSensitivity(Slider s)
    {
        GlobalVariables.mouseSensitivity = s.value;
        Debug.Log(s.value);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
