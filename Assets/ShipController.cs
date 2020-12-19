using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField]
    float health = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
            Destroy(collision.gameObject);
        }
    }

    private void DestroyShip()
    {
        Destroy(this.gameObject);
    }
}
