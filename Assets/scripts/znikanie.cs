using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class znikanie : MonoBehaviour
{
    public float time;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void wy��czenie()
    {
       gameObject.SetActive(false);
    }

    private void w��czenie()
    {
        gameObject.SetActive(true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
          Invoke("wy��czenie", time);
          Invoke("w��czenie", 6);
        }
    }
}
