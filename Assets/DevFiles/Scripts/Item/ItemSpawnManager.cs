using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnManager : MonoBehaviour
{
    public static ItemSpawnManager Instance;

    public List<Item.ItemData> ItemData = new List<Item.ItemData>();

    private void Awake()
    {
        Instance = this;
    }

    public void GetItem()
    {

    }

}
