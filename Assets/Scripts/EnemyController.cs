using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class EnemyController : MonoBehaviour
    {
        public bool Active;

        private SwordsmanController sc;

        private GameObject player;


        private void Start()
        {
            sc = GetComponent<SwordsmanController>();
            player = GameObject.Find("Player");
        }

        private void Update()
        {
            float distanceToPlayer = Vector2.Distance(player.transform.position, this.transform.position);
            int directionToPlayer = (player.transform.position.x - this.transform.position.x) > 0 ? 1 : -1;
            if (distanceToPlayer < 3)
            {
                //Debug.Log("Attack!");
                sc.Lunge(directionToPlayer > 0);
            }
            else if (distanceToPlayer < 10)
            {
                sc.Move(directionToPlayer * 0.7f);
            }
        }

    }
}
