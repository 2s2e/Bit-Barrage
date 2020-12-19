using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletPool : BulletPool
{
    public static PlayerBulletPool PlayerBulletPoolInstance;

    private void Awake()
    {
        PlayerBulletPoolInstance = this;
    }
}
