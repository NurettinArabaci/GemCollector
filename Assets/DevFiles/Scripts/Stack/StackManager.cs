using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackManager : MonoBehaviour
{
    public List<GameObject> Collectables = new List<GameObject>();

    #region Private Variables
    private LerpStackCommand _lerpStackCommand;
    private AddStackCommand _addStackCommand;

    #endregion

    private void Awake()
    {
        _addStackCommand = new AddStackCommand(new AddStackKeyParams(ref Collectables, transform, this));
        _lerpStackCommand = new LerpStackCommand(ref Collectables);
    }

    #region Event Subscription
    private void OnEnable()
    {
        SubscribeEvents();
    }
    private void SubscribeEvents()
    {
        CollectableEvents.OnCollectableWithStack += _addStackCommand.OnAddOnStack;
        CollectableEvents.OnRemoveCollectable += _addStackCommand.OnRemoveOnStack;
        CollectableEvents.OnMovementLerp += _lerpStackCommand.OnLerpTheStack;
   
    }
    private void UnsubscribeEvents()
    {
        CollectableEvents.OnCollectableWithStack -= _addStackCommand.OnAddOnStack;
        CollectableEvents.OnRemoveCollectable -= _addStackCommand.OnRemoveOnStack;
        CollectableEvents.OnMovementLerp -= _lerpStackCommand.OnLerpTheStack;
    }
    private void OnDisable()
    {
        UnsubscribeEvents();
    }
    #endregion
}
