using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class ScreenTransition : MonoBehaviour
    {
        public Transform Destination;
        public bool SetFixedCamera;
        public Transform CameraPosition;


        [SerializeField]
        private Cinemachine.CinemachineVirtualCamera vc;
        [SerializeField]
        private GameObject player;

        private void Start()
        {
            vc = GameObject.Find("VCAM").GetComponent<Cinemachine.CinemachineVirtualCamera>();
            player = GameObject.Find("Player");
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(!other.CompareTag("Player"))
            {
                // not the player, don't do anything
                return;
            }

            other.gameObject.transform.position = Destination.position;
            vc.transform.position = CameraPosition.position;
            if(SetFixedCamera)
            {
                vc.Follow = null;
            }
            else
            {
                vc.Follow = player.transform;
            }

        }

        void OnDrawGizmosSelected()
        {
                Gizmos.color = Color.blue;
                Gizmos.DrawLine(transform.position, Destination.position);
        }
    }
}
