using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndLevelView : MonoBehaviour
{
    [SerializeField] private Button _multiplyButton;
    [SerializeField] private Button _skipButton;
    [SerializeField] private MoneyCollector _moneyCollector;
    [SerializeField] private TMP_Text _collectedCoin;

    public event Action MultiplyButtonClicked;
    public event Action SkipButtonClicked;

    private void Start()
    {
        if (HasNotInternetConnection())
        {
            _multiplyButton.interactable = false;
        }
    }

    private static bool HasNotInternetConnection()
    {
        return Application.internetReachability == NetworkReachability.NotReachable;
    }

    public void OnEnable()
    {
        _collectedCoin.SetText(_moneyCollector.CollectedCoin.ToString());
        _multiplyButton.onClick.AddListener(OnMultiplyButtonClicked);
        _skipButton.onClick.AddListener(OnSkipButtonClicked);
    }

    private void OnDisable()
    {
        _multiplyButton.onClick.RemoveListener(OnMultiplyButtonClicked);
        _skipButton.onClick.RemoveListener(OnSkipButtonClicked);
    }

    private void OnMultiplyButtonClicked()
    {
        if (_moneyCollector.CollectedCoin == 0)
        {
            _collectedCoin.SetText("No :)");
        }
        else
        {
            _collectedCoin.SetText((_moneyCollector.CollectedCoin * 2).ToString());
            _multiplyButton.interactable = false;   
        }
        MultiplyButtonClicked?.Invoke();
    }
    
    private void OnSkipButtonClicked()
    {
        SkipButtonClicked?.Invoke();
    }
}
