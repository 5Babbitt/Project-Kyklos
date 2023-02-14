using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowEffect : MonoBehaviour
{
    public Rigidbody player;
    //public float slowVal = 999f;

    [Range(0f, 0.98f)] [SerializeField] private float deceleration = 0.998f;

    [SerializeField]
    private bool onPad;

    private void Awake() 
    {
        player = PlayerManager.Instance.rb;
    }

    void FixedUpdate()
    {
        if (onPad) //if the player is on the pad, player speed will be reduced
        {
            player.velocity *= deceleration;
        }
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            onPad = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            onPad = false;
        }
    }
}
