using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Item item))
        {
            SpawnManager.Instance.GetRandomItem(item.transform.position, item.transform.parent);
            item.Collected();
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out SalesArea area))
        {
            area.SaleItem();
        }
    }

    

}
