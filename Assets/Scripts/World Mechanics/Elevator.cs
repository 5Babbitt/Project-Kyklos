using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Vector3 startPos;
    [SerializeField] private Transform platform;
    [SerializeField] private bool inUse;
    [SerializeField] private bool triggered;
    [SerializeField] private bool colliding;
    [SerializeField] private float distanceToStart;

    private void Awake() 
    {
        startPos = transform.position;
    }

    private void Update() 
    {
        startPos = transform.position;
        distanceToStart = Vector3.Distance(platform.transform.position, startPos);
        
        if (distanceToStart >= 0.5f && !inUse)
        {
            ResetPlatform();
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            inUse = true;
            triggered = true;
        }
    }

    private void OnTriggerStay(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            RaisePlatform();
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            triggered = false;
            
            if (!colliding)
            {
                inUse = false;
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            colliding = true;
        }
    }

    private void OnCollisionExit(Collision other) 
    {
        if(other.gameObject.tag == "Player")
        {
            colliding = false;

            if (triggered == false)
            {
                inUse = false;
            }
        }
    }

    private void RaisePlatform()
    {
        platform.transform.position += platform.transform.up * speed * Time.deltaTime;
    }

    private void ResetPlatform()
    {
        platform.transform.position += platform.transform.up * -speed * Time.deltaTime;
    }
}
