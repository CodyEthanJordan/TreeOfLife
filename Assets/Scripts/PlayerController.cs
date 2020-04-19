using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private SwordsmanController sc;
       
        void Awake()
        {

        }

        void Update()
        {
            if (Input.GetButtonDown("Jump"))
            {
                Debug.Log("Jump");
                sc.Jump();
            }

            //if (rb.velocity.y < 0)
            //{
            //    rb.velocity += Vector2.up * Physics2D.gravity.y * (FallMultiplier - 1) * Time.deltaTime;
            //}
            //else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
            //{
            //    rb.velocity += Vector2.up * Physics2D.gravity.y * (LowGravFactor - 1) * Time.deltaTime;
            //}

            //float horizontalVelocity = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
            //anim.SetFloat("Speed", Mathf.Abs(horizontalVelocity));

            //if (horizontalVelocity > 0)
            //{
            //    sr.flipX = true;
            //}
            //else if (horizontalVelocity < 0)
            //{
            //    sr.flipX = false;
            //}

            //rb.velocity = new Vector2(horizontalVelocity, rb.velocity.y);

            //lungeTimer += Time.deltaTime;
            //if (lungeTimer >= LungeCooldown)
            //{

            //    if (Input.GetButtonDown("Lunge"))
            //    {
            //        anim.SetTrigger("Lunge");
            //        dashDirection = sr.flipX ? 1 : -1;
            //        dashTimer = 0;
            //        lungeTimer = 0;
            //    }
            //    if (Input.GetButtonDown("LungeRight"))
            //    {
            //        anim.SetTrigger("Lunge");
            //        dashDirection = 1;
            //        dashTimer = 0;
            //        lungeTimer = 0;
            //    }
            //    if (Input.GetButtonDown("LungeLeft"))
            //    {
            //        anim.SetTrigger("Lunge");
            //        dashDirection = -1;
            //        dashTimer = 0;
            //        lungeTimer = 0;
            //    }
            //}


            //if(Input.GetKeyDown(KeyCode.K))
            //{
            //    Die();
            //}

            //dashTimer += Time.deltaTime;
            //if (dashDirection != 0)
            //{
            //    if (dashTimer >= DashTime)
            //    {
            //        dashDirection = 0;
            //    }
            //    else
            //    {
            //        rb.velocity += new Vector2(DashSpeed * dashDirection, 0);
            //    }
            //}


        }
    }
}
