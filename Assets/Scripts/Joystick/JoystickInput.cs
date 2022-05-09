using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickInput : MonoBehaviour
{
    [SerializeField] private PlayerMovement _movement;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private FinishLine _finishLine;
    [SerializeField] private Obstacle[] _obstacles;

    private void OnEnable()
    {
        _finishLine.Finished += OnFinished;
        
        foreach (var obstacle in _obstacles)
        {
            obstacle.Hit += OnHit;
        }
    }

    private void OnDisable()
    {
        _finishLine.Finished -= OnFinished;
        
        foreach (var obstacle in _obstacles)
        {
            obstacle.Hit -= OnHit;
        }
    }

    private void OnHit()
    {
        _joystick.gameObject.SetActive(false);
    }

    private void Awake()
    {
        Input.multiTouchEnabled = false;
    }

    private void FixedUpdate()
    {
        Vector3 rawDirection = new Vector3(_joystick.Direction.x, 0);
        
        _movement.Move(rawDirection);
    }

    private void OnFinished()
    {
        _joystick.gameObject.SetActive(false);
    }
}
