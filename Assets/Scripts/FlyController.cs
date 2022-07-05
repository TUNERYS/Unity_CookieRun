using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyController : MonoBehaviour
{
    GameObject cookie;
    float p1, p2;

    // Start is called before the first frame update
    void Start()
    {
        cookie = GameObject.Find("CookieD");

    }

    // Update is called once per frame
    void Update()
    {
        p1 = transform.position.x;
        p2 = cookie.transform.position.x;
        
        if (p1 - p2 < 20)
        {
            transform.Translate(-5 * Time.deltaTime, 0, 0);
        }
        if (p1 - p2 < -20)
        {
            Destroy(gameObject);
        }

    }
}
