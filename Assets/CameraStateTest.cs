using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CameraStateTest : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Animator _animator;
    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _image.raycastTarget = false;
        _animator.ResetTrigger("Idle");
        _animator.SetTrigger("Run");
    }
}
