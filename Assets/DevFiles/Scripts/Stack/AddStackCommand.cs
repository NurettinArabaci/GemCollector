using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class AddStackCommand
{
    private AddStackKeyParams _params;

    public AddStackCommand(AddStackKeyParams param)
    {
        _params = param;
    }

    public void OnAddOnStack(GameObject gO)
    {
        Transform mT = gO.transform;

        mT.SetParent(_params._transform);

        if (_params._collectables.Count < 1)
        {

            mT.DOJump(_params._transform.position + Vector3.up, 1, 1, 0.1f).OnComplete(() => mT.localPosition = Vector3.up);
            
            _params._collectables.Add(gO);

            return;
        }

        mT.DOJump(_params._collectables[_params._collectables.Count - 1].transform.position + Vector3.up, 1, 1, 0.2f);
        

        _params._collectables.Add(gO);

        OnShakeStack();


    }

    public void OnShakeStack()
    {
        _params._monoBehaviour.StartCoroutine(_params._shakeStackCommand.HandleShakeOfStack());
    }
}
