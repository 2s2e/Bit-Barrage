using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletPool : BulletPool
{
    public static EnemyBulletPool EnemyBulletPoolInstance;
    private void Awake()
    {
        EnemyBulletPoolInstance = this;
    }
}
