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
     {
        PlayerPrefs.SetFloat("scena1", 2);
         Time.timeScale = 1f;
        PlayerPrefs.Save();
        SceneManager.LoadScene(2);
     }
}
