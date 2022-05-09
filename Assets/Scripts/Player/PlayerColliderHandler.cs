using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliderHandler : MonoBehaviour
{
    public event Action Hit;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Obstacle obstacle))
        {
            Hit?.Invoke();   
        }
    }
}
