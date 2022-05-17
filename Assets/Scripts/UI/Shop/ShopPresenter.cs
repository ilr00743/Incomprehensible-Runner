using UnityEngine;
using UnityEngine.UI;

namespace Runner.UI.Shop
{
    public class ShopPresenter : MonoBehaviour
    {
        [SerializeField] private ShopView _shopView;
        [SerializeField] private GameObject _tapToStart;
        [SerializeField] private Button _openShopButton;

        private void OnEnable()
        {
            _openShopButton.onClick.AddListener(OnOpenShopButtonClicked);
            _shopView.CloseButtonClicked += OnCloseButtonClicked;
        }

        private void OnDisable()
        {
            _openShopButton.onClick.RemoveListener(OnOpenShopButtonClicked);
            _shopView.CloseButtonClicked -= OnCloseButtonClicked;
        }

        private void OnCloseButtonClicked()
        {
            _shopView.gameObject.SetActive(false);
            _tapToStart.SetActive(true);
        }

        private void OnOpenShopButtonClicked()
        {
            _shopView.gameObject.SetActive(true);
            _tapToStart.SetActive(false);
        }
    }
}
