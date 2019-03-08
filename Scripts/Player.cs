using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public int playerSpeed = 10;
    public int playerJumpPower = 1250;
    public float moveX;
    public bool playerInputsEnabled = true;
    public int canJump = 1;
    public int maxJump = 1;
    public float stunnedWaitTime;
    public ParallaxScroll parallax;
    private WaitForSecondsRealtime waitForSecondsRealtime;
    private Rigidbody2D rb;
    private bool facingRight = false;
    private Animator animator;
    private ScoreManager theScoreManager;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        theScoreManager = FindObjectOfType<ScoreManager>();
        theScoreManager.scoreIncreasing = true;
    }

    void Update()
    {
        parallax.offset = transform.position.x;
        PlayerMove();
    }

    void PlayerMove()
    {
        if (playerInputsEnabled)
        {
            moveX = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);

            if (Input.GetButtonDown("Jump"))
            {
                if (canJump >= 1)
                {
                    Jump();
                }
            }
        }

        //ensuring sprite flips left and right
        if(moveX < 0.0f && !facingRight)
        {
            flipPlayer();
        }
        else if(moveX > 0.0f && facingRight)
        {
            flipPlayer();
        }

        //user moving animation
        if(Mathf.Abs(moveX) > 0 && rb.velocity.y == 0) //!!! consider finding a reasonable epsilon see: https://stackoverflow.com/questions/30216575/why-float-epsilon-and-not-zero
            animator.SetBool("UserStepping", true);
        else
            animator.SetBool("UserStepping", false);

        //user jumping animation
        if(rb.velocity.y != 0) //see comment in above conditional statement
            animator.SetBool("UserJumping", true);
        else
            animator.SetBool("UserJumping", false);

    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
        canJump -= 1;
    }

    void flipPlayer()
    {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    void OnCollisionEnter2D(Collision2D Col)
    {
        if(Col.gameObject.tag == "ground")
        {
            canJump = maxJump;
        }

        if(Col.gameObject.tag == "Kate")
        {
            SceneManager.LoadScene("Death");
            theScoreManager.scoreIncreasing = false;
        }
    }
}
