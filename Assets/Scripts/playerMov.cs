using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMov : MonoBehaviour
{
    private Rigidbody2D rig;

    public Transform detectGround;

    public LayerMask ground;

    public float velocity = 0;
    public float moveHorizontal;
    public float jumpForce;

    public bool doubleJump;
    public bool isGround = true;


    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        
    }

    public void Movement()
    {
        moveHorizontal =Input.GetAxis("Horizontal");
        transform.position += new Vector3(moveHorizontal, 0, 0) * velocity * Time.deltaTime;
    }

    void jump()
    {
        isGround = Physics2D.OverlapCircle(detectGround.position, 0.2f, ground); //detecta se player está no chão

        if (Input.GetButtonDown("Jump"))
        {
            if(isGround == true)
            {
                rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                doubleJump = true;
            }

            else
            {
                if(doubleJump == true)
                {
                    rig.AddForce(new Vector2(0, jumpForce*0.5f), ForceMode2D.Impulse);
                    doubleJump = false;
                }
            }
        }
    }

    // Update is called once per frame
       void Update()
    {
        jump();

    }
    void FixedUpdate()
    {
        Movement();
    }
}
