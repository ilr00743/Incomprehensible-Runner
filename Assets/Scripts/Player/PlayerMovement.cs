using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private TapToStartPresenter _tapToStart;
    private Rigidbody _rigidbody;

    private void OnEnable()
    {
        _tapToStart.Started += OnStarted;
    }

    private void OnDisable()
    {
        _tapToStart.Started -= OnStarted;
    }

    private void OnStarted()
    {
        
    }
}
