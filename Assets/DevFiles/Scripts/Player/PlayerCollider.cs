using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ICollectable collectible))
        {
            collectible.Collected();
        }
    }

    void StackItem()
    {

    }
}
