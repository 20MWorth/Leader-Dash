using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpHeight = 15f;
    [SerializeField] float climbSpeed = 10f;
    [SerializeField] TextMeshProUGUI instructions;
    [SerializeField] TextMeshProUGUI leftClickToContinue;
    float gravityScaleAtStart;
    bool disableInteractions = false;
    int instructCount = 0;


    // cached
    Rigidbody2D myRigidBody;
    Animator myAnimator;
    CapsuleCollider2D myBodyCollider;
    BoxCollider2D myFeetCollider;


    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        myFeetCollider = GetComponent<BoxCollider2D>();
        gravityScaleAtStart = myRigidBody.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (disableInteractions && Input.GetMouseButtonDown(0))
        {
            disableInteractions = false;
            instructions.text = "";
            leftClickToContinue.text = "";
            instructCount++;
        }
        else if (!disableInteractions)
        {
            Run();
            ClimbLadder();
            Jump();
            FlipSprite();
            Instruct();
        }

    }

    private void Run()
    {
        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal"); // value between -1 and +1
        Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, myRigidBody.velocity.y);
        myRigidBody.velocity = playerVelocity;
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("Running", playerHasHorizontalSpeed);
    }

    private void ClimbLadder()
    {
        if (!myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            myAnimator.SetBool("Climbing", false);
            myRigidBody.gravityScale = gravityScaleAtStart;
            return;
        }

        bool playerHasVerticalSpeed = myRigidBody.velocity.y != 0f;
        myAnimator.SetBool("Climbing", playerHasVerticalSpeed);
        float controlThrow = CrossPlatformInputManager.GetAxis("Vertical");
        Vector2 climbVelocity = new Vector2(myRigidBody.velocity.x, controlThrow * climbSpeed);
        myRigidBody.velocity = climbVelocity;
        myRigidBody.gravityScale = 0f;
    }
    private void Jump()
    {
        if (!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Foreground"))) { return; }
        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            Vector2 jumpVelocityToAdd = new Vector2(0f, jumpHeight);
            myRigidBody.velocity += (jumpVelocityToAdd);
        }
    }
    private void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);
        }
    }
    private void Instruct()
    {
        if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Instruct")) && instructCount == 0)
        {
            var currentSceneindex = SceneManager.GetActiveScene().buildIndex;
            if (currentSceneindex == 1)
            {
                myRigidBody.velocity = new Vector2(0f, 0f); //stops player from moving
                myAnimator.SetBool("Running", false); //stops running animation
                disableInteractions = true; //disables all functions in Update()
                instructions.text =
                "Hello Leader! I see you have become interested in completing the BAA's." +
                " Let's get you started on the Future Level. " +
                "Your Future Level activity is to create a bulletin board/poster promoting FBLA." +
                " Collect the scissors, paper, stapler, and bulletin board to continue. Don't forget, we're working with a deadline, so you can only restart a few times!";
                leftClickToContinue.text = "Left Click Mouse to Continue...";
            }
            if (currentSceneindex == 2)
            {
                myRigidBody.velocity = new Vector2(0f, 0f);
                myAnimator.SetBool("Running", false);
                disableInteractions = true;
                instructions.text =
                "Wow, great job with the Future Level! Your bulletin board looks great." +
                " Now, let's get moving on the business level, it might take you a bit longer!" +
                " This time, you'll be creating a social media graphic with #FBLA: AWorldOfOpportunity." +
                " Collect the Adobe Illustrator App, smart phone, Twitter App, and hashtag to continue.";
                leftClickToContinue.text = "Left Click Mouse to Continue...";
            }
            if (currentSceneindex == 3)
            {
                myRigidBody.velocity = new Vector2(0f, 0f);
                myAnimator.SetBool("Running", false);
                disableInteractions = true;
                instructions.text =
                "You're on a roll now! Might as well continue on to the leader level - and don't forget about the deadline!" +
                " For the Leader Level, I'll need you to record a podcast that promotes FBLA." +
                " Collect the microphone, headphones, mixing board, and WiFi access to continue to America Level.";
                leftClickToContinue.text = "Left Click Mouse to Continue...";
            }
            if (currentSceneindex == 4)
            {
                myRigidBody.velocity = new Vector2(0f, 0f);
                myAnimator.SetBool("Running", false);
                disableInteractions = true;
                instructions.text =
                "Your Leadership is really showing! All you have left is the America Level, which is by far the most rigorous." +
                " For this level, I'll need you to start by creating a board/card game that teaches kids about American Enterprise Day, and then upload a picture of it!" +
                " To finish, you'll need to collect the fake money, cards, dice, and camera. You got this!";
                leftClickToContinue.text = "Left Click Mouse to Continue...";

            }
        }
    }
}
