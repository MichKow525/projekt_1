using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class killcheck : MonoBehaviour
{
    private int hitpoints;
    public float bounce;
    public Rigidbody2D rb2D;
    public float killreward;
    void Start()
    {
        hitpoints = 3;
        killreward = PlayerPrefs.GetFloat("killpoint");
    }

    // Update is called once per frame
   
    public void OnCollisionEnter2D(Collision2D collision)
    { 
         if (collision.gameObject.tag == "Weak_Point")
         {
            killreward = killreward + 10;
            PlayerPrefs.SetFloat("killpoint", killreward);
             Destroy(collision.gameObject);
             rb2D.velocity = new Vector2(rb2D.velocity.x,bounce);
           
        }
        if (collision.gameObject.tag == "boss")
        {
            hitpoints--;
            rb2D.velocity = new Vector2(rb2D.velocity.x+12, bounce*2);
            if (hitpoints <= 0)
            {


                Destroy(collision.gameObject);
                SceneManager.LoadScene(3);
            }
        }
     }
}
