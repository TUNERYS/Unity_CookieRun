using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuDirector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void startBtn()
    {
        SceneManager.LoadScene("GameScene");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
