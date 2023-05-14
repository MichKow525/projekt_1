using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killcheck : MonoBehaviour
{
   public float bounce;
   public Rigidbody2D rb2D;

    void Start()
    {
        
    }

    // Update is called once per frame
   
    public void OnCollisionEnter2D(Collision2D collision)
     {
         if (collision.gameObject.tag == "Weak_Point")
         {  
             Destroy(collision.gameObject);
             rb2D.velocity = new Vector2(rb2D.velocity.x,bounce);
         }
     }
}
