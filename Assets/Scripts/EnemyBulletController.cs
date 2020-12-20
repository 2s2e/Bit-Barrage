using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    public float speed = 3f + 0.1f * GlobalVariables.level;
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
        float speed = 3f + 0.1f * GlobalVariables.level;
}

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
        float speed = 3f + 0.1f * GlobalVariables.level;
    }

}
