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

    private void wylaczenie()
    {
       gameObject.SetActive(false);
    }

    private void wlaczenie()
    {
        gameObject.SetActive(true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
          Invoke("wylaczenie", time);
          Invoke("wlaczenie", 6);
        }
    }
}
