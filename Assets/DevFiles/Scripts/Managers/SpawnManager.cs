using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoSingleton<SpawnManager>
{
    [SerializeField] private Item itemPrefab;


    public List<ItemData> itemDatas = new List<ItemData>();

    public Item GetRandomItem(Vector3 pos, Transform _transform)
    {
        Item item = Instantiate(itemPrefab, pos, Quaternion.identity, _transform);
        item._itemData = itemDatas[Random.Range(0, itemDatas.Count)];
        Instantiate(item._itemData.meshRenderer, item.transform);

        return item;
    }

    

}