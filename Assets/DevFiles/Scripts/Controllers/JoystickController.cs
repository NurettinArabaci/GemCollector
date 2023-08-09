using UnityEngine.EventSystems;

public class JoystickController : FloatingJoystick
{
    public override void OnPointerDown(PointerEventData eventData)
    {
        if (GameManager.Instance.gameState == GameState.Begin)
        {
            GameStateEvent.Fire_OnChangeGameState(GameState.Play);
        }

        //PlayerEvents.Fire_OnMove(MoveType.Move);
        base.OnPointerDown(eventData);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        //PlayerEvents.Fire_OnMove(MoveType.Stop);
        base.OnPointerUp(eventData);
    }

}