using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackManager : MonoBehaviour
{
    public List<GameObject> Collectables = new List<GameObject>();

    #region Private Variables
    private LerpStackCommand _lerpStackCommand;
    private ShakeStackCommand _shakeStackCommand;
    private AddStackCommand _addStackCommand;

    #endregion

    private void Awake()
    {
        _shakeStackCommand = new ShakeStackCommand(ref Collectables);
        _addStackCommand = new AddStackCommand(new AddStackKeyParams(ref Collectables, transform, this, ref _shakeStackCommand));
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
        CollectableEvents.OnMovementLerp += _lerpStackCommand.OnLerpTheStack;
        CollectableEvents.OnShakeOnStack += _addStackCommand.OnShakeStack;
   
    }
    private void UnsubscribeEvents()
    {
        CollectableEvents.OnCollectableWithStack -= _addStackCommand.OnAddOnStack;
        CollectableEvents.OnMovementLerp -= _lerpStackCommand.OnLerpTheStack;
        CollectableEvents.OnShakeOnStack -= _addStackCommand.OnShakeStack;
    }
    private void OnDisable()
    {
        UnsubscribeEvents();
    }
    #endregion
}
