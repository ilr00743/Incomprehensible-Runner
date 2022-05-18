using System;
using UnityEngine;

namespace Runner.Player
{
    public class PlayerColliderHandler : MonoBehaviour
    {
        private CapsuleCollider _collider;
        public event Action Hit;

        private void Awake()
        {
            _collider = GetComponent<CapsuleCollider>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out Obstacle.Obstacle obstacle))
            {
                Hit?.Invoke();
                _collider.enabled = false;
            }
        }
    }
}
