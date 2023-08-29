using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    private float moveInput;

    public bool isGrounded;
    public bool onWall;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    public bool Left;
    public bool Right;
    public bool canMove;

    private float jumpTimeCounter;
    public float jumpTime;
    public bool isJumping;

    public Animator anim;

    public GameObject gun;
    public GameObject gun2;

    public GameObject BulletSpawn;



    public float sped = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Left = true;
        canMove = true;
        
    }

    private void FixedUpdate()
    {
       

        moveInput = Input.GetAxisRaw("Horizontal");

        if (transform.Find("Rambro") != null)
        {
            anim = transform.Find("Rambro").GetComponent<Animator>();
        }
        else if (transform.Find("Brodell Walker") != null)
        {
            anim = transform.Find("Brodell Walker").GetComponent<Animator>();
        }

        if (canMove == true)
        {
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        }
        
        
    }
    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Weapon") != null)
        {
            gun = GameObject.Find("Weapon");
           
        }
        if (GameObject.Find("Weapon2") != null)
        {
            
            gun2 = GameObject.Find("Weapon2");
        }

        BulletSpawn = GameObject.Find("BulletSpawn");
        

        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        


        if (Input.GetKeyDown(KeyCode.Space))
        {
           
                
            
            if (isGrounded == true || onWall == true)
            {
                
                isJumping = true;
                jumpTimeCounter = jumpTime;
                rb.velocity = Vector2.up * jumpForce;
                anim.SetBool("Jump", true);
                anim.SetBool("Walk", false);
            }
            
        }
        if(Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if(jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                
                isJumping = false;
            }
            
        }


        
        if (isGrounded == true || onWall == true)
        {
            if(isJumping == false)
            {
                anim.SetBool("Jump", false);
            }
            
        }


        if (Input.GetKeyUp(KeyCode.Space))
        {
            Left = !Left;
            isJumping = false;
        }

        if (onWall == true && !Input.GetKeyDown(KeyCode.Space) && isGrounded == false)
        {
            if (Left == false)
            {
                anim.SetBool("WallRight", true);
                gun.SetActive(false);
                gun2.SetActive(false);
                anim.SetBool("WallLeft", false);

            }
            if (Left == true)
            {
                anim.SetBool("WallLeft", true);
                gun.SetActive(false);
                gun2.SetActive(true);
                anim.SetBool("WallRight", false);
            }
            
        }
        else 
        {
            anim.SetBool("WallLeft", false);

            anim.SetBool("WallRight", false);
            
               
        }
       

        Vector3 CharacterScale = transform.localScale;
        if (Input.GetAxis("Horizontal") == 0 || canMove == false || onWall == true || isGrounded == false)
        {
            anim.SetBool("Walk", false);
        }
        if (canMove == true && Input.GetAxis("Horizontal") < 0)
        {
            Right = false;
            CharacterScale.x = -1;
            if (isGrounded == true )
            {
                anim.SetBool("Walk", true);
            }                                                
        }
       

        if (canMove == true && Input.GetAxis("Horizontal") > 0 )
        {
            Right = true;
            CharacterScale.x = 1;
            if (isGrounded == true)
            {
                anim.SetBool("Walk", true);
            }
            
                                    
        }
        

        
        transform.localScale = CharacterScale;

        
    }

    public void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Murder")
        {

        }
    }


}
