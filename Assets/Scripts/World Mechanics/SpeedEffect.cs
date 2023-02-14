using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedEffect : MonoBehaviour
{
    public Rigidbody player;
    //public float speedVal = 999f;
    [Range(1f, 1.1f)][SerializeField] private float acceeleration = 1.005f;

    [SerializeField]
    private bool onPad;

    private void Awake()
    {
        player = PlayerManager.Instance.rb;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (onPad)
        {
            player.velocity *= acceeleration;
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
