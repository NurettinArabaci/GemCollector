using System;
using System.Collections;
using UnityEngine;

public enum MoveType { Move, Stop }

public class PlayerEvents
{
    public static event Action<MoveType> OnMove;
    public static void Fire_OnMove(MoveType moveType) { OnMove?.Invoke(moveType); }

}

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;

    MoveType moveType;

    [SerializeField] private JoystickController joystick;
    [SerializeField] private int speed = 1;
    [SerializeField] private Animator anim;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();

        PlayerEvents.OnMove += Move;

    }

    private void OnDisable()
    {
        PlayerEvents.OnMove -= Move;
    }

    private void Move(MoveType type)
    {
        moveType = type;
        StartCoroutine(MoveCR());
    }

    
    private void FixedUpdate()
    {
        if (GameManager.Instance.gameState != GameState.Play) return;

        _rb.velocity = DirectionPose() * speed;
        transform.rotation = RotationPose();
        anim.SetFloat("MoveParam", _rb.velocity.magnitude / speed);
        CollectableEvents.Fire_OnMovementLerp();
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

    IEnumerator MoveCR()
    {
        while (moveType == MoveType.Move)
        {
            _rb.velocity = DirectionPose() * speed;
            transform.rotation = RotationPose();
            anim.SetFloat("MoveParam", _rb.velocity.magnitude / speed);
            CollectableEvents.Fire_OnMovementLerp();

            yield return null;
        }

        _rb.velocity = Vector3.zero;
        anim.SetFloat("MoveParam", 0);
    }

}