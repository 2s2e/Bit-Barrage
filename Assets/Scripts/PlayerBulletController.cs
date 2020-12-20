using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletController : MonoBehaviour
{
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.SetActive(false);
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
