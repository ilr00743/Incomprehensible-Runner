using Runner.Player;
using UnityEngine;

namespace Runner.Input
{
    public class JoystickInput : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _movement;
        [SerializeField] private Joystick _joystick;
        [SerializeField] private FinishLine.FinishLine _finishLine;
        [SerializeField] private PlayerColliderHandler _playerCollider;

        private void OnEnable()
        {
            _finishLine.Finished += OnFinished;
            _playerCollider.Hit += OnHit;
        }

        private void OnDisable()
        {
            _finishLine.Finished -= OnFinished;
            _playerCollider.Hit -= OnHit;
        }

        private void OnHit()
        {
            _joystick.gameObject.SetActive(false);
        }

        private void Awake()
        {
            UnityEngine.Input.multiTouchEnabled = false;
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
}
