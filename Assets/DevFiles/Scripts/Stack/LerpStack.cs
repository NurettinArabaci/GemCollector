
using System.Collections.Generic;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class LerpStack
{
    private List<GameObject> _collectables;

    public LerpStack(ref List<GameObject> Collectables)
    {
        _collectables = Collectables;
    }

    public void OnLerpStack(MonoBehaviour _monobehaviour)
    {
        if (_collectables.Count < 1) return;


        for (int i = _collectables.Count - 1; i >= 1; i--)
        {

            //_collectables[i].transform.DOMove(_collectables[i - 1].transform.position + Vector3.up, 0.2f);
            _monobehaviour.StartCoroutine(LerpMove(_collectables[i].transform, _collectables[i-1].transform));
        }


    }

    IEnumerator LerpMove(Transform followed,Transform target)
    {
        while (true)
        {
            Vector3 curPos = Vector3.Lerp(followed.position, target.position, 3 * Time.fixedDeltaTime);
            followed.position = curPos;
        }
    }

}
