
using System.Collections.Generic;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class LerpStack
{
    private List<GameObject> _collectables;

    public LerpStack(ref List<GameObject> Collectables)
    {
        _collectables = Collectables;
    }

    public void OnLerpStack()
    {
        if (_collectables.Count < 1) return;

        for (int i = _collectables.Count - 1; i >= 1; i--)
        {
            _collectables[i].transform.DOMove(_collectables[i - 1].transform.position + Vector3.up, 0.1f);

        }


    }

}
