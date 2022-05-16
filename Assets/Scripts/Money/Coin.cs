using UnityEngine;
using DG.Tweening;

public class Coin : MonoBehaviour
{
    [SerializeField] private AudioSetting _audioSetting;
    private AudioSource _audioSource;
    private MeshRenderer _mesh;
    private Tweener _tweener;
    private Transform _transform;
    private int _value = 1;
    public int Value => _value;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _mesh = GetComponent<MeshRenderer>();
        _transform = GetComponent<Transform>();
    }

    private void Start()
    {
        _tweener = _transform.DORotate(new Vector3(0,360f,0), 1.5f, RotateMode.FastBeyond360).SetLoops(-1).SetEase(Ease.Linear);
        _audioSource.mute = _audioSetting.IsMute;
    }

    private void OnEnable()
    {
        _audioSetting.Clicked += OnClicked;
    }

    private void OnDisable()
    {
        _tweener.Kill();
        _audioSetting.Clicked -= OnClicked;
    }

    private void OnClicked(bool isMute)
    {
        _audioSource.mute = !isMute;
    }
        
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerMovement player))
        {
            _audioSource.Play();
            _mesh.enabled = false;
        }
    }
}