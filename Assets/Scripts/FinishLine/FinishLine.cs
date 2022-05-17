using System;
using System.Collections;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] _particles;
    [SerializeField] private AudioSetting _audioSetting;
    [SerializeField] private AudioSource _confettiSound;
    [SerializeField] private AudioSource _music;

    public event Action Finished;

    private void OnEnable()
    {
        _audioSetting.Clicked += OnClicked;
    }

    private void OnDisable()
    {
        _audioSetting.Clicked -= OnClicked;
    }

    private void Start()
    {
        _confettiSound.mute = _audioSetting.IsMute;
        _music.mute = _audioSetting.IsMute;
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
        _music.mute = !isMuted;
        _confettiSound.mute = !isMuted;
    }

    private IEnumerator FinishAfterSeconds()
    {
        yield return new WaitForSeconds(1f);
        
        int i;
        for (i = 0; i < _particles.Length; i++)
        {
            _particles[i].Play();
        }
        _confettiSound.Play();
        _music.Play();
        Finished?.Invoke();
    }
}
