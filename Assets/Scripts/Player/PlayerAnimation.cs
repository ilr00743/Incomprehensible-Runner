using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private TapToStartPresenter _tapToStart;
    [SerializeField] private FinishLine _finishLine;
    private Animator _animator;
    private PlayerColliderHandler _playerCollider;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _playerCollider = GetComponent<PlayerColliderHandler>();
    }

    private void OnEnable()
    {
        _tapToStart.Started += OnStarted;
        _finishLine.Finished += OnFinished;
        _playerCollider.Hit += OnHit;
    }

    private void OnDisable()
    {
        _tapToStart.Started -= OnStarted;
        _finishLine.Finished -= OnFinished;
        _playerCollider.Hit -= OnHit;
    }

    private void OnHit()
    {
        _animator.SetTrigger(AnimationParams.Death);
    }

    private void OnStarted()
    {
        _animator.SetTrigger(AnimationParams.Run);
    }

    public void OnFinished()
    {
        _animator.SetTrigger(AnimationParams.Dance);
        
    }
    
    private static class AnimationParams
    {
        public static readonly string Idle = nameof(Idle);
        public static readonly string Run = nameof(Run);
        public static readonly string Dance = nameof(Dance);
        public static readonly string Death = nameof(Death);
    }
}
