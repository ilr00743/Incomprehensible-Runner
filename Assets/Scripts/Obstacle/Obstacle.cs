using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public event Action Hit;

    public virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerMovement player))
        {
            Hit?.Invoke();    
        }
    }
}
