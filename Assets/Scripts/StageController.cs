using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    public GameObject oldBack1, oldBack2, oldBack3, oldBack4, oldBack5;
    public GameObject newBack1, newBack2, newBack3, newBack4, newBack5;
    public GameObject oldStage;
    public GameObject newStage;
    GameObject cookie;
    bool spdUp = false;


    // Start is called before the first frame update
    void Start()
    {
        cookie = GameObject.Find("CookieD");
        newStage.SetActive(false);
    }

    bool chk=false;

    void FadeOut(GameObject obj, float time)
    {
        Color oldcolor = obj.GetComponent<SpriteRenderer>().color;
        if (oldcolor.a > 0)
        {
            oldcolor.a -= Time.deltaTime / time;
            //Debug.Log(oldcolor.a);
            obj.GetComponent<SpriteRenderer>().color = oldcolor;
        }      
    }
    void FadeIn(GameObject obj, float alpha, float time)
    {
        Color newcolor = obj.GetComponent<SpriteRenderer>().color;
        if (newcolor.a < alpha)
        {
            newcolor.a += Time.deltaTime / time;
            obj.GetComponent<SpriteRenderer>().color = newcolor;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                 chk = true;
            spdUp = true;
            //Debug.Log("bye");
            }
        }
    
    // Update is called once per frame
    void Update()
    {
        if(chk)
        {
            newStage.SetActive(true);

            FadeOut(oldBack1, 2);
            FadeOut(oldBack2, 2);
            FadeOut(oldBack3, 2);
            FadeOut(oldBack4, 2);
            FadeOut(oldBack5, 2);

            FadeIn(newBack1, 1, 2);
            FadeIn(newBack2, 1, 2);
            FadeIn(newBack3, 1, 2);
            FadeIn(newBack4, 1, 2);
            FadeIn(newBack5, 1, 2);


            if (spdUp)
            {
                cookie.GetComponent<CookieController>().speed *= 1.1f;
                spdUp = false;
            }

            Destroy(oldStage, 5);





        }
    }
}
