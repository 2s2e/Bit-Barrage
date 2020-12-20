using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    public float speed = 5f;
    Vector3 movement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector3(Mathf.Cos((transform.rotation.z + 90) * Mathf.Deg2Rad), Mathf.Sin((transform.rotation.z + 90) * Mathf.Deg2Rad), 0);
        transform.Translate(movement * Time.deltaTime * speed);
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
