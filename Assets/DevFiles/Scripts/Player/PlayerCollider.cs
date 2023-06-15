using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Item collectable))
        {
            ItemSpawnManager.Instance.GetRandomItem(collectable.transform.position, collectable.transform.parent);
            collectable.Collected();
            Debug.Log(collectable._itemData.Name);
            
            
        }
    }

}
