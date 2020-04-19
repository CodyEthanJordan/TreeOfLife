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
            if(!canJump)
            {
                return;
            }

            rb.velocity = Vector2.up * JumpVelocity;
            canJump = false;
        }

        private void Update()
        {
            Debug.Log("yo");
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
        }
    }
}
