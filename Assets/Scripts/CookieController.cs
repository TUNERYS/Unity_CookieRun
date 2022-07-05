using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookieController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;
    GameObject director;

    public Transform pos;
    public float power = 5.0f;
    bool isGround;
    public float checkRadius=1.2f;
    public LayerMask isLayer;

    public bool giant = false;
    float giantTime =0;
    float grow = 0;

    public bool runner = false;
    float runnerTime = 0;

    public bool magnet = false;
    float magnetTime = 0;

    bool canJump = true;
    bool chkSlideBtn = false; //������ �����̵��ư üũ
    bool slide = false;

    public float speed = 1.0f;

    public void damaged()
    {
        animator.SetTrigger("damaged");
    }

    public void giantTrans()
    {
        giant = true;        
;    }
    public void runnerTrans()
    {
        runner = true;
        speed *= 2;
    }
    public void magnetTrans()
    {
        magnet = true;
        Debug.Log("���׳�");
    }

    void ResetSlide()
    {
        if (slide == true)
        {
            transform.Rotate(new Vector3(0, 0, -90));
            animator.SetBool("slide", false);
            slide = false;
        }
    }

    public void die()
    {
        Time.timeScale = 0;

    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = speed;
        rigid2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        director = GameObject.Find("GameDirector");

    }
  
    /************����� �Է�**************/
    public void jmpBtnDown()
    {
        if(isGround && canJump)
        {
            rigid2D.velocity = Vector2.up * power;
            animator.SetTrigger("jump");
            ResetSlide();
        }
        else if(isGround == false && canJump)
        {
            canJump = false;
            rigid2D.velocity = Vector2.up * power;
            animator.SetTrigger("jump2");
        }
    }
    public void sldBtnUp()
    {
        chkSlideBtn = false;
        ResetSlide();
    }
    public void sldBtnDown()
    {
        chkSlideBtn = true;
    }

    void Update()
    {
        /****************�����̵�**************/
        if (slide) transform.Translate(0, -1 * Time.deltaTime * speed * 10, 0);

        else transform.Translate(Time.deltaTime*speed * 10, 0, 0);//�Ϲݻ��� ����

       
        if (Input.GetKeyDown(KeyCode.DownArrow))  //���߿��� �����̵� ������츦 ����
        {
            chkSlideBtn = true;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow)  )
        {
            chkSlideBtn = false;
            ResetSlide();
        }

        if (chkSlideBtn && isGround)
        {
            transform.Rotate(new Vector3(0, 0, 90));
            animator.SetBool("slide", true);
            slide = true;
            chkSlideBtn = false;
        }
        
        isGround = Physics2D.OverlapCircle(pos.position, checkRadius, isLayer);
        if (isGround) //ĳ���Ͱ� ������ üũ
        {
            canJump = true;
            animator.SetBool("isGround", true);
        }
        else
            animator.SetBool("isGround", false);

        /************1������***************/
        if ( (isGround && Input.GetKeyDown(KeyCode.Space) && canJump)/* || (isGround && jmpBtnDown() && canJump)*/) 
        {
            rigid2D.velocity = Vector2.up * power;
            animator.SetTrigger("jump");
            ResetSlide();
        }

        /**************2������*************/
        if ((isGround == false && Input.GetKeyDown(KeyCode.Space) && canJump) /*|| (isGround == false && jmpBtnDown() && canJump)*/) 
        {
            canJump = false;
            rigid2D.velocity = Vector2.up * power;
            animator.SetTrigger("jump2");
        }

        /***************�Ŵ�ȭ**************/
        if(giant)
        {
            if(giantTime<=5)
            {
                if (grow < 0.5f) grow+=Time.deltaTime;
                transform.localScale = new Vector3(1.5f + grow*5, 1.5f + grow*5, 1);
                checkRadius = 3.2f;
                giantTime += Time.deltaTime;
            }
            else if(giantTime>5)
            {
                grow=0;
                transform.localScale = new Vector3(1.5f, 1.5f, 1);
                checkRadius = 1.2f;
                giant = false;
                giantTime = 0;
                director.GetComponent<DirectorController>().giveInvincibleTime(); //����ȭ ������ �����ð� �ο�               
            }
        }
        /***************����****************/
        if (runner)
        {
            if(runnerTime<=3)
            {
                runnerTime += Time.deltaTime;
                animator.SetBool("runner", true);
            }

            else if(runnerTime>3)
            {
                speed /= 2.0f;
                runnerTime = 0;
                runner = false;
                animator.SetBool("runner", false);
                director.GetComponent<DirectorController>().giveInvincibleTime(); //���� ������ �����ð� �ο�               

            }
        }
        /***************�ڼ�**************/
        if (magnet)
        {
            if (magnetTime <= 5)
                magnetTime += Time.deltaTime;
            else if (magnetTime > 5)
            {
                magnet = false;
                magnetTime = 0;
            }
        }
       
    }
}

  

//transform.Translate(speed, 0, 0);
