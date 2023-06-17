using System;
using System.Collections;
using UnityEngine;

public class Item : MonoBehaviour//, ICollectable
{
    #region Properties
    public ItemData _itemData { get; set; }

    public Vector3 Scale
    {
        get => transform.localScale;
        set => transform.localScale = value;
    }

    public int Cost
    {
        get => (int)(_itemData.Cost + Math.Round(transform.localScale.x * 100));
        set => _itemData.Cost = value;
    }

    public int CollectedAmount
    {
        get => PlayerPrefs.GetInt(_itemData.Name, 0);
        set => PlayerPrefs.SetInt(_itemData.Name, value);
    }

    public Collider mCollider
    {
        get => GetComponent<Collider>();
    }
    #endregion

    #region Private Variables
    private bool isCollect = false;
    #endregion

    private void OnEnable()
    {
        StartCoroutine(GrowUpCR());       
    }

    IEnumerator GrowUpCR()
    {
        Scale = Vector3.zero;

        float growUnit = 0;

        while (Scale.x < 1 && !isCollect)
        {
            if(GameManager.Instance.gameState != GameState.Begin)
                growUnit += Time.deltaTime / 5;

            Scale = growUnit * Vector3.one;

            mCollider.enabled = Scale.x >= 0.25f;

            yield return null;
        }

        Scale = Scale.x > 0.99f ? Vector3.one : Scale;
    }

    public void Collected()
    {
        isCollect = true;

        CollectableEvents.Fire_OnCollectableWithStack(this.gameObject);
    }

    

}
