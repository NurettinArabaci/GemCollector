using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Item collectable))
        {
            SpawnManager.Instance.GetRandomItem(collectable.transform.position, collectable.transform.parent);
            collectable.Collected();
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
