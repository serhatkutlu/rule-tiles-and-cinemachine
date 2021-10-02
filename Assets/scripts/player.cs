using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    Rigidbody2D rb;
    
    Animator anim;
    [SerializeField]
    float jumpvalue, speed = 5;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        running();
        flipSpriteAndAnimations();
        Jump();
    }

    private void Jump()
    {
        float jump = Input.GetAxis("Jump");
        if (GetComponent<BoxCollider2D>().IsTouchingLayers(LayerMask.GetMask("ground")))
        {


            if (jump > 0)
            {
                rb.velocity += new Vector2(0, jumpvalue);
            }
        }
    }

    void running()
    {
        float x = Input.GetAxis("Horizontal");
        
        
        rb.velocity = new Vector2(x*speed,rb.velocity.y);
        
    }
    void flipSpriteAndAnimations()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1);
            anim.SetBool("running", true);
        }
        else
        {
            anim.SetBool("running", false);
        }
    }
}

