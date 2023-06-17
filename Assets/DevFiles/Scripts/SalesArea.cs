using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class SalesArea : MonoBehaviour
{
    float saleTime = 0;

    private void Awake()
    {
        GetComponent<Collider>().isTrigger = true;
    }

    public void SaleItem()
    {
        if (saleTime < 0.1f)
        {
            saleTime += Time.deltaTime;

            return;
        }
        CollectableEvents.Fire_OnSaleCollectable();
        saleTime = 0;
    }
}