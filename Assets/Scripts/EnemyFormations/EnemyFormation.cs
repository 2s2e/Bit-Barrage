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
        enemyWidth = col.size.x;
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

    private void Update()
    {
        if(transform.position.x + width/2f > ScreenUtils.ScreenRight || transform.position.x - width / 2f < ScreenUtils.ScreenLeft)
        {
            dir *= -1;
        }
        transform.Translate(Vector3.right * dir * speed * Time.deltaTime);
        if(width != 0 && enemies.Count == 0)
        {
            Destroy(gameObject);
        }
    }

    void Linear()
    {
        if(((float)numEnemies * 2f - 1f) * enemyWidth > screenWidth)
        {
            numEnemies = Mathf.FloorToInt((screenWidth + enemyWidth * 0.5f) / (enemyWidth * 1.5f));
        }
        Debug.Log(enemyWidth);
        Debug.Log(screenWidth);
        width = (float)numEnemies * enemyWidth + ((float)numEnemies - 1) * 0.5f * enemyWidth;
        Debug.Log(width);
        transform.position = new Vector3(0, transform.position.y,0);
        float start = width / 2f + enemyWidth / 2;
        for(int i = 0; i < numEnemies; i++)
        {
            GameObject tempShip = Instantiate(enemy, transform, true);
            tempShip.transform.position = new Vector3(-start + enemyWidth * 1.5f * i, transform.position.y, 0);
            tempShip.GetComponent<SpriteRenderer>().color = enemyColor;
            enemies.Add(tempShip);
        }
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
