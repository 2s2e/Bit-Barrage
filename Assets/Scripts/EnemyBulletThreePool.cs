using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletThreePool : BulletPool
{
    public static EnemyBulletThreePool EnemyBulletPoolInstance;
    private void Awake()
    {
        EnemyBulletPoolInstance = this;
    }
}
