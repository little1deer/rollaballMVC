using System;
using UnityEngine;
namespace RollaBall
{
    public class PlayerController : MonoBehaviour
    {
        private int _keys = 0;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Key"))
            {
                _keys++;
                Destroy(other.gameObject);
            }
            if (other.CompareTag("Finish")&&_keys == 2)
            {
                Debug.Log("22");
            }
        }
    }
}