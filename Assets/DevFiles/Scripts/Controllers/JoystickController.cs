using UnityEngine.EventSystems;

public class JoystickController : FloatingJoystick
{
    public override void OnPointerDown(PointerEventData eventData)
    {
        EventManager.Fire_onMoveControl(MoveState.Move);

        base.OnPointerDown(eventData);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        EventManager.Fire_onMoveControl(MoveState.Stop);

        base.OnPointerUp(eventData);
    }

}