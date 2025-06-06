using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float seed = 3.0f;
    public bool isToRight;
    int groundContactCount;

    public LayerMask 

    // Start is called before the first frame update
    void Start()
    {
        isToRight = true;
        {
            transform.localScale = new Vector2(-1,1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        bool onGround = Physics2D.CircleCast(
            transform.position,
            0.5f,
            Vector2.down,
            0,
            groundLayer
            );

        if ( onGround ) {
            Rigidbody2D rbody = GetComponent<Rigidbody2D>();
            if (isToRight)
            {
                rbody.velocity = new Vector2(speed, rbody.velocity.y);
            }
            else 
            {
                rbody.velocity = new Vector2(-speed, rbody.velocity.y);
    }


            void Turn()
            {
                isToRight = !isToRight;

                if (isToRight) transform.localScale = new Vector2(-1, 1);
                else transform.localScale = new Vector2(1, 1);

            }

            private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag != "Ground")
        {
            Turn();
        }
        private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {

        }
    }
} 


