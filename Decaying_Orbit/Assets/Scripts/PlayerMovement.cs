using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float horizontalMove = 0f;

    //speed at which the player moves along the horizontal axis
    [SerializeField]
    public float horizontalMoveSpeed = 7.0f;

    //speed at which the player jumps
    [SerializeField]
    public float jumpSpeed = 10.0f;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        //sets movement keys to what is set in the InputManager under project settings
        horizontalMove = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalMove * horizontalMoveSpeed, rb.velocity.y);

        if(Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
    }
}
