using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swiatla : MonoBehaviour
{
    public Light light3, light4;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            light3.enabled = false;
            light4.enabled = true;
        }
    }

}

