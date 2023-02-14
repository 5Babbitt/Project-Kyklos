using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resizer : MonoBehaviour
{
    private bool _Size = false;
    [SerializeField] private float resizeValue = 0.5f;
    [SerializeField] private float originalValue = 1f;

    [SerializeField] private AttachPosition[] offsets;

    //private void OnEnable() 
    //{
    //    InputManager.activatePressed += Size;
    //}

    //private void OnDisable() 
    //{
    //    InputManager.activatePressed -= Size;
    //}

    public void Size()
    {
        _Size = !_Size;

        if(_Size == true)
        {
            transform.localScale = new Vector3(resizeValue, resizeValue, resizeValue);
            foreach (var offset in offsets)
            {
                offset.EditOffset(resizeValue);
            }
        }
        else if (_Size == false)
        {
            transform.localScale = new Vector3(originalValue, originalValue, originalValue);
            foreach (var offset in offsets)
            {
                offset.EditOffset(originalValue/resizeValue);
            }
        }
    }
}
