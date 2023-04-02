using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wylacznik : MonoBehaviour
{
    public Light light1,light2;

    public void Start()
    {
        light1.enabled = false;
        light2.enabled = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            light1.enabled = false;
            light2.enabled = true;
        }
    }

}
