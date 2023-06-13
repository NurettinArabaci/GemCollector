using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    [SerializeField] private Transform stackTransform;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ICollectible collectible))
        {
            collectible.Collected(stackTransform);
        }
    }

    void StackItem()
    {

    }
}
