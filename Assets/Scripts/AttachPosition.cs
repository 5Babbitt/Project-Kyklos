using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class AttachPosition : MonoBehaviour
{
    [SerializeField] private Transform objectTransform;
    [SerializeField] private Vector3 offset;

    private void Update() 
    {
        transform.position = objectTransform.position + offset;
    }

    public void EditOffset(float modifier)
    {
        offset *= modifier;
    }
}
