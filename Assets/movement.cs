using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public int upForce = 200;
    public float speed = 10;
    public float runspeed = 15;
    public bool isGrounded = false;
    public bool doubleJump = false;
    public Animator kontroler;
    public Transform _originalParent;


    // Start is called before the first frame update
    void Start()
    {
        _originalParent = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {   DoubleJump();
        Skok();

        float move = Input.GetAxis("Horizontal");
        if (move == 0)
        {
            kontroler.SetBool("isRun", false);
        }
        else
        {
            if (move > 0)
            {
                transform.localScale = new Vector3(5, 5, 1);
            }
            else if (move < 0)
            {
                transform.localScale = new Vector3(-5, 5, 1);
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                kontroler.SetBool("isRun", true);
                rb.velocity = new Vector2(move * runspeed * Time.deltaTime, rb.velocity.y);
            }
            else
            {
                kontroler.SetBool("isRun", true);
                rb.velocity = new Vector2(move * speed * Time.deltaTime, rb.velocity.y);
            }
        }

        if (Input.GetKey(KeyCode.Space))
        {
            kontroler.SetBool("isJump", true);
           
        }
       
    }

    void FixedUpdate()
    {
        Ruch();
    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
        doubleJump = false;
    }

    private void Skok()
 {
     if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
 {
            
            rb.AddForce(Vector2.up * upForce);
            isGrounded = false;
            doubleJump = true;
          
 }
 }
    private void DoubleJump()
    {
         if (Input.GetKeyDown(KeyCode.Space) && doubleJump)
         {
             rb.AddForce(Vector2.up * upForce);
             isGrounded = false;
             doubleJump = false;
         }
 }

  private void Ruch()
  {
  
        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * runspeed * Time.deltaTime, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed * Time.deltaTime, rb.velocity.y);
        }
  }
  
 private void OnTriggerEnter2D (Collider2D collision)
 { 
     if (collision.tag == "dziura")
     {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);;
        }
 }
    public void SetParent(Transform newParent)
    {
        _originalParent = transform.parent;
        transform.parent = newParent;
    }
    public void ResetParent()
    { transform.parent = _originalParent; }

}