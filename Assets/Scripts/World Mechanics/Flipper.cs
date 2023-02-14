using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    [SerializeField] private float startPosition = 0f;
    [SerializeField] private float pressedPosition = 90f;
    [SerializeField] private float hitStrength = 5000f;
    [SerializeField] private float flipperDamp = 50f;

    private HingeJoint hinge;

    private void Awake() 
    {
        hinge = GetComponent<HingeJoint>();
        hinge.useSpring = true;
    }

    private void OnEnable() 
    {
        InputManager.activatePressed += Activate;
    }

    private void OnDisable() 
    {
        InputManager.activatePressed -= Activate;
    }
    
    public void Activate()
    {
        JointSpring spring = new JointSpring();

        spring.spring = hitStrength;
        spring.damper = flipperDamp;
        spring.targetPosition = pressedPosition;
        
        hinge.spring = spring;
        hinge.useLimits = true;
        
        StartCoroutine(ActivateCoroutine());
    }

    IEnumerator ActivateCoroutine()
    {
        yield return new WaitForSeconds(2f);
        Reset();
    }

    private void Reset()
    {
        JointSpring spring = new JointSpring();

        spring.spring = hitStrength;
        spring.damper = flipperDamp;
        spring.targetPosition = startPosition;
        
        hinge.spring = spring;
        hinge.useLimits = true;
    }
}
