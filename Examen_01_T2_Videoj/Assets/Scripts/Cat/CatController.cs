using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{

    //Public properties
    public float velocityX = 5f;
    public float jumpForce = 40f;

    public GameObject rightBall;
    public GameObject leftBall;

    private ScoreController scoreController;

    //transform
    private Transform cameraTransform;
    private Vector3 cameraPosition;

    //private components
    private SpriteRenderer sr;
    private Animator animator;
    private Rigidbody2D rb;


    //bool states
    private bool isJumping = false;
    //private bool isDead = false;
    public bool isSliding = false;

    //animations
    private const int ANIMATION_IDLE = 0;
    private const int ANIMATION_RUN = 1;
    private const int ANIMATION_SLIDE = 2;
    private const int ANIMATION_JUMP = 3;
    private const int ANIMATION_DEAD = 4;

    //tags

    private const string TAG_GROUND = "Ground";

    private const string TAG_BRONZECOIN = "bronzeCoin";
    private const string TAG_SILVERCOIN = "silverCoin";
    private const string TAG_GOLDCOIN = "goldCoin";


    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        scoreController = FindObjectOfType<ScoreController>();

        cameraTransform = Camera.main.transform;
        cameraPosition = new Vector3(6,1,-10);
    }

    // Update is called once per frame
    void Update()
    {
        estaDeslizando();
        cameraPosition.x = transform.position.x;
        cameraPosition.y = transform.position.y;
        cameraTransform.position = cameraPosition;

        rb.velocity = new Vector2(0,rb.velocity.y);

        changeAnimation(ANIMATION_IDLE);

        

        //caminarDerecha
        if(Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(velocityX,rb.velocity.y);
            sr.flipX = false;
            changeAnimation(ANIMATION_RUN);
            if(Input.GetKey(KeyCode.X) && !isSliding)
            {
                rb.velocity = new Vector2((velocityX * 2),rb.velocity.y);
                changeAnimation(ANIMATION_SLIDE);
                isSliding = true;
                Debug.Log("Está Deslizando a la derecha");
            }
        }

        //caminarIzquierda
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-velocityX,rb.velocity.y);
            sr.flipX = true;
            changeAnimation(ANIMATION_RUN);
            if(Input.GetKey(KeyCode.X) && !isSliding)
            {
                rb.velocity = new Vector2((-velocityX * 2),rb.velocity.y);
                changeAnimation(ANIMATION_SLIDE);
                isSliding = true;
                Debug.Log("Está Deslizando a la izquierda");
            }
        }


        


        if(Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            changeAnimation(ANIMATION_JUMP);
            cameraPosition.x = transform.position.x;
            cameraTransform.position = cameraPosition;
            isJumping = true;
        }

        if(Input.GetKeyUp(KeyCode.J))
        {
            //Crear el objeto
            //1. GameObject que debemos crear
            //2. Position dónde va a aparecer
            //3. Rotación
            var ball = sr.flipX ? leftBall : rightBall; 
            var position = new Vector2(transform.position.x,transform.position.y);
            var rotation = rightBall.transform.rotation;
            Instantiate(ball, position, rotation);
        }
        
        
    }



    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.tag == TAG_GROUND)
        {
            isJumping = false;
        }
        if(collision.gameObject.tag == TAG_BRONZECOIN)
        {
            Destroy(collision.gameObject);
            scoreController.bronzeCoinScore(10);
            Debug.Log(scoreController.GetBronzeCoinsScore());
        }
        else if(collision.gameObject.tag == TAG_SILVERCOIN)
        {
            Destroy(collision.gameObject);
            scoreController.silverCoinScore(20);
            Debug.Log(scoreController.GetSilverCoinsScore());
        }
        else if(collision.gameObject.tag == TAG_GOLDCOIN)
        {
            Destroy(collision.gameObject);
            scoreController.goldCoinScore(30);
            Debug.Log(scoreController.GetGoldCoinsScore());
        }
        /*if(isSliding)
        {

        }*/
    }

    private void estaDeslizando()
    {
        isSliding = false;
    }

    private void changeAnimation(int animation)
    {
        animator.SetInteger("Estado", animation);
    }
}
