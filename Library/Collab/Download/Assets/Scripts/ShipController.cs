using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float health = 3;
    public Color color;
    // Start is called before the first frame update
    void Start()
    {
        BasicAttackPatterns.BasicAttackPatternsInstance.BasicAttack(1, transform.rotation.z - 180,
            5, Color.red, 3, 2, gameObject);

        Debug.Log(Mathf.Atan((GlobalVariables.player.transform.position.x - transform.position.x) / (GlobalVariables.player.transform.position.y - transform.position.y)) * Mathf.Rad2Deg);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnBecameVisible()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("playerBullet"))
        {
            health -= GlobalVariables.playerDamage;
            if (health <= 0f)
            {
                DestroyShip();
            }
            collision.gameObject.SetActive(false);
        }
    }

    private void DestroyShip()
    {
        Destroy(this.gameObject);
    }
}
