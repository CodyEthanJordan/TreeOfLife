using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class SwordsmanController : MonoBehaviour
    {
        public float Speed;
        public float JumpVelocity;
        public float LungeCooldown;
        public float FallMultiplier;
        public float LowGravFactor;
        public float DashSpeed;
        public float DashTime;
        public bool Dead;

        [SerializeField]
        private Transform groundCheck;

        protected bool canJump;
        protected int dashDirection = 0;
        protected float dashTimer = 10000;
        protected float lungeTimer = 1000;

        protected Rigidbody2D rb;
        protected SpriteRenderer sr;
        protected Animator anim;

        void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            sr = GetComponent<SpriteRenderer>();
            anim = GetComponent<Animator>();
        }

        public void Die()
        {
            anim.SetTrigger("Die");
            Dead = true;
        }

        public void Jump()
        {
            Debug.Log(canJump);
            if(!canJump || Dead)
            {
                return;
            }

            rb.AddForce(new Vector2(0, JumpVelocity), ForceMode2D.Impulse);
            canJump = false;
        }

        public void Move(float dir)
        {
            if(Dead)
            {
                return;
            }
            float horizontalVelocity = dir * Speed * Time.deltaTime;
            anim.SetFloat("Speed", Mathf.Abs(horizontalVelocity));
            Vector2 force = new Vector2(horizontalVelocity, 0);
            rb.AddForce(force, ForceMode2D.Force);
        }

        public void Lunge(bool right)
        {
            if(lungeTimer < LungeCooldown || Dead)
            {
                return; //can't do that yet
            }

            anim.SetTrigger("Lunge");
            dashDirection = right ? 1 : -1;
            dashTimer = 0;
            lungeTimer = 0;
            rb.AddForce(new Vector2(DashSpeed * dashDirection, 0), ForceMode2D.Impulse);
        }

        public void Parry()
        {
            anim.SetTrigger("Parry");
        }

        private void Update()
        {
            //check for jump
            var collider = Physics2D.OverlapCircle(groundCheck.position, 0.12f);
            if (collider is null)
            {
                canJump = false;
            }
            else
            {
                canJump = true;
            }

            if (rb.velocity.y < 0)
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (FallMultiplier - 1) * Time.deltaTime;
            }
            else if (rb.velocity.y > 0) //TODO: jump input?
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (LowGravFactor - 1) * Time.deltaTime;
            }

            if (rb.velocity.x > 0.01)
            {
                sr.flipX = true;
            }
            else if (rb.velocity.x < -0.01)
            {
                sr.flipX = false;
            }

            lungeTimer += Time.deltaTime;
            dashTimer += Time.deltaTime;
            if (dashDirection != 0)
            {
                if (dashTimer >= DashTime)
                {
                    dashDirection = 0;
                }
                else
                {
                    //rb.velocity += new Vector2(DashSpeed * dashDirection, DashSpeed * dashDirection);
                }
            }
                    Debug.Log(rb.velocity);

        }
    }
}
