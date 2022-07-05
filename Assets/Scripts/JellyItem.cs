using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyItem : MonoBehaviour
{
    GameObject director;
    GameObject cookie;

    public int jellyScore = 123;
    float x1, x2, y1, y2;


    // Start is called before the first frame update
    void Start()
    {
        director = GameObject.Find("GameDirector");
        cookie = GameObject.Find("CookieD");

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //Debug.Log("jelly");
            director.GetComponent<DirectorController>().score += jellyScore;
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        x1 = transform.position.x;
        x2 = cookie.transform.position.x; 
        y1 = transform.position.y;
        y2 = cookie.transform.position.y;


        if (cookie.GetComponent<CookieController>().magnet)
        {
            if (-0.2f < x1 - x2 && x1 - x2 < 5)
                transform.position = Vector2.Lerp(transform.position, cookie.transform.position, Time.deltaTime * 10);
        }
       

    }
}
