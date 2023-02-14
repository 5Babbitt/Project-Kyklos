using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class BouncePad : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private Vector3 bounceDirection;
    [SerializeField] private float bounceForce;
    [SerializeField] private AudioSource audioSource;

    private void Awake() 
    {
        bounceDirection = transform.up;
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Player")
        {
            Rigidbody rb = other.rigidbody;

            Debug.Log("collided");
            
            bounceDirection = transform.up;
            rb.AddForce(bounceDirection * bounceForce, ForceMode.Impulse);
            audioSource.Play();
        }

    }

}
