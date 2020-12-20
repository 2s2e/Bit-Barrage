using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    List<GameObject> enemyBullets;
    [SerializeField]
    List<GameObject> enemies;

    [SerializeField]
    public List<List<Sprite>> bossParts;

    [SerializeField]
    Text highScore;

    bool inGame;

    public GameObject wave;

    GameObject waveInstance;
    private static Camera _instance;
    public static Camera Instance { get { return _instance; } }

    void Awake()
    {
        Screen.SetResolution(600, 800, true);
        //Singleton
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = gameObject.GetComponent<Camera>();
        }
        ScreenUtils.Initialize();
        DontDestroyOnLoad(gameObject);
        GlobalVariables.enemyBullets = this.enemyBullets;
        GlobalVariables.enemies = this.enemies;
        GlobalVariables.bossParts = this.bossParts;
        highScore.text = "High Score: " + PlayerPrefs.GetInt("HS", 0);
    }


    

    private void OnLevelWasLoaded(int level)
    {
        ScreenUtils.Initialize();
        if(SceneManager.GetActiveScene().name.Equals("Main"))
        {
            newWave(0);
            StartCoroutine("level");
            GlobalVariables.score = 0;
        }
        else
        {
            Cursor.visible = true;
            Destroy(waveInstance);
            StopCoroutine("level");
            PlayerPrefs.SetInt("HS", Mathf.Max(PlayerPrefs.GetInt("HS", 0), GlobalVariables.score));
            highScore = GameObject.FindGameObjectWithTag("HighScore").GetComponent<Text>();
            highScore.text = "High Score: " + PlayerPrefs.GetInt("HS", 0);
        }
    }

    IEnumerator level()
    {
        while(true) {
            while (waveInstance != null)
            {
                yield return new WaitForSeconds(1);
            }
            yield return new WaitForSeconds(1);
            GlobalVariables.attackFinished = true;
            newWave(0);
        }
        
    }

    public void setMouseSensitivity(Slider s)
    {
        GlobalVariables.mouseSensitivity = s.value;
        Debug.Log(s.value);
    }
    public void newWave(int formation)
    {
        if(GameObject.FindGameObjectsWithTag("EnemyFormation").Length == 0)
        {
            if(GlobalVariables.wave > 2)
            {
                GlobalVariables.wave = 0;
                GlobalVariables.level++;
            }
            else
            {
                GlobalVariables.wave++;
            }
            waveInstance = Instantiate(wave, new Vector3(0, 4, 0), Quaternion.identity);
            EnemyFormation formationScript = waveInstance.GetComponent<EnemyFormation>();
            formationScript.numEnemies = 3 + Mathf.FloorToInt(GlobalVariables.level * 0.25f);
            formationScript.formation = formation;
            formationScript.enemy = enemies[Random.Range(0,enemies.Count)];
            formationScript.enemyColor = generateColor();
            formationScript.speed = 3f + GlobalVariables.level * 0.3f;
        }
        
    }

    public Color generateColor()
    {
        int[] arr = { 0, 0, 0 };
        arr[Random.Range(0, 3)] = 50;
        float red = Random.Range(240 - GlobalVariables.level * 10, 255 - GlobalVariables.level * 5);
        float blue = Random.Range(240 - GlobalVariables.level * 10, 255 - GlobalVariables.level * 5);
        float green = Random.Range(240 - GlobalVariables.level * 10, 255 - GlobalVariables.level * 5);
        return new Color((red - arr[0]) / 255f,(blue - arr[1])/255f,(green - arr[2])/255f);
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
