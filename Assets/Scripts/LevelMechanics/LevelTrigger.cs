using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelTrigger : MonoBehaviour
{
    public UnityEvent LevelEvent;
    
    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
            LevelEventMethod();
        }
    }

    private void LevelEventMethod()
    {
        LevelEvent.Invoke();
    }
}
