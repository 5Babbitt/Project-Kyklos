using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HingeDoor : MonoBehaviour
{
    [SerializeField] private float pressedPosition = 90f;
    [SerializeField] private float hitStrength = 5000f;
    [SerializeField] private float flipperDamp = 50f;

    private HingeJoint hinge;

    private void Awake() 
    {
        hinge = GetComponent<HingeJoint>();
        hinge.useSpring = true;
    }
    
    public void OpenDoor()
    {
        JointLimits limits = new JointLimits();
        JointSpring spring = new JointSpring();
        limits.max = pressedPosition;
        spring.spring = hitStrength;
        spring.damper = flipperDamp;
        
        spring.targetPosition = pressedPosition;
        
        hinge.limits = limits;
        hinge.spring = spring;
        hinge.useLimits = true;
    }
}
