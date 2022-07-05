using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartItem : MonoBehaviour
{
    GameObject director;
    public int heal = 30;

    // Start is called before the first frame update
    void Start()
    {
        director = GameObject.Find("GameDirector");

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            director.GetComponent<DirectorController>().hp += heal;
            Destroy(gameObject);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
