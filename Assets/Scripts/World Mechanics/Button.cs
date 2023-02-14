using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    [SerializeField] UnityEvent OnButtonPressed;
    [SerializeField] private Animator animator;

    [SerializeField] private bool pressed = false;

    private void Awake() 
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag != "Player" || pressed == true)
        {
            return;
        }

        pressed = true;

        Debug.Log("Pressed = " + pressed.ToString());

        animator.SetBool("Pressed", pressed);
        
        OnButtonPressed.Invoke();
    }
}
