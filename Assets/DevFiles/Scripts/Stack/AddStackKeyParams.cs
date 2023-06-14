using System;
using System.Collections.Generic;
using UnityEngine;

public class AddStackKeyParams
{
    public List<GameObject> _collectables;
    public Transform _transform;
    public MonoBehaviour _monoBehaviour;


    public AddStackKeyParams(ref List<GameObject> collectables, Transform transform, MonoBehaviour monoBehaviour)
    {
        _collectables = collectables;
        _transform = transform;
        _monoBehaviour = monoBehaviour;
    }

}
