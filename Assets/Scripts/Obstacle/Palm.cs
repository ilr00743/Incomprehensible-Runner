using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palm : Obstacle
{
    [SerializeField] private ParticleSystem _particle;

    public override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
        if (collision.gameObject.TryGetComponent(out PlayerMovement player))
        {
            _particle.Play();       
        }    
    }
}
