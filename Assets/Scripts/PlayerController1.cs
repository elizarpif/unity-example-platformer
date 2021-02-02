using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour {

    public float moveSpeed;
    public float jumpSpeed;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public bool isGrounded;

    private Rigidbody2D myRigidBody;
    private Animator myAnimator;

    public Vector3 respawnPosition;
    private LevelManager myLevelManager;

    // Use this for initialization
    void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();

        respawnPosition = transform.position;
        myLevelManager = FindObjectOfType<LevelManager>();
    }

    const float zero = 0f;
	// Update is called once per frame
	void Update () {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);


        float curAxis = Input.GetAxisRaw("Horizontal");

        if (curAxis > zero)
        {
            myRigidBody.velocity = new Vector3(moveSpeed, myRigidBody.velocity.y, 0f);
            transform.localScale = new Vector3(1f, 1f, 1f);
        } else if (curAxis < zero)
        {
            myRigidBody.velocity = new Vector3(-moveSpeed, myRigidBody.velocity.y, 0f);
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
            myRigidBody.velocity = new Vector3(0f, myRigidBody.velocity.y, 0f);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            myRigidBody.velocity = new Vector3(myRigidBody.velocity.x, jumpSpeed, 0f);
        }

        myAnimator.SetFloat("Speed", Mathf.Abs(myRigidBody.velocity.x));
        myAnimator.SetBool("Grounded", isGrounded);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Kill Plane"))
        {
            // gameObject.SetActive(false);
            // transform.position = respawnPosition;
            myLevelManager.Respawn();
        }
        if (other.tag.Equals("CheckPoint"))
        {
            respawnPosition = other.transform.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("MovingPlatform"))
        {
            transform.parent = other.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "MovingPlatform")
        {
            transform.parent = null;
        }
    }
}
