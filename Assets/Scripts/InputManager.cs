using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.OnFootActions OnFoot;
    private PlayerMotor motor;
    private PlayerLook look;
    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();
        OnFoot = playerInput.OnFoot;      
        look=GetComponent<PlayerLook>();
        motor = GetComponent<PlayerMotor>();
        OnFoot.Jump.performed += ctx => motor.Jump();
    }
    private void LateUpdate()
    {
        look.ProcessLook(OnFoot.Look.ReadValue<Vector2>());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        motor.ProcessMove(OnFoot.Movement.ReadValue<Vector2>());
    }
    private void OnEnable()
    {
        OnFoot.Enable();
    }
    private void OnDisable()
    {
        OnFoot.Disable();
    }
}
