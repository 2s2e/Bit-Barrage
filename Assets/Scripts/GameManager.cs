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

    bool inGame;

    public GameObject wave;

    GameObject waveInstance;
    void Awake()
    { 

        ScreenUtils.Initialize();
        DontDestroyOnLoad(gameObject);
        GlobalVariables.enemyBullets = this.enemyBullets;
        GlobalVariables.enemies = this.enemies;
        GlobalVariables.bossParts = this.bossParts;
    }

    private void OnLevelWasLoaded(int level)
    {
        ScreenUtils.Initialize();
        if(SceneManager.GetActiveScene().name.Equals("Main"))
        {
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
        waveInstance = Instantiate(wave, new Vector3(0,4,0), Quaternion.identity);
        EnemyFormation formationScript = waveInstance.GetComponent<EnemyFormation>();
        formationScript.numEnemies = 4;
        formationScript.formation = formation;
        formationScript.enemy = enemies[0];
        formationScript.enemyColor = generateColor();
        formationScript.speed = 2f;
    }

    public Color generateColor()
    {
        float red = Random.Range(240 - GlobalVariables.level * 10, 255 - GlobalVariables.level * 5);
        float blue = Random.Range(240 - GlobalVariables.level * 10, 255 - GlobalVariables.level * 5);
        float green = Random.Range(240 - GlobalVariables.level * 10, 255 - GlobalVariables.level * 5);
        return new Color(red,blue,green);
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
