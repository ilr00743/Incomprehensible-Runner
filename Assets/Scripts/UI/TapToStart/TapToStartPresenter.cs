using System;
using UnityEngine;
using UnityEngine.UI;

namespace Runner.UI.TapToStart
{
    public class TapToStartPresenter : MonoBehaviour
    {
        [SerializeField] private TapToStartView _tapToStartView;
        [SerializeField] private Button _settingButton, _shopButton;
        [SerializeField] private LevelIndex _levelIndex;

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
            _levelIndex.gameObject.SetActive(true);
            Started?.Invoke();
        }
    }
}
