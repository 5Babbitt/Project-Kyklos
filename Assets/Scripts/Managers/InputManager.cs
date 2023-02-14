using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    //Singleton Instantiation
    private static InputManager instance;
    public static InputManager Instance
    {
        get
        {
            if (instance == null) 
            {
                instance = GameObject.FindObjectOfType<InputManager>();
            }
            return instance;
        }
    }

    //Events
    public static event Action activatePressed;
    public static event Action pausePressed;
    
    [Header("References")]
    public PlayerInputActions controls;
    private InputAction jump;
    private InputAction rotate;
    private InputAction activate;
    private InputAction pause;

    [Header("Properties")]
    public Vector3 movementInput;

    private void OnEnable() 
    {
        
        //Code checks for the device that the system is running on and sets the controls accordingly
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            InputSystem.EnableDevice(Accelerometer.current);
            rotate = controls.Player.MobileMove;
            
            Debug.Log($"[Mobile]System: " + SystemInfo.deviceName);
        }
        else
        {
            rotate = controls.Player.Move;
            
            Debug.Log($"[PC/Console]System: " + SystemInfo.deviceName);
        }

        //Subscription to the controls events
        jump = controls.Player.Jump;
        activate = controls.Player.Activate;
        pause = controls.Player.Pause;

        //Enabling the controls events
        jump.Enable();
        rotate.Enable();
        activate.Enable();
        pause.Enable();

        
        jump.performed += Jump;
        activate.performed += Activate;
        pause.performed += Pause;

    }

    private void OnDisable() 
    {
        if (Accelerometer.current != null)
        {
            InputSystem.DisableDevice(Accelerometer.current);
        }
        
        jump.Disable();
        rotate.Disable();
        activate.Disable();
        pause.Disable();
    }

    private void Awake() 
    {
        controls = new PlayerInputActions();
    }

    private void Update() 
    {
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            movementInput = rotate.ReadValue<Vector3>() * 2.5f;
        }
        else
        {
            movementInput = rotate.ReadValue<Vector2>();
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        Debug.Log("Jumped");
        PlayerManager.Instance.Jump();
    }

    public void Activate(InputAction.CallbackContext context)
    {
        Debug.Log("Activated Button");
        activatePressed?.Invoke();
    }

    public void Pause(InputAction.CallbackContext context)
    {
        Debug.Log("Pause Pressed");
        pausePressed?.Invoke();
    }
}
