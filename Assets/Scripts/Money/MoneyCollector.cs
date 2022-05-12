using System;
using System.Collections;
using System.Collections.Generic;
using Money;
using UnityEngine;

public class MoneyCollector : MonoBehaviour
{
    private MoneyHolder _playerMoney;
    private int _value = 1;
    private int _collectedCoin;

    public int CollectedCoin => _collectedCoin;

    private void Awake()
    {
        _playerMoney = GetComponent<MoneyHolder>();
    }

    private void Start()
    {
        _collectedCoin = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Coin coin))
        {
            _playerMoney.AddMoney(_value);
            _collectedCoin++;
        }
    }
}
