using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class SwordController : MonoBehaviour
    {
        public float ParryRecoil;
        public float FlaccidFrames;

        [SerializeField]
        private GameObject weilder;

        private float flaccidTimer = 1000;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.CompareTag("Parrybox"))
            {
                Debug.Log("parry");
                flaccidTimer = 0;
                //recoil
                int directionToParry = other.transform.position.x - weilder.transform.position.x > 0 ? 1 : -1;
                weilder.GetComponent<Rigidbody2D>()
                    .AddForce(new Vector2(-directionToParry * ParryRecoil, 0), ForceMode2D.Impulse);
            }

            if(other.CompareTag("Enemy") || other.CompareTag("Player"))
            {
                if(flaccidTimer >= FlaccidFrames)
                {
                    other.gameObject.GetComponent<SwordsmanController>().Die();
                }
            }

           
        }

        private void Update()
        {
            flaccidTimer += Time.deltaTime;
        }
    }
}
