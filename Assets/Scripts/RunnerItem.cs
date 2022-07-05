using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerItem : MonoBehaviour
{
    GameObject cookie;
    // Start is called before the first frame update
    void Start()
    {
        cookie = GameObject.Find("CookieD");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            cookie.GetComponent<CookieController>().runnerTrans();
            
        }
    }
 // Update is called once per frame
void Update()
    {
        
    }
}
