using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float climbSpeed = 8f;
    [SerializeField] private float jumpPower = 15f;
    [SerializeField] private Rigidbody2D myRB;
    [SerializeField] private Transform groundDetect;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] LayerMask climbing;
    [SerializeField] CapsuleCollider2D myCollider;

    private float horizontal = 0f;
    private float vertical = 0f;
    private bool isFacingRight = true;
    private Animator myAnimator;
    private float startingGravity;

  
    // Start is called before the first frame update
    private void Start()
    {
        myAnimator = GetComponent<Animator>();
        startingGravity = myRB.GetComponent<Rigidbody2D>().gravityScale;
    }
    private void Update()
    {
        FlipPlayer();
        Run();
        ClimbLadder();
    }
    
    private void LateUpdate()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("Jump") && IsOnGround())
        {
            Debug.Log("Jump!");
            myRB.velocity = new Vector2(myRB.velocity.x, jumpPower);
        }
        else if (Input.GetButtonUp("Jump") && myRB.velocity.y > 0f)
        {
            myRB.velocity = new Vector2(myRB.velocity.x, jumpPower * 0.5f);
        }
    }
    private bool IsOnGround()
    {
        return Physics2D.OverlapCircle(groundDetect.position, 0.2f, groundLayer);
    }

    private void FixedUpdate()
    {
        //horizontal = Input.GetAxisRaw("Horizontal");
        myRB.velocity = new Vector2(horizontal * speed, myRB.velocity.y);
    }

    private void FlipPlayer()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 playerScale = transform.localScale;
            playerScale.x *= -1f;
            transform.localScale = playerScale;
        }
    }

    private void Run()
    {
        if (horizontal != 0)
        {
            myAnimator.SetBool("isRunning", true);
        }
        else
        {
            myAnimator.SetBool("isRunning", false);
        }
    }
    
    private void ClimbLadder()
    {
        bool isMovingVertical = Mathf.Abs(myRB.velocity.y) > Mathf.Epsilon;

        if(!myCollider.IsTouchingLayers(climbing))
        {
            myRB.gravityScale = startingGravity;
            myAnimator.SetBool("isClimbing", false);

        }
        Vector2 climbVelocity = new Vector2(myRB.velocity.x, vertical * climbSpeed);
        myRB.velocity = climbVelocity;
        myRB.gravityScale = 0f;
        myAnimator.SetBool("isClimbing", isMovingVertical);
       
    }
}
