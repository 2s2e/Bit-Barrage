using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    List<Sprite> enemyBulletSprites;
    [SerializeField]
    List<Sprite> enemySprites;

    [SerializeField]
    public List<List<Sprite>> bossParts;

    bool inGame;

    void Awake()
    { 

        ScreenUtils.Initialize();
        DontDestroyOnLoad(gameObject);
        GlobalVariables.enemyBulletSprites = this.enemyBulletSprites;
        GlobalVariables.enemySprites = this.enemySprites;
        GlobalVariables.bossParts = this.bossParts;
    }

    public void setMouseSensitivity(Slider s)
    {
        GlobalVariables.mouseSensitivity = s.value;
        Debug.Log(s.value);
    }
    public void newWave()
    {

    }
    /* 
     public int numEnemies;
    public int formation;
    public static int numFormations = 3;
    public GameObject enemy;
    public Color enemyColor;
    public float speed = 2f;
     */
    // Update is called once per frame
    void Update()
    {
        
    }
}
