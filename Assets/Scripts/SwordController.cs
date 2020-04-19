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
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log(other);
        }
    }
}
