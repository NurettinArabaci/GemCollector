using System.Collections;
using UnityEngine;

public enum MoveState { Move, Stop }

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;

    [SerializeField] private JoystickController joystick;
    [SerializeField] private int speed = 1;
    [SerializeField] private Animator anim;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();

        PlayerEvents.OnMoveControl += MoveControl;

    }

    void MoveControl(MoveState state)
    {
        StartCoroutine(MoveCR(state));

        if (GameManager.Instance.gameState == GameState.Begin)
        {
            GameStateEvent.Fire_OnChangeGameState(GameState.Play);
        }

            
    }


    IEnumerator MoveCR(MoveState state)
    {
        

        while (state == MoveState.Move)
        {
            
            _rb.velocity = DirectionPose() * speed;
            transform.rotation = RotationPose();
            anim.SetFloat("MoveParam", _rb.velocity.magnitude / speed);

            CollectableEvents.Fire_OnMovementLerp(this);
            yield return null;
        }

        _rb.velocity = Vector3.zero;
        anim.SetFloat("MoveParam", 0);

    }

    Vector3 DirectionPose()
    {
        
        return Vector3.forward * joystick.Vertical + Vector3.right * joystick.Horizontal; ;
    }

    Quaternion RotationPose()
    {
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
            return Quaternion.LookRotation(_rb.velocity);

        return transform.rotation;
    }

    private void OnDisable()
    {
        PlayerEvents.OnMoveControl -= MoveControl;
    }
}