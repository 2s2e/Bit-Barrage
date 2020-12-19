using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Camera cam;
    Animator animator;
    BoxCollider2D graze;
    float halfWidth;
    float halfHeight;

    [SerializeField]
    float speed = 20;

    float scaledSpeed;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        graze = GetComponent<BoxCollider2D>();
        halfWidth = graze.size.x / 2;
        halfHeight = graze.size.y / 2;
        scaledSpeed = speed * (0.5f + GlobalVariables.mouseSensitivity);
    }

    // Update is called once per frame
    void Update()
    {
        float h = scaledSpeed * Input.GetAxis("Mouse X") * Time.deltaTime;
        float v = scaledSpeed * Input.GetAxis("Mouse Y") * Time.deltaTime;
        Vector3 cameraPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x + h, ScreenUtils.ScreenLeft + halfWidth, ScreenUtils.ScreenRight - halfWidth),
            Mathf.Clamp(transform.position.y + v, ScreenUtils.ScreenBottom + halfHeight, ScreenUtils.ScreenTop - halfHeight), 0);
    }
}
