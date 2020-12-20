using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalVariables
{
    public static float mouseSensitivity = 0.5f;
    public static float volume = 0.5f;
    public static float playerDamage = 1f;
    public static List<GameObject> enemyBullets;
    public static List<GameObject> enemies;
    public static List<List<Sprite>> bossParts;
    public static GameObject player;
    public static int level = 1;
    public static int graze = 0;
    public static int wave = 0;
    public static bool attackFinished = false;
    public static int score = 0;
}
