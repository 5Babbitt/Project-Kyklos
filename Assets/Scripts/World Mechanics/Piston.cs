using UnityEngine;

public class Piston : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Vector3 startPos;
    [SerializeField] private Transform platform;
    [SerializeField] private bool triggered;
    [SerializeField] private float distanceToStart;

    private void Awake() 
    {
        startPos = transform.position;
    }

    private void Update() 
    {
        startPos = transform.position;
        distanceToStart = Vector3.Distance(platform.transform.position, startPos);
        
        if (distanceToStart >= 0.5f && !triggered)
        {
            ResetPlatform();
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
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
