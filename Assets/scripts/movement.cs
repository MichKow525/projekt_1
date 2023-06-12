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
{   public int deathcount = 0;
    public killcheck script;
    public float score = 0;
    public int coins = 0;
    public int NIesmiertelny;
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
    public int lives;
    public ParticleSystem krew;
    public GameObject player;
    movement playerPosData;
    public AudioSource jumpEffect;
    public AudioSource doubleJumpEffect;
    public AudioSource deathEffect;
    public AudioSource coinEffect;

    private void Awake()
   {
playerPosData= FindObjectOfType<movement>();
playerPosData.PlayerPosLoad();
   }
   // zapisywanie********************
   void Start()
    {
        deathcount = PlayerPrefs.GetInt("smierci",0);
        score = PlayerPrefs.GetFloat("wynik",0);
        lives = PlayerPrefs.GetInt("zycia",3);
       
        if(PlayerPrefs.GetInt("Saved") == 1 && PlayerPrefs.GetInt("TimeToLoad") == 1)
    {
    
        float pX= player.transform.position.x;
        float pY= player.transform.position.y;
        score = PlayerPrefs.GetFloat("wynik");
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

    public void LivesForCoins()
    {
        if (lives < 4)
        {

            if (coins >= 3)
            {
                lives++;
                coins = 0;
                PlayerPrefs.SetInt("zycia", lives);
            }
        }
    }
    
    public void PlayerPosSave()
    {   PlayerPrefs.SetInt("smierci", deathcount);
        PlayerPrefs.SetFloat("wynik",score);
        PlayerPrefs.SetInt("monety", coins);
        PlayerPrefs.SetInt("zycia",lives);
        PlayerPrefs.SetFloat("p_x",player.transform.position.x);
        PlayerPrefs.SetFloat("p_y",player.transform.position.y);
        PlayerPrefs.SetInt("Saved",1);
        PlayerPrefs.Save();
    }
    // koniec zapisywania********************

    public float groundCheckDistance = 0.5f;

    void Update()
    {   DoubleJump();
        Skok();
        animacje();
        if (script.killreward != 0)
        {
            score = score + 10;
        }
       
    }

  
   


    void FixedUpdate()
    {
        GroundCheck();
        LivesForCoins();
        Ruch();
       
    }
   
    private void OnCollisionEnter2D(Collision2D other)
    {   
      

        isGrounded = true;
        doubleJump = false;
    }
  
    private void Skok()
 {
     if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
 {
            jumpEffect.Play();
            rb.AddForce(Vector2.up * upForce);
            isGrounded = false;
            doubleJump = true;
          
 }
 }
    private void DoubleJump()
    {
         if (Input.GetKeyDown(KeyCode.Space) && doubleJump)
         {
            doubleJumpEffect.Play();
            rb.AddForce(Vector2.up * upForce);
            
             doubleJump = false;
         }
 }
    public void GroundCheck()
    {
        RaycastHit2D[] res = new RaycastHit2D[10];
        ContactFilter2D filter = new ContactFilter2D();
        filter.NoFilter();
        Physics2D.Raycast(transform.position, Vector2.down * groundCheckDistance, filter, res);
        bool anyGround = false;
        foreach (RaycastHit2D hit in res)
        {

            if (hit.collider != null && hit.collider.gameObject.CompareTag("Ground") && Vector2.Distance(transform.position, hit.point) < groundCheckDistance)
            {
        
                anyGround = true;
            }
              if (hit.collider != null && hit.collider.gameObject.CompareTag("dziura") && Vector2.Distance(transform.position, hit.point) < groundCheckDistance)
            {
        
                 rb.velocity = Vector2.zero;
              
           coins = 0;
            score = score - 10;
            deathcount++;
            PlayerPrefs.SetInt("œmierci", deathcount);
            PlayerPrefs.SetFloat("p_x", -146);
            PlayerPrefs.SetFloat("p_y", 100);
            PlayerPrefs.SetFloat("wynik", score);
                PlayerPrefs.SetInt("zycia", 3);
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            }
 if (hit.collider != null && hit.collider.gameObject.CompareTag("coin") && Vector2.Distance(transform.position, hit.point) < groundCheckDistance)
            {
            Destroy(hit.transform.gameObject);
                coinEffect.Play();
           score = score + 10;
            coins ++;
            PlayerPrefs.SetFloat("wynik",score);
           
            }
        }
        if (!anyGround)
        {
            isGrounded = false;
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
        if (NIesmiertelny == 0)
        {
        if (collision.tag == "obrazenia")
        {
                deathEffect.Play();
                krew.Play();
            kontroler.SetBool("isDamaged", true);
            isDamaged = true;
            lives--;
            PlayerPrefs.SetInt("zycia", lives);
            Invoke ("invunurable", 0);
            Invoke("nodamage", 1);
                score = score- 5;
            PlayerPrefs.SetFloat("wynik", score);

        }
            if (collision.tag == "meele")
            {
                deathEffect.Play();
                krew.Play();
                kontroler.SetBool("isDamaged", true);
                isDamaged = true;
                lives--;
                PlayerPrefs.SetInt("zycia", lives);
                Invoke("invunurable", 0);
                Invoke("nodamage", 1);
                score = score - 5;
                PlayerPrefs.SetFloat("wynik", score);
                rb.velocity = Vector2.zero;
                rb.AddForce(Vector2.up * burnForce);

            }
            
        }
        if (collision.tag == "lawa")
        {
            deathEffect.Play();
            krew.Play();
            kontroler.SetBool("isDamaged", true);
            isDamaged = true;
            lives--;
            PlayerPrefs.SetInt("zycia", lives);
            Invoke("invunurable", 0);
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * burnForce);
            Invoke("nodamage", 1);
            score = score - 5;
            PlayerPrefs.SetFloat("wynik", score);
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
            Invoke("death", 2);
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

    public void invunurable()
    {
        NIesmiertelny = 1;
        Invoke("koniecinvunurable",1);
    }

    public void koniecinvunurable()
    {
       NIesmiertelny = 0;
    }

    public void death()
    {
      
        deathcount++;
        PlayerPrefs.SetInt("smierci", deathcount);
        PlayerPrefs.SetFloat("p_x",-146);
        PlayerPrefs.SetFloat("p_y",100);
        score = score - 10;
        PlayerPrefs.SetFloat("wynik", score);
        PlayerPrefs.SetInt("zycia", 3);
        coins = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}