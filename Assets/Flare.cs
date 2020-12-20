using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flare : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < ScreenUtils.ScreenBottom)
        {
            Destroy(gameObject);
        }
    }
}
