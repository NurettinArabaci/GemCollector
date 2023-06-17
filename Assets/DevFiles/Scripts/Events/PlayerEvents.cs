public class PlayerEvents
{
    public static System.Action<MoveState> OnMoveControl;
    public static void Fire_OnMoveControl(MoveState state) { OnMoveControl?.Invoke(state); }
}
