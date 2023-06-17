using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUISpawner : MonoBehaviour
{
    [SerializeField] private ItemUI _itemUIPrefab;

    private void SpawnItemUI()
    {
        for (int i = 0; i < SpawnManager.Instance.itemDatas.Count; i++)
        {
            ItemUI _itemUI=Instantiate(_itemUIPrefab, transform);
            _itemUI.SetGemInfo(SpawnManager.Instance.itemDatas[i]);
        }
        
    }

    private void Start()
    {
        SpawnItemUI();
    }
}
