using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class AddStackCommand
{
    private AddStackKeyParams _param;

    public AddStackCommand(AddStackKeyParams param)
    {
        _param = param;
    }

    public void OnAddOnStack(GameObject gO)
    {
        Transform mT = gO.transform;

        mT.SetParent(_param._transform);

        if (_param._collectables.Count < 1)
        {

            mT.DOJump(_param._transform.position + Vector3.up, 1, 1, 0.1f).OnComplete(() => mT.localPosition = Vector3.up);
            
            _param._collectables.Add(gO);

            return;
        }

        mT.DOJump(_param._collectables[_param._collectables.Count - 1].transform.position + Vector3.up, 1, 1, 0.2f);
        

        _param._collectables.Add(gO);

    }

}
