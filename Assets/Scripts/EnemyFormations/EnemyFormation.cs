using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFormation : MonoBehaviour
{
    List<GameObject> enemies;
    public int numEnemies;
    public int formation;
    public static int numFormations = 3;
    public GameObject enemy;
    public Color enemyColor;
    public float speed = 2f;

    float enemyHeight;
    float enemyWidth;
    
    float width = 0;
    float height = 0;
    float screenWidth = Mathf.Abs(ScreenUtils.ScreenRight - ScreenUtils.ScreenLeft);

    float dir = 1;
    private void Start()
    {
        enemies = new List<GameObject>();
        BoxCollider2D col = enemy.GetComponent<BoxCollider2D>();
        enemyHeight = col.size.y;
        enemyWidth = col.size.x / 2;
        if(formation == 0)
        {
            Linear();
        }
        else if(formation == 1)
        {
            ZigZag();
        }
        else if(formation == 2)
        {
            Sphere();
        }
    }

    IEnumerator attackCycle()
    {
        
        while(true)
        {
            GlobalVariables.attackFinished = false;
            int ind = Random.Range(0, BasicAttackPatterns.attacks.Length);
            int numBullets = 5 + Mathf.FloorToInt(GlobalVariables.level * 0.8f) + Random.Range(-2,3);
            //enemy color
            int repeat = Random.Range(3, 10);
            int spriteNum = Random.Range(0, BasicAttackPatterns.bulletTypes);
            for(int i = 0; i < transform.childCount; i++)
            {
                GameObject cur = transform.GetChild(i).gameObject;
                cur.GetComponent<ShipController>().Attack(ind, numBullets, enemyColor, repeat, spriteNum);
                Debug.Log("Attacked");
            }
            while(!GlobalVariables.attackFinished)
            {
                yield return new WaitForSeconds(1);
            }
            yield return new WaitUntil(checkWait);
            yield return new WaitForSeconds(0.5f);
            //yield return new WaitForSeconds(1);
        }
        
    }

    bool checkWait()
    {
        return GlobalVariables.attackFinished;
    }

    private void Update()
    {
        if(transform.position.x + width/2f > ScreenUtils.ScreenRight || transform.position.x - width / 2f < ScreenUtils.ScreenLeft)
        {
            dir *= -1;
        }
        transform.Translate(Vector3.right * dir * speed * Time.deltaTime);
        Debug.Log(width);
        Debug.Log(enemies.Count);
        if(width != 0 && transform.childCount == 0)
        {
            GlobalVariables.attackFinished = false;
            StopCoroutine("attackCycle");
            Destroy(gameObject);
        }
    }
    /*
     BasicAttackPatterns.BasicAttackPatternsInstance.BasicAttack(0, transform.rotation.z - 180,
            5, Color.red, 3, 1, gameObject);
     */
    void Linear()
    {
        Debug.Log(enemyColor);
        screenWidth = Mathf.Abs(ScreenUtils.ScreenRight - ScreenUtils.ScreenLeft);
        if (((float)numEnemies * enemyWidth + ((float)numEnemies - 1) * (enemyWidth / 2) > screenWidth))
        {
            numEnemies = Mathf.FloorToInt((screenWidth + enemyWidth * 0.5f) / (enemyWidth * 1.5f));
        }
        Debug.Log(enemyWidth);
        Debug.Log(screenWidth);
        width = (float)numEnemies * enemyWidth + ((float)numEnemies - 1) * 0.5f * enemyWidth;
        Debug.Log(width);
        transform.position = new Vector3(0, transform.position.y,0);
        float start = width / 2f - enemyWidth / 2;
        for(int i = 0; i < numEnemies; i++)
        {
            GameObject tempShip = Instantiate(enemy, transform, true);
            tempShip.transform.position = new Vector3(-start + enemyWidth * 1.5f * i, transform.position.y, 0);
            tempShip.GetComponent<SpriteRenderer>().color = enemyColor;
            tempShip.GetComponent<ShipController>().color = enemyColor;
            enemies.Add(tempShip);
        }
        StartCoroutine("attackCycle");
    }
    
    void ZigZag()
    {

    }

    void Sphere()
    {

    }
    
    void Boss()
    {

    }
    

}
