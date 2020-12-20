using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Camera cam;
    Animator animator;
    PolygonCollider2D graze;
    float halfWidth;
    float halfHeight;
    Timer fireTimer;

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


    float scaledSpeed;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        graze = GetComponent<PolygonCollider2D>();

        halfWidth = dimensions.size.x / 2;
        halfHeight = dimensions.size.y / 2;
        scaledSpeed = speed * (0.5f + GlobalVariables.mouseSensitivity);
        fireTimer = gameObject.AddComponent<Timer>();
        fireTimer.Duration = 0.2f;
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

        if(Input.GetMouseButton(0))
        {
            if(!fireTimer.Running)
            {
                Fire();
            }
        }

        
    }

    void Fire()
    {
        Debug.Log("fired");
        GameObject bullet = PlayerBulletPool.PlayerBulletPoolInstance.GetBullet();
        bullet.transform.position = transform.position;
        bullet.transform.rotation = Quaternion.identity;
        bullet.SetActive(true);
        fireTimer.Run();
    }
}
