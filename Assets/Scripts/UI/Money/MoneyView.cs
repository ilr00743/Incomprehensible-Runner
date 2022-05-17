using Runner.Money;
using TMPro;
using UnityEngine;

namespace Runner.UI.Money
{
    public class MoneyView : MonoBehaviour
    {
        [SerializeField] private MoneyHolder _playerMoney;
        [SerializeField] private TMP_Text _text;
    
        private void OnEnable()
        {
            _text.text =_playerMoney.GetBalance().ToString();
            _playerMoney.BalanceChanged += OnBalanceChanged;
        }

        private void OnDisable()
        {
            _playerMoney.BalanceChanged -= OnBalanceChanged;
        }

        private void OnBalanceChanged()
        {
            _text.text = _playerMoney.Balance.ToString();
        }
    }
}
