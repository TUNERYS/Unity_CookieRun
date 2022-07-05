using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurdleController : MonoBehaviour
{
    GameObject director;
    GameObject cookie;
    Rigidbody2D rigid2d;
    bool isDestroyed = false;
    float delta;

    // Start is called before the first frame update
    void Start()
    {
        director = GameObject.Find("GameDirector");
        cookie = GameObject.Find("CookieD");
        rigid2d = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) //캐릭터와 충돌
        {
            /*거대화 or 질주*/
            if (cookie.GetComponent<CookieController>().giant || cookie.GetComponent<CookieController>().runner)
            {
                isDestroyed = true;
                director.GetComponent<DirectorController>().score += 100;
                rigid2d.bodyType = RigidbodyType2D.Dynamic;
                rigid2d.gravityScale = 20;
                rigid2d.AddForce(transform.right * 2000);
                rigid2d.AddForce(transform.up * 800);
            }
            else director.GetComponent<DirectorController>().decreaseHp();

        }
    }
    // Update is called once per frame
    void Update()
    {
       
        if (isDestroyed)
        {
            //Debug.Log("d");
            transform.Rotate(0, 0, 1000 * Time.deltaTime);
            if (delta < 2)
            {
                delta += Time.deltaTime;
            }
            else Destroy(gameObject);
        }

    }
}
