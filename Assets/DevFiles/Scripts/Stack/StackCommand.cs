using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class StackCommand
{
    private StackParameters _param;

    public StackCommand(StackParameters param)
    {
        _param = param;
    }

    public void OnStackItem(GameObject gO)
    {
        Transform mT = gO.transform;

        mT.SetParent(_param._transform);

        if (_param._collectables.Count < 1)
        {

            mT.DOJump(_param._transform.position + Vector3.up, 1, 1, 0.1f).OnComplete(() => mT.localPosition = Vector3.up);

            _param._collectables.Add(gO);

            return;
        }

        mT.DOJump(_param._collectables[_param._collectables.Count - 1].transform.position + Vector3.up, 1, 1, 0.25f).SetUpdate(UpdateType.Late);

        _param._collectables.Add(gO);

    }

    public void OnRemoveStack()
    {
        if (_param._collectables.Count <= 0) return;

        var obj = _param._collectables[_param._collectables.Count - 1].gameObject;

        obj.GetComponent<Item>().SoldItem();

        _param._collectables.Remove(obj);
        MonoBehaviour.Destroy(obj);
        DOTween.Kill(obj.transform);


    }

}