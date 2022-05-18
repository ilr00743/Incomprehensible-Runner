using System;
using UnityEngine;

namespace Runner.Money
{
    public class MoneyHolder : MonoBehaviour
    {
        private int _balance;
        public int Balance => _balance;

        public event Action BalanceChanged;

        private void Start()
        {
            _balance = GetBalance();
        }

        public void AddMoney(int value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            _balance += value;
            SaveBalance();
            BalanceChanged?.Invoke();
        }

        public void SpendMoney(int value)
        {
            if (value <= 0 || _balance <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            _balance -= value;
            SaveBalance();
            BalanceChanged?.Invoke();
        }

        private void SaveBalance()
        {
            PlayerPrefs.SetInt("MoneyBalance", _balance);
        }

        public int GetBalance()
        {
            return PlayerPrefs.GetInt("MoneyBalance");
        }
    }
}