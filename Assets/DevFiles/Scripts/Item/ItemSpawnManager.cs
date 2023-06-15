using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnManager : MonoBehaviour
{
    [SerializeField] private Item itemPrefab;

    

    public static ItemSpawnManager Instance;

    public List<ItemData> itemData = new List<ItemData>();

    private void Awake()
    {
        Instance = this;
    }

    public Item GetRandomItem(Vector3 pos, Transform _transform)
    {
        

        Item item= Instantiate(itemPrefab, pos, Quaternion.identity, _transform);
        item._itemData = itemData[Random.Range(0, itemData.Count)];
        Instantiate(item._itemData.meshRenderer, item.transform);

        return item;
    }

    

}

[System.Serializable]
public class ItemData
{
    public string Name;
    public Sprite Icon;
    public MeshRenderer meshRenderer;
}
