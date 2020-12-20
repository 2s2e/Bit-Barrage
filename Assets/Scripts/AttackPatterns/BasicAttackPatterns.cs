using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttackPatterns : MonoBehaviour
{
    public static BasicAttackPatterns BasicAttackPatternsInstance;
    readonly static BulletPool[] bulletPools;
    public static int bulletTypes = 3;
    private void Awake()
    {
        BasicAttackPatternsInstance = this;
        StopAllCoroutines();
    }
    public static string[] attacks = {"Trident", "Spear", "Circle"};

    public void BasicAttack(int ind, float generalDirection, int numBullets, Color color, int repeat, int spriteNum, GameObject ship)
    {
        if(ind == 0)
        {
            StartCoroutine(Trident(generalDirection, numBullets, color, repeat, spriteNum, ship));
        }
        else if(ind == 1)
        {
            StartCoroutine(Spear(generalDirection, numBullets, color, repeat, spriteNum, ship));
        }
        else if(ind == 2)
        {
            StartCoroutine(Circle(generalDirection, numBullets, color, repeat, spriteNum, ship));
        }
    }
    public IEnumerator Trident(float generalDirection, int numBullets, Color color, int repeat, int spriteNum, GameObject ship)
    {
        float angleInc = 60f / (numBullets - 1);
        float start = generalDirection - 30f;
        GameObject bullet;
        SpriteRenderer sr;
        for (int i = 0; i < repeat; i++)
        {
            for (int j = 0; j < numBullets; j++)
            {
                try
                {
                    if(ship != null)
                    {
                        if (spriteNum == 0)
                        {
                            bullet = EnemyBulletPool.EnemyBulletPoolInstance.GetBullet();
                        }
                        else if (spriteNum == 1)
                        {
                            bullet = EnemyBulletTwoPool.EnemyBulletPoolInstance.GetBullet();
                        }
                        else if (spriteNum == 2)
                        {
                            bullet = EnemyBulletThreePool.EnemyBulletPoolInstance.GetBullet();
                        }
                        else
                        {
                            bullet = EnemyBulletPool.EnemyBulletPoolInstance.GetBullet();
                        }
                        bullet.transform.position = ship.transform.position;
                        bullet.transform.eulerAngles = new Vector3(0, 0, start + angleInc * j);
                        sr = bullet.GetComponent<SpriteRenderer>();
                        sr.color = color;
                        bullet.SetActive(true);
                    }
                    
                }
                finally
                {

                }
            }
            yield return new WaitForSeconds(1);
        }
        GlobalVariables.attackFinished = true;
        StopAllCoroutines();
    }
    public IEnumerator Spear(float generalDirection, int numBullets, Color color, int repeat, int spriteNum, GameObject ship)
    {
        GameObject bullet;
        SpriteRenderer sr;
        for (int i = 0; i < repeat; i++)
        {
            for (int j = 0; j < numBullets; j++)
            {
                try
                {

                    //bullet = bulletPools[spriteNum].GetBullet();
                    if(spriteNum == 0)
                    {
                        bullet = EnemyBulletPool.EnemyBulletPoolInstance.GetBullet();
                    }
                    else if(spriteNum == 1)
                    {
                        bullet = EnemyBulletTwoPool.EnemyBulletPoolInstance.GetBullet();
                    }
                    else if(spriteNum == 2)
                    {
                        bullet = EnemyBulletThreePool.EnemyBulletPoolInstance.GetBullet();
                    }
                    else
                    {
                        bullet = EnemyBulletPool.EnemyBulletPoolInstance.GetBullet();
                    }
                    if (ship != null) {
                        bullet.transform.position = ship.transform.position;
                        Vector3 targetDir = GlobalVariables.player.transform.position - ship.transform.position;
                        float angle = Mathf.Atan(-(GlobalVariables.player.transform.position.x - ship.transform.position.x) / (GlobalVariables.player.transform.position.y - ship.transform.position.y)) * Mathf.Rad2Deg - 180;
                        Debug.Log(angle);
                        bullet.transform.eulerAngles = new Vector3(0, 0, angle);
                        sr = bullet.GetComponent<SpriteRenderer>();
                        sr.color = color;
                        bullet.SetActive(true);
                        yield return new WaitForSeconds(0.2f);
                    }
                    
                }
                finally
                {

                }
            }
            yield return new WaitForSeconds(1);
        }
        GlobalVariables.attackFinished = true;
        StopAllCoroutines();
    }

    public IEnumerator Circle(float generalDirection, int numBullets, Color color, int repeat, int spriteNum, GameObject ship)
    {
        GameObject bullet;
        SpriteRenderer sr;
        numBullets = Mathf.FloorToInt(1.5f * numBullets);
        float inc = 360f / numBullets;
        for (int i = 0; i < repeat; i++)
        {
            for (int j = 0; j < numBullets; j++)
            {
                try
                {

                    //bullet = bulletPools[spriteNum].GetBullet();
                    if (spriteNum == 0)
                    {
                        bullet = EnemyBulletPool.EnemyBulletPoolInstance.GetBullet();
                    }
                    else if (spriteNum == 1)
                    {
                        bullet = EnemyBulletTwoPool.EnemyBulletPoolInstance.GetBullet();
                    }
                    else if (spriteNum == 2)
                    {
                        bullet = EnemyBulletThreePool.EnemyBulletPoolInstance.GetBullet();
                    }
                    else
                    {
                        bullet = EnemyBulletPool.EnemyBulletPoolInstance.GetBullet();
                    }
                    if (ship != null)
                    {
                        bullet.transform.position = ship.transform.position;
                        bullet.transform.eulerAngles = new Vector3(0, 0, generalDirection + inc * j);
                        sr = bullet.GetComponent<SpriteRenderer>();
                        sr.color = color;
                        bullet.SetActive(true);
                        bullet.GetComponent<EnemyBulletController>().speed = (3f + 0.1f * GlobalVariables.level) * 2.2f;

                    }

                }
                finally
                {

                }
            }
            yield return new WaitForSeconds(1);
        }
        GlobalVariables.attackFinished = true;
        StopAllCoroutines();
    }
}
