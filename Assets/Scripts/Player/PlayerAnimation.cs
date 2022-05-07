using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private TapToStartPresenter _tapToStart;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

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
        _animator.SetTrigger(AnimationParams.Run);
    }

    private static class AnimationParams
    {
        public static readonly string Idle = nameof(Idle);
        public static readonly string Run = nameof(Run);
        public static readonly string Dance = nameof(Dance);
        public static readonly string Death = nameof(Death);
    }
}
