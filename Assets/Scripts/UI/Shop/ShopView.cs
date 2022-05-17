using System;
using UnityEngine;
using UnityEngine.UI;

namespace Runner.UI.Shop
{
    public class ShopView : MonoBehaviour
    {
        [SerializeField] private Button _closeButton;

        public event Action CloseButtonClicked;

        private void OnEnable()
        {
            _closeButton.onClick.AddListener(OnCloseButtonClicked);
        }

        private void OnDisable()
        {
            _closeButton.onClick.RemoveListener(OnCloseButtonClicked);
        }

        private void OnCloseButtonClicked()
        {
            CloseButtonClicked?.Invoke();
        }
    }
}
