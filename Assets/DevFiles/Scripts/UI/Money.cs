using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class Money : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _moneyText;

    const string MONEY = "Money";

    public int MoneyAmount
    {
        get => PlayerPrefs.GetInt(MONEY, 0);
        set => PlayerPrefs.SetInt(MONEY, value);
    }

    private void Awake()
    {
        UpdateMoney(0);
    }

    private void OnEnable()
    {
        UIEvents.OnUpdateMoney += UpdateMoney;
    }

    private void UpdateMoney(int _money)
    {
        transform.DOScale(1.1f, 0.1f).OnComplete(()=> transform.DOScale(1f, 0.1f));
        MoneyAmount += _money;
        _moneyText.SetText(MoneyAmount.ToString());
    }

    private void OnDisable()
    {
        UIEvents.OnUpdateMoney -= UpdateMoney;
    }
}