using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float xSpeed = 0f;
    [SerializeField] private float ySpeed = 0.5f;
    [SerializeField] private float zSpeed = 0f;
    
    private void Update() 
    {
        transform.Rotate( +1 * xSpeed/100f, +1 * ySpeed/100f,  +1 * zSpeed/100f);
    }
}
