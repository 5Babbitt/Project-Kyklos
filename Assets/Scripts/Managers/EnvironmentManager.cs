using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnvironmentManager : MonoBehaviour
{
    //Singleton Instantiation
    private static EnvironmentManager instance;
    public static EnvironmentManager Instance
    {
        get
        {
            if (instance == null) 
            {
                instance = GameObject.FindObjectOfType<EnvironmentManager>();
            }
            return instance;
        }
    }
    
    [SerializeField] [Range(0, 720f)] private float rotationSpeed = 30f;
    [SerializeField] [Range(0, 360f)] private float clampAngle = 45f;
    [SerializeField] private float _rotation; 
    [SerializeField] private Transform centre;

    private void OnEnable() 
    {
        centre = PlayerManager.Instance.playerTransform;
    }
    
    void Update()
    {
        Vector3 movement = InputManager.Instance.movementInput;

        float rotateDelta = movement.x * -rotationSpeed * Time.deltaTime;
        float newRotation = Mathf.Clamp(_rotation + rotateDelta, -clampAngle, clampAngle);

        ApplyRotation(newRotation);
    }

    private void ApplyRotation(float newRotation)
    {
        float rotationDelta = newRotation - _rotation;
        
        transform.RotateAround(centre.position, Vector3.forward, rotationDelta);
        _rotation = _rotation + rotationDelta;
        
        transform.rotation = Quaternion.Euler( 0, 0, _rotation);
    }
}
