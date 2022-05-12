using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private TapToStartPresenter _tapToStart;
    [SerializeField] private FinishLine _finishLine; 
    [SerializeField] private float _moveForwardSpeed;
    [SerializeField] private float _strafeSpeed;
    private Rigidbody _rigidbody;
    private PlayerColliderHandler _collider;
    private bool _canRun;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<PlayerColliderHandler>();
    }

    private void Start()
    {
        _canRun = false;
    }

    private void OnEnable()
    {
        _tapToStart.Started += OnStarted;
        _finishLine.Finished += OnFinished;
        _collider.Hit += OnHit;
    }

    private void OnDisable()
    {
        _tapToStart.Started -= OnStarted;
        _finishLine.Finished -= OnFinished;
        _collider.Hit -= OnHit;
    }

    private void OnHit()
    {
        _canRun = false;
        _rigidbody.velocity = Vector3.zero;
    }

    private void OnStarted()
    {
        _canRun = true;
    }

    private void OnFinished()
    {
        _canRun = false;
    }

    public void Move(Vector3 direction)
    {
        if (_canRun == false) return;
        
        _rigidbody.MovePosition(
            new Vector3(_rigidbody.position.x + direction.x * _strafeSpeed * Time.fixedDeltaTime,0, 
                _rigidbody.position.z + _moveForwardSpeed * Time.fixedDeltaTime));
    }
}
