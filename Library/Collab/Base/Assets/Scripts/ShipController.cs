using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float health = 3 + GlobalVariables.level * 0.4f;
    public Color color;

    [SerializeField]
    Sprite appearance;
    [SerializeField]
    Sprite ship;

    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        //BasicAttackPatterns.BasicAttackPatternsInstance.BasicAttack(0, transform.rotation.z - 180,
        //5, Color.red, 3, 1, gameObject);
        spriteRenderer = GetComponent<SpriteRenderer>();
        GetComponent<Light>().color = color;
        spriteRenderer.color = color;
        spriteRenderer.sprite = appearance;
        StartCoroutine("ChangeSprite");
        //Debug.Log(Mathf.Atan((GlobalVariables.player.transform.position.x - transform.position.x) / (GlobalVariables.player.transform.position.y - transform.position.y)) * Mathf.Rad2Deg);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator ChangeSprite()
    {
        yield return new WaitForSeconds(0.08f);
        spriteRenderer.sprite = ship;

    }
    public void Attack(int ind, int numBullets, Color color, int repeat, int spriteNum)
    {
        BasicAttackPatterns.BasicAttackPatternsInstance.BasicAttack(ind, transform.rotation.z - 180, numBullets, color,
            repeat, spriteNum, gameObject);
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
