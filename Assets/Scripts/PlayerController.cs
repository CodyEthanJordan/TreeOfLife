using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    public float JumpVelocity;
    public float FallMultiplier;
    public float LowGravFactor;

    [SerializeField]
    private Transform groundCheck;

    private bool canJump;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        //check for jump
        var collider = Physics2D.OverlapCircle(groundCheck.position, 0.12f);
        if(collider is null)
        {
            canJump = false;
        }

        if(Input.GetButtonDown("Jump"))
        {
            rb.velocity = Vector2.up * JumpVelocity;
            canJump = false;
        }

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (FallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (LowGravFactor - 1) * Time.deltaTime;
        }

        rb.velocity = new Vector2(0, 0);

        
    }
}
