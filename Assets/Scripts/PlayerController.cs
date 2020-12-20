using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Camera cam;
    Animator animator;
    PolygonCollider2D graze;
    float halfWidth;
    float halfHeight;
    Timer fireTimer;
    SpriteRenderer spriteRenderer;

    [SerializeField]
    float speed = 20;

    [SerializeField]
    float health = 10;

    [SerializeField]
    BoxCollider2D dimensions;

    [SerializeField]
    BoxCollider2D core;

    [SerializeField]
    GameObject bullet;

    [SerializeField]
    float fireDuration = 0.2f;

    [SerializeField]
    Text healthText;

    [SerializeField]
    Text grazeText;

    [SerializeField]
    Text levelText;

    [SerializeField]
    Text scoreText;

    float scaledSpeed;

    Timer cooldownTimer;

    
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        graze = GetComponent<PolygonCollider2D>();
        cooldownTimer = gameObject.AddComponent<Timer>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        halfWidth = dimensions.size.x / 2;
        halfHeight = dimensions.size.y / 2;
        scaledSpeed = speed * (0.5f + GlobalVariables.mouseSensitivity * 2);
        fireTimer = gameObject.AddComponent<Timer>();
        fireTimer.Duration = 0.1f;

        healthText.text = "HP: " + health;
        grazeText.text = "Graze: " + GlobalVariables.graze.ToString();
        levelText.text = "Level: " + GlobalVariables.level.ToString();
        scoreText.text = "Score: " + GlobalVariables.score.ToString();
        cooldownTimer.Duration = 1f;
        spriteRenderer.color = Color.white;
    }

    private void Awake()
    {
        GlobalVariables.player = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //movement
        float h = scaledSpeed * Input.GetAxis("Mouse X") * Time.deltaTime;
        float v = scaledSpeed * Input.GetAxis("Mouse Y") * Time.deltaTime;
        Vector3 cameraPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x + h, ScreenUtils.ScreenLeft + halfWidth, ScreenUtils.ScreenRight - halfWidth),
            Mathf.Clamp(transform.position.y + v, ScreenUtils.ScreenBottom + halfHeight, ScreenUtils.ScreenTop - halfHeight), 0);
        Debug.Log(GlobalVariables.mouseSensitivity);

        if (Input.GetMouseButton(0))
        {
            if(!fireTimer.Running)
            {
                Fire();
            }
        }

        if(Input.GetKey(KeyCode.Escape)) {
            GameObject[] formations = GameObject.FindGameObjectsWithTag("EnemyFormation");
            foreach(GameObject i in formations)
            {
                Destroy(i);
            }
            StopAllCoroutines();
            SceneManager.LoadScene("Menu");
        }

        levelText.text = "Level: " + GlobalVariables.level.ToString();
        scoreText.text = "Score: " + GlobalVariables.score.ToString();
        if(cooldownTimer.Finished)
        {
            spriteRenderer.color = Color.white;
        }
    }

    void Fire()
    {
        Debug.Log("fired");

        FindObjectOfType<AudioManager>().Play("Shoot");

        GameObject bullet = PlayerBulletPool.PlayerBulletPoolInstance.GetBullet();
        bullet.transform.position = transform.position + Vector3.left * 0.1f;
        bullet.transform.rotation = Quaternion.identity;
        bullet.SetActive(true);
        bullet = PlayerBulletPool.PlayerBulletPoolInstance.GetBullet();
        bullet.transform.position = transform.position + Vector3.right * 0.1f;
        bullet.transform.rotation = Quaternion.identity;
        bullet.SetActive(true);

        fireTimer.Run();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log("hit");
        if (!cooldownTimer.Running)
        {
            FindObjectOfType<AudioManager>().Play("PlayerHit");
            health--;
            if (health <= 0)
            {
                Debug.Log("oof");
                GameOver();
            }
            healthText.text = "HP: " + health;
            cooldownTimer.Run();
            spriteRenderer.color = new Color(1, 1, 1, 0.5f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        GlobalVariables.graze += 1;
        GlobalVariables.score += 1;
        Debug.Log(GlobalVariables.graze);
        grazeText.text = "Graze: " + GlobalVariables.graze.ToString();
        scoreText.text = "Score: " + GlobalVariables.score.ToString();
    }

    private void GameOver()
    {
        StopAllCoroutines();
        SceneManager.LoadScene("Menu");
        GlobalVariables.wave = 0;
        GlobalVariables.level = 1;
        GlobalVariables.graze = 0;
    }

}
