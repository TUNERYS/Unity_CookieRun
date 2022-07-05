using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurdleAnimatorController : MonoBehaviour
{
    Animator animator;
    GameObject cookie;
    float p1, p2;

    void Start()
    {
        animator = GetComponent<Animator>();
        cookie = GameObject.Find("CookieD");


    }

    // Update is called once per frame
    void Update()
    {
        p1 = transform.position.x;
        p2 = cookie.transform.position.x;

        if (p1 - p2 < 10)
        {
            animator.SetTrigger("showUp");
        }

    }
}
