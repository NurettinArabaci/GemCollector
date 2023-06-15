using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalesArea : MonoBehaviour
{
    float saleTime = 0;

    public void SaleItem()
    {
        if (saleTime < 0.1f)
        {
            saleTime += Time.deltaTime;

            return;
        }
        CollectableEvents.Fire_OnRemoveCollectable();
        saleTime = 0;
    }

    
}
