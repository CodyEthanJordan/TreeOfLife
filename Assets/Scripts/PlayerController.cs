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

            sc.Move(Input.GetAxis("Horizontal"));

            if (Input.GetButtonDown("LungeRight"))
            {
                sc.Lunge(true);
            }
            else if (Input.GetButtonDown("LungeLeft"))
            {
                sc.Lunge(false);
            }

            if (Input.GetButtonDown("Parry"))
            {
                sc.Parry();
            }

            if (Input.GetKeyDown(KeyCode.K))
            {
                sc.Die();
            }
        }
    }
}
