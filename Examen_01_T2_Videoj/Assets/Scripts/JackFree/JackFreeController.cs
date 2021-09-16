using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JackFreeController : MonoBehaviour
{
    //public properties
    public float velocityX = 2f;

    //private components
    private SpriteRenderer sr;
    private Animator animator;
    private Rigidbody2D rb;

    //bool states
    
    //private bool isDead = false;
    

    //animations
    private const int ANIMATION_RUN = 0;
    private const int ANIMATION_DEAD = 1;
    private const int ANIMATION_IDLE = 2;

    //tags

    private const string TAG_PLAYER = "Cat";
    private const string TAG_BALL = "Ball";

    //timer
    private float tiempoFlip = 0;

    //
    // Start is called before the first frame update

    
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.tag == TAG_BALL)
        {
            changeAnimation(ANIMATION_IDLE);
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
        
    }

    private void reiniciarTiempo()
    {
        tiempoFlip = 0;
    }

    private void changeAnimation(int animation)
    {
        animator.SetInteger("Estado", animation);
    }
}
