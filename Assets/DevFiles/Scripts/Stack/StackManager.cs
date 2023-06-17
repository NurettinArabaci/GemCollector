using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackManager : MonoBehaviour
{
    public List<GameObject> Collectables = new List<GameObject>();

    #region Private Variables
    private LerpStack _lerpStack;
    private StackCommand _stackCommand;

    #endregion

    private void Awake()
    {
        _stackCommand = new StackCommand(new StackParameters(ref Collectables, transform, this));
        _lerpStack = new LerpStack(ref Collectables);
    }

    #region Event Subscription
    private void OnEnable()
    {
        SubscribeEvents();
    }
    private void SubscribeEvents()
    {
        CollectableEvents.OnCollectableWithStack += _stackCommand.OnStackItem;
        CollectableEvents.OnSaleCollectable += _stackCommand.OnRemoveStack;
        CollectableEvents.OnMovementLerp += _lerpStack.OnLerpStack;
   
    }
    private void UnsubscribeEvents()
    {
        CollectableEvents.OnCollectableWithStack -= _stackCommand.OnStackItem;
        CollectableEvents.OnSaleCollectable -= _stackCommand.OnRemoveStack;
        CollectableEvents.OnMovementLerp -= _lerpStack.OnLerpStack;
    }
    private void OnDisable()
    {
        UnsubscribeEvents();
    }
    #endregion
}
