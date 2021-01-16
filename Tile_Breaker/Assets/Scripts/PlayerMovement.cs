using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int playerNumber;
    public float speed = 5;
    public bool horizontalGauche1;
    public bool horizontalDroite1;
    public bool horizontalGauche2;
    public bool horizontalDroite2;
    public bool Jump1;
    public bool Jump2;
    public Rigidbody2D rb;
    private float startY;
    public float JumpForce = 10;
    public bool isJumping;

    // Start is called before the first frame update
    void Start()
    {
         rb = GetComponent<Rigidbody2D>();
         startY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {

        isJumping = transform.position.y > startY;
        CheckInput();
        CheckMovement();

        if (transform.position.y < startY)
        {
            transform.position = new Vector2(transform.position.x, startY);
            rb.gravityScale = 0;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY;
        }
    }
    public void CheckInput()
    {
        
        horizontalGauche1 = Input.GetKey(KeyCode.Q);
        horizontalDroite1 = Input.GetKey(KeyCode.D);

        horizontalGauche2 = Input.GetKey(KeyCode.LeftArrow);
        horizontalDroite2 = Input.GetKey(KeyCode.RightArrow);

        Jump1 = Input.GetKeyDown(KeyCode.Z) && !isJumping;
        Jump2 = Input.GetKeyDown(KeyCode.UpArrow) && !isJumping;

        if (Input.GetKeyDown(KeyCode.V))
        {
            speed = 2f;
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            speed = 5f;
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            speed = 10f;
        }
        
    }

    public void CheckMovement()
    {
        if(playerNumber == 1)
        {
            if (horizontalGauche1 && !horizontalDroite1)
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }
            else if (horizontalDroite1 && !horizontalGauche1)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }

            if (Jump1)
            {
                rb.gravityScale = 3;
                rb.constraints = RigidbodyConstraints2D.None;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                rb.velocity = new Vector2(rb.velocity.x, JumpForce);
            }
        }

        if (playerNumber == 2)
        {
            if (horizontalGauche2 && !horizontalDroite2)
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }
            else if (horizontalDroite2 && !horizontalGauche2)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }

            if (Jump2)
            {
                rb.gravityScale = 3;
                rb.constraints = RigidbodyConstraints2D.None;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                rb.velocity =  new Vector2(rb.velocity.x,JumpForce);
            }

        }
    }
}
