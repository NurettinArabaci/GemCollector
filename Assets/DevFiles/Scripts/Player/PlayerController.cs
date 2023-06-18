using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;

    [SerializeField] private JoystickController joystick;
    [SerializeField] private int speed = 1;
    [SerializeField] private Animator anim;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();

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

}