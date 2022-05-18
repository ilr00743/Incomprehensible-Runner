using UnityEngine;
using UnityEngine.UI;

public class SettingsPresenter : MonoBehaviour
{
    [SerializeField] private SettingsView _settingsView;
    [SerializeField] private GameObject _tapToStart;
    [SerializeField] private Button _settingsButton;

    private void OnEnable()
    {
        _settingsButton.onClick.AddListener(OnOpenSettingsButtonClicked);
        _settingsView.CloseButtonClicked += OnCloseButtonClicked;
    }

    private void OnDisable()
    {
        _settingsButton.onClick.RemoveListener(OnOpenSettingsButtonClicked);
        _settingsView.CloseButtonClicked -= OnCloseButtonClicked;
    }

    private void OnCloseButtonClicked()
    {
        _settingsView.gameObject.SetActive(false);
        _tapToStart.SetActive(true);
    }

    private void OnOpenSettingsButtonClicked()
    {
        _settingsView.gameObject.SetActive(true);
        _tapToStart.SetActive(false);
    }
}