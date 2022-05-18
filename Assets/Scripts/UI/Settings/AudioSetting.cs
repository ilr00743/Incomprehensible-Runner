using System;
using UnityEngine;
using UnityEngine.UI;

namespace Runner.UI.Settings
{
    public class AudioSetting : MonoBehaviour
    {
        [SerializeField] private Sprite _soundOn;
        [SerializeField] private Sprite _soundOff;
        [SerializeField] private Image _image;
        [SerializeField] private Button _muteButton;
        private bool _isMute;
        public bool IsMute => _isMute;
        public event Action<bool> Clicked;

        private void OnEnable()
        {
            _image.sprite = _soundOn;
            _isMute = true;
            _muteButton.onClick.AddListener(OnButtonClicked);
        }

        private void OnDisable()
        {
            _muteButton.onClick.RemoveListener(OnButtonClicked);
        }

        private void OnButtonClicked()
        {
            ToggleMute();
            Clicked?.Invoke(_isMute);
        }

        private void ToggleMute()
        {
            _image.sprite = _isMute == false ? _soundOn : _soundOff;
            _isMute = !_isMute;
        }
    }
}
