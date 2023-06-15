using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, ICollectable
{  
    public int Cost { get; set; }

    public ItemData _itemData { get; set; }


    private Collider _collider;
    private bool isCollect = false;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
    }

    private void OnEnable()
    {
        StartCoroutine(GrowUpCR());
        
    }

    IEnumerator GrowUpCR()
    {
        transform.localScale = Vector3.zero;

        float growUnit = 0;

        while (transform.localScale.x < 1 && !isCollect)
        {
            growUnit += Time.deltaTime / 5;
            transform.localScale = growUnit * Vector3.one;

            _collider.enabled = transform.localScale.x >= 0.25f;

            yield return null;
        }
        transform.localScale = transform.localScale.x > 0.99f ? Vector3.one : transform.localScale;
    }

    public void Collected()
    {
        this.isCollect = true;
        CollectableEvents.Fire_OnCollectableWithStack(this.gameObject);
    }

    
}
