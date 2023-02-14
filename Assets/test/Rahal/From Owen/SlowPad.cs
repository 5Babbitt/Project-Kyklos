using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class SlowPad : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float opposingForce;
    [SerializeField] private Vector3 opposingDirection;
    
    private void Awake() 
    {
        
    }

    private void OnCollisionStay(Collision other) 
    {
        if (other.gameObject.tag == "Player")
        {
            Rigidbody rb = other.rigidbody;

            Debug.Log("Slowed");

            opposingDirection = -rb.velocity.normalized;
            rb.AddForce(opposingDirection * opposingForce, ForceMode.Force);
        }
    }
}
