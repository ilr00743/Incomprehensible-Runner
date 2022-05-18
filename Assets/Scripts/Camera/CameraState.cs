using Runner.Finish;
using Runner.UI.TapToStart;
using UnityEngine;

namespace Runner.Camera
{
    public class CameraState : MonoBehaviour
    {
        [SerializeField] private TapToStartPresenter _tapToStart;
        [SerializeField] private FinishLine _finishLine;
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            _tapToStart.Started += OnStarted;
            _finishLine.Finished += OnFinished;
        }

        private void OnDisable()
        {
            _tapToStart.Started -= OnStarted;
            _finishLine.Finished -= OnFinished;
        }

        private void OnStarted()
        {
            _animator.SetTrigger(AnimationParams.Run);
        }

        private void OnFinished()
        {
            _animator.SetTrigger(AnimationParams.Finish);
        }

        private static class AnimationParams
        {
            public static readonly string Idle = nameof(Idle);
            public static readonly string Run = nameof(Run);
            public static readonly string Finish = nameof(Finish);
        }
    }
}
