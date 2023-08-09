using System;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class Money : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _moneyText;

    [SerializeField] Transform target;

    const string MONEY = "Money";

    public int MoneyAmount
    {
        get => PlayerPrefs.GetInt(MONEY, 0);
        set => PlayerPrefs.SetInt(MONEY, value);
    }

    private void Awake()
    {
        _moneyText.SetText(MoneyText());
    }

    private void OnEnable()
    {
        UIEvents.OnUpdateMoney += UpdateMoney;
    }

    private void UpdateMoney(int _money)
    {
        transform.DOScale(1.1f, 0.1f).OnComplete(()=> transform.DOScale(1f, 0.1f));
        MoneyAmount += _money;
        _moneyText.SetText(MoneyText());

        SpawnManager.Instance.MoneyEarnVfx().SetMoneyAmount(_money, target);

    }

    string MoneyText()
    {
        if (MoneyAmount > 999 && MoneyAmount < 1000000)
        {
            return $"{String.Format("{0:0.00}", Math.Round((float)MoneyAmount / 1000, 2))}K $";
        }
        else if (MoneyAmount >=1000000  && MoneyAmount < 1000000000)
        {
            return $"{String.Format("{0:0.00}", Math.Round((float)MoneyAmount / 1000000, 2))}M $";
        }
            
        return MoneyAmount.ToString() + " $";
    }

    private void OnDisable()
    {
        UIEvents.OnUpdateMoney -= UpdateMoney;
    }
}