using System;
using System.Collections;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] _particles;
    [SerializeField] private AudioSetting _audioSetting;
    private AudioSource _audioSource;

    public event Action Finished;

    private void OnEnable()
    {
        _audioSetting.Clicked += OnClicked;
    }

    private void OnDisable()
    {
        _audioSetting.Clicked -= OnClicked;
    }

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _audioSource.mute = _audioSetting.IsMute;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerMovement player))
        {
            StartCoroutine(FinishAfterSeconds());
        }
    }

    private void OnClicked(bool isMuted)
    {
        _audioSource.mute = !isMuted;
    }

    private IEnumerator FinishAfterSeconds()
    {
        yield return new WaitForSeconds(1f);
        
        int i;
        for (i = 0; i < _particles.Length; i++)
        {
            _particles[i].Play();
        }
        _audioSource.Play();
        Finished?.Invoke();
    }
}
