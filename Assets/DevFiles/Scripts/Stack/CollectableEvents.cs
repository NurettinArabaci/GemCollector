using UnityEngine;

public static class CollectableEvents
{
    public static event System.Action<GameObject> OnCollectableWithStack;
    public static void Fire_OnCollectableWithStack(GameObject go) { OnCollectableWithStack?.Invoke(go); }

    public static event System.Action OnMovementLerp;
    public static void Fire_OnMovementLerp() { OnMovementLerp?.Invoke(); }

    public static event System.Action OnShakeOnStack;
    public static void Fire_OnShakeOnStack() { OnShakeOnStack?.Invoke(); }
}
