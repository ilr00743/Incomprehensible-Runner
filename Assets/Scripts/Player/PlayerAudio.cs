using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [SerializeField] private AudioSetting _audioSetting;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _audioSource.mute = _audioSetting.IsMute;
    }

    private void OnEnable()
    {
        _audioSetting.Clicked += OnClicked;
    }

    private void OnDisable()
    {
        _audioSetting.Clicked -= OnClicked;
    }

    private void OnClicked(bool isMute)
    {
        _audioSource.mute = !isMute;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.TryGetComponent(out Obstacle obstacle))
        {
            _audioSource.Play();
        }
    }
}
