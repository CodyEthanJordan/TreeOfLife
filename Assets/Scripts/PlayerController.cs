using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    public float JumpVelocity;
    public float LungeVelocity;
    public float FallMultiplier;
    public float LowGravFactor;

    [SerializeField]
    private Transform groundCheck;

    private bool canJump;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
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
        else
        {
            canJump = true;
        }

        if(Input.GetButtonDown("Jump") && canJump)
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

        float horizontalVelocity = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
        anim.SetFloat("Speed", Mathf.Abs(horizontalVelocity));

        if(horizontalVelocity > 0)
        {
            sr.flipX = true;
        }
        else if(horizontalVelocity < 0)
        {
            sr.flipX = false;
        }

        rb.velocity = new Vector2(horizontalVelocity, rb.velocity.y);
        
        if(Input.GetButtonDown("Lunge"))
        {
            anim.SetTrigger("Lunge");
            float lunge = LungeVelocity * (sr.flipX ? -1 : 1);
            rb.velocity += new Vector2(lunge, lunge * 0.1f);
        }

        
    }
}
