using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //Variable velocidad
    public float speed;
    private float speedStore;
    private float speedXStores;
    private float speedIncreaseStore;
    public float speedMul;
    public float speedIncreaseX;
    private float speedXCount;
    //Variables salto
    public float jumpTime;
    private float jumpTimeCounter;
    private bool stopJump;
    private bool canDoubleJump;
    public float jumpForce;
    //Variables para saber si esta tocando suelo
    public bool grounded;
    public LayerMask isGround;
    public Transform groundCheck;
    public float groundCheckRadio;
    //Variables para sonido
    public AudioSource jumpSound;
    public AudioSource deathSound;

    private Animator Animator;
    public GameManager gameManager;
    private Rigidbody2D RB;


    
    void Start () {
        RB = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        jumpTimeCounter = jumpTime;
        speedXCount = speedIncreaseX;
        speedStore = speed;
        speedXStores = speedXCount;
        speedIncreaseStore = speedIncreaseX;
        stopJump = true;
	}
	
	
	void Update () {
        /*Saber si esta en Ground para no saltar en el aire*/
         grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadio,isGround);

        if (transform.position.x > speedXCount) {
            speedXCount += speedIncreaseX;
            speedIncreaseX += speedIncreaseX * speedMul;
            speed = speed * speedMul;
        }

        /*Controles para saltar*/
        RB.velocity = new Vector2(speed , RB.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
            if (grounded)
            {
                RB.velocity = new Vector2(RB.velocity.x, jumpForce);
                stopJump = false;
                jumpSound.Play();
            }

            if (!grounded && canDoubleJump) {
                RB.velocity = new Vector2(RB.velocity.x, jumpForce);
                jumpTimeCounter = jumpTime;
                canDoubleJump = false;
                stopJump = false;
                jumpSound.Play();
            }

        }
        if ((Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) && !stopJump) {
            if (jumpTimeCounter > 0) {
                RB.velocity = new Vector2(RB.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0)) {
            jumpTimeCounter = 0;
            stopJump = true;
        }

        if (grounded) {
            jumpTimeCounter = jumpTime;
            canDoubleJump = true;
        }


        /*Animaciones*/
        Animator.SetFloat("Speed", RB.velocity.x);
        Animator.SetBool("isGrounded",grounded);
	}

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "killbox") {
            
            gameManager.RestartGame();
            speed = speedStore;
            speedXCount = speedXStores;
            speedIncreaseX = speedIncreaseStore;
            deathSound.Play();
            
        }
    }

}
  