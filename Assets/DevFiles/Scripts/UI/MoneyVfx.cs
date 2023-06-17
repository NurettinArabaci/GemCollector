using UnityEngine;
using TMPro;
using DG.Tweening;

public class MoneyVfx : MonoBehaviour
{
    TextMeshProUGUI _moneyText => GetComponent<TextMeshProUGUI>();
    RectTransform mRT;

    private void Awake()
    {
        mRT = GetComponent<RectTransform>();
    }

    public void SetMoneyAmount(int _money, Transform target)
    {
        _moneyText.SetText($"+{_money} $");

        mRT.DOMove(target.position, 1f).OnComplete(()=>Destroy(gameObject));
    }


}
