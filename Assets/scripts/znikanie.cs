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

    private void wyłączenie()
    {
       gameObject.SetActive(false);
    }

    private void włączenie()
    {
        gameObject.SetActive(true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
          Invoke("wyłączenie", time);
          Invoke("włączenie", 6);
        }
    }
}
