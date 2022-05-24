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

    public Vector3 Velocity => _rigidbody.velocity;
    public bool CanRun => _canRun;
    
    public void Awake()
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

    public void Initialize(Rigidbody rigidbody)
    {
        _rigidbody = rigidbody;
    }
    
    public void OnStarted()
    {
        _canRun = true;
    }

    public void OnHit()
    {
        _canRun = false;
        _rigidbody.velocity = Vector3.zero;
    }

    private void OnFinished()
    {
        _canRun = false;
        _rigidbody.velocity = Vector3.zero;
    }

    public void Move(Vector3 direction)
    {
        if (_canRun == false) return;
        
        float minPositionX = -6.1f;
        float maxPositionX = 6.1f;

        float clampedPositionX = Mathf.Clamp(_rigidbody.position.x, minPositionX, maxPositionX);
        _rigidbody.MovePosition(
            new Vector3(clampedPositionX + direction.x * _strafeSpeed * Time.fixedDeltaTime,0, 
                _rigidbody.position.z + _moveForwardSpeed * Time.fixedDeltaTime));
    }
}