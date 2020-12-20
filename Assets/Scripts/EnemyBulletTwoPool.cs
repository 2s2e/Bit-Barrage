using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletTwoPool : BulletPool
{
    public static EnemyBulletTwoPool EnemyBulletPoolInstance;
    private void Awake()
    {
        EnemyBulletPoolInstance = this;
    }
}
