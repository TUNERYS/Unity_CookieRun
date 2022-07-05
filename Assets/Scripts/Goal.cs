using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    GameObject cookie;
    GameObject clear;
    GameObject goHome;

    bool goMenu=false;

    // Start is called before the first frame update
    void Start()
    {
        cookie = GameObject.Find("CookieD");
        clear = GameObject.Find("notice");
        goHome = GameObject.Find("goHome");

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            cookie.GetComponent<CookieController>().die();
            clear.GetComponent<Text>().text = "GAME CLEAR!!!";
            goHome.GetComponent<Text>().text = "터치하면 메인화면으로";
            goMenu = true;

        }
    }
        // Update is called once per frame
        void Update()
    {
        if(goMenu&&Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("main");
        }
    }
}
