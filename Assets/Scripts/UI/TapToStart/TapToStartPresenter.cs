using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapToStartPresenter : MonoBehaviour
{
    [SerializeField] private TapToStartView _tapToStartView;
    [SerializeField] private Button _settingButton, _shopButton;

    public event Action Started;
    
    private void OnEnable()
    {
        _tapToStartView.Clicked += OnClicked;
    }

    private void OnDisable()
    {
        _tapToStartView.Clicked -= OnClicked;
    }

    private void OnClicked()
    {
        _tapToStartView.gameObject.SetActive(false);
        _settingButton.gameObject.SetActive(false);
        _shopButton.gameObject.SetActive(false);
        Started?.Invoke();
    }
}
