using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {
    public float moveSpeed;
    public float jumpSpeed;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool isGrounded;
    public bool isFalling;
    public float inAirModifier;
    public Vector3 respawnPosition;
    private Rigidbody2D myRigidbody;
    private Animator myAnim;
    private AudioSource jumpSoundFX;
	// Use this for initialization
	void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        jumpSoundFX = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        if(transform.position.x > 66.585f)
        {
            transform.position = new Vector3(-13.335f,transform.position.y,0f);
        }else if(transform.position.x < -15.9f)
        {
            transform.position = new Vector3(64.02f, transform.position.y, 0f);
        }

        if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            if (!isGrounded)
            {
                myRigidbody.velocity = new Vector3(moveSpeed * inAirModifier, myRigidbody.velocity.y, 0f);
            }
            else
            {
                myRigidbody.velocity = new Vector3(moveSpeed, myRigidbody.velocity.y, 0f);
            }
            transform.localScale = new Vector3(.25f, .25f, .25f);
        }
        else if(Input.GetAxisRaw("Horizontal") < 0f)
        {
            if (!isGrounded)
            {
                myRigidbody.velocity = new Vector3(-moveSpeed * inAirModifier, myRigidbody.velocity.y, 0f);
            }
            else
            {
                myRigidbody.velocity = new Vector3(-moveSpeed, myRigidbody.velocity.y, 0f);
            }
            transform.localScale = new Vector3(-.25f, .25f, .25f);
        }
        else
        {
            myRigidbody.velocity = new Vector3(0f, myRigidbody.velocity.y, 0f);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, jumpSpeed, 0f);
            jumpSoundFX.Play();
        }

        if(myRigidbody.velocity.y > -0.1f)
        {
            isFalling = false;
        }
        else
        {
            isFalling = true;
        }

        myAnim.SetFloat("Speed", Mathf.Abs(myRigidbody.velocity.x));
        myAnim.SetBool("Grounded",isGrounded);
        myAnim.SetBool("Falling", isFalling);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "RespawnPlane")
        {
            transform.position = respawnPosition;
        }
    }
}
