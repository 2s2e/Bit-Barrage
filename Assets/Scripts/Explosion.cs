using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject t;
    public Color color;
    void Start()
    {
        for(int i = 0; i < 8; i++)
        {
            color.a = 0.5f;
            GameObject toInst = Instantiate(t, transform.position, Quaternion.identity);
            toInst.GetComponent<SpriteRenderer>().color = color;
            toInst.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-40, 40), Random.Range(40, 60)));
        }
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
