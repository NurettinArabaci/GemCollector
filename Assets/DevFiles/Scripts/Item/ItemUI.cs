using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ItemUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _gemType,_gemAmount;
    [SerializeField] private Image _itemIcon;

    public string GemName { get; set; }

    public void SetGemInfo(ItemData itemData)
    {
        GemName = itemData.Name;
        _gemType.SetText(GemName);
        _gemAmount.SetText(PlayerPrefs.GetInt(GemName).ToString());
        _itemIcon.sprite = itemData.Icon;
    }

    private void OnEnable()
    {
        UIEvents.OnUpdateItemAmount += UpdateItemAmount;
    }

    private void UpdateItemAmount()
    {
        _gemAmount.SetText(PlayerPrefs.GetInt(GemName).ToString());
        //_gemAmount.SetText(PlayerPrefs.GetInt(itemData.Name).ToString());
    }

    private void OnDisable()
    {
        UIEvents.OnUpdateItemAmount -= UpdateItemAmount;
    }
}