using UnityEngine.EventSystems;

public class JoystickController : FloatingJoystick
{
    public override void OnPointerDown(PointerEventData eventData)
    {
        PlayerEvents.Fire_OnMoveControl(MoveState.Move);

        base.OnPointerDown(eventData);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        PlayerEvents.Fire_OnMoveControl(MoveState.Stop);

        base.OnPointerUp(eventData);
    }

}