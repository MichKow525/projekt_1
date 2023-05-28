using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class nextlvl : MonoBehaviour
{   
    public float scena;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
     {  float p_x = -150;
        float p_y = 117;
        PlayerPrefs.GetInt("zycia");
        PlayerPrefs.SetFloat("p_x", p_x);
        PlayerPrefs.SetFloat("p_y", p_y);
        PlayerPrefs.SetFloat("scena1", 2);
        Time.timeScale = 1f;
        PlayerPrefs.Save();
        SceneManager.LoadScene(2);
     }
}
