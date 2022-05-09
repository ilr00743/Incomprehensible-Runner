using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palm : Obstacle
{
    [SerializeField] private ParticleSystem _particle;
    [SerializeField] private PlayerMovement _player;
    
    public override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
        if (collision.gameObject.TryGetComponent(out _player))
        {
            _particle.Play();       
        }    
    }
}
