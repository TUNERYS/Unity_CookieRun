using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DirectorController : MonoBehaviour
{
    public float hp = 100;
    float delta = 0;
    float invincibleTime = 0;

    GameObject hpGauge;
    GameObject cookie;
    public bool canDamaged = true;

    GameObject scoreT;
    GameObject GameOver;
    GameObject goHome;
    bool goMenu = false;

    public float score = 0;

    public void giveInvincibleTime()
    {
        canDamaged = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        GameOver = GameObject.Find("notice");
        scoreT = GameObject.Find("ScoreText");
        hpGauge = GameObject.Find("hpGauge");
        cookie = GameObject.Find("CookieD");
        goHome = GameObject.Find("goHome");

    }
    public void decreaseHp()
    {
        if (canDamaged == true)
        {
            cookie.GetComponent<CookieController>().damaged();
            Debug.Log("decreaseHp");
            hp -= 20;
            canDamaged = false;
        }
    }
    public void heal30Hp() { hp += 30; }
    public void heal5HP() { hp += 5; }
    // Update is called once per frame
   
    void Update()
    {
        scoreT.GetComponent<Text>().text = "score : " + score.ToString();
        this.hpGauge.GetComponent<Image>().fillAmount = hp / 100;
        delta += Time.deltaTime;
        if(delta>0.5)
        {
            hp -= 1;
            delta = 0;
            Debug.Log(hp);
        }

        if(canDamaged==false)
        {
            invincibleTime += Time.deltaTime;
            if(invincibleTime>1f) //1초간 무적
            {
                canDamaged = true;
                invincibleTime = 0;
            }
        }

        if (hp<=0 || cookie.transform.position.y<-2.5)
        {
             GameOver.GetComponent<Text>().text = "GAME OVER! ";
            goHome.GetComponent<Text>().text = "터치하면 메인화면으로";
            cookie.GetComponent<CookieController>().die();
            goMenu = true;
        }

        if (goMenu && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("main");
        }

    }
}
