using UnityEngine;
public interface ICollectible
{
    public int Cost { get;}

    void Collected(Transform transform);
}
