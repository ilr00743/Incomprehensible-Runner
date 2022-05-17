using Runner.Player;
using UnityEngine;

namespace Runner.Obstacle
{
    public class Palm : Obstacle
    {
        [SerializeField] private ParticleSystem _particle;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out PlayerMovement player))
            {
                _particle.Play();
            }
        }
    }
}
