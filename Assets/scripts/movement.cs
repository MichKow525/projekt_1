using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public int burnForce = 400;
    public int upForce = 200;
    public float speed = 10;
    public float runspeed = 15;
    public bool isDamaged = false;
    public bool isGrounded = false;
    public bool doubleJump = false;
    public Animator kontroler;
    public Transform _originalParent;
    public Vector3 lastMove;
    public int lives = 2;
    public ParticleSystem krew;
    public GameObject player;
    movement playerPosData;

   private void Awake()
   {
playerPosData= FindObjectOfType<movement>();
playerPosData.PlayerPosLoad();
   }
    void Start()
    {   
        if(PlayerPrefs.GetInt("Saved") == 1 && PlayerPrefs.GetInt("TimeToLoad") == 1)
    {
    
        float pX= player.transform.position.x;
        float pY= player.transform.position.y;

        pX= PlayerPrefs.GetFloat("p_x");
        pY= PlayerPrefs.GetFloat("p_y");
        player.transform.position = new Vector2 (pX, pY);
        lives = PlayerPrefs.GetInt("zycia",3);
        PlayerPrefs.SetInt("TimeToLoad",0);
    }    
        
        
        krew.Stop();
        _originalParent = transform.parent;
    }

    public void  PlayerPosLoad()
    {
        PlayerPrefs.SetInt("TimeToLoad", 1);
        PlayerPrefs.Save();
    }
    
    
    public void PlayerPosSave()
    {
 PlayerPrefs.SetInt("zycia",lives);
        PlayerPrefs.SetFloat("p_x",player.transform.position.x);
        PlayerPrefs.SetFloat("p_y",player.transform.position.y);
        PlayerPrefs.SetInt("Saved",1);
        PlayerPrefs.Save();
    }
    
    
    void Update()
    {   DoubleJump();
        Skok();
        animacje();
       
       
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
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
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
private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.tag == "lawa")
        {
           
            krew.Play();
            kontroler.SetBool("isDamaged", true);
            isDamaged = true;
            lives--;
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * burnForce);
            Invoke("nodamage", 1);

        }

        if (collision.tag == "dziura")
     {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
       
    }
    public void SetParent(Transform newParent)
    {
        _originalParent = transform.parent;
        transform.parent = newParent;
    }
    public void ResetParent()
    { transform.parent = _originalParent; }

    public void animacje()
    {

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

        if (isGrounded == true)
        {
            kontroler.SetBool("isJump", false);
        }
        else
        {
            kontroler.SetBool("isJump", true);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            kontroler.SetBool("isJump", true);
        }
        if (lives == 0)
        {
            kontroler.SetBool("isDead", true);
            Invoke("death", 3);
            return;
        }
        kontroler.SetFloat("yVelocity", rb.velocity.y);

    }
    public void nodamage()
    {
        krew.Stop();
        isDamaged = false;
        kontroler.SetBool("isDamaged", false);
    }
    public void death()
    {   
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}