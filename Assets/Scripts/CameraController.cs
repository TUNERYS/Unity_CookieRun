using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject cookie;
    float cookiePos;


    // Start is called before the first frame update
    void Start()
    {
        cookie = GameObject.Find("CookieD");

    }
    // Update is called once per frame
    void Update()
    {

        cookiePos = cookie.transform.position.x;
        transform.position = new Vector3(cookiePos+5.5f , 2.68f,-8);
    }
}
