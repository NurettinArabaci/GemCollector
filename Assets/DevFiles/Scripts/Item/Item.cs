using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, ICollectible
{
    public int Cost { get;}

    public void Collected(Transform _transform)
    {
        //TODO: collected
        //transform.parent = _transform;

        CollectableEvents.Fire_OnCollectableWithStack(this.gameObject);
    }

    
}
