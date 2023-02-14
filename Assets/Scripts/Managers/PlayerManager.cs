using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class PlayerManager : MonoBehaviour
{
    //Singleton Instantiation
    private static PlayerManager instance;
    public static PlayerManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<PlayerManager>();
            }
            return instance;
        }
    }

    [Header("Refernces")]
    [SerializeField] private Collider groundCheckBottom; //Ground Check trigger at bottom of Player, detects if colliding with the ground
    [SerializeField] private Collider groundCheckTop; //Ground Check trigger at top of Player, detects if colliding with the ground
    public Rigidbody rb;
    public Transform playerTransform;
    public CinemachineVirtualCamera camTop;
    public CinemachineVirtualCamera camBottom;
    public AudioSource audioSource;

    //Variables for Collectibles
    public int _coins;
    public int _gems;

    [Header("Properties")]
    [SerializeField] private Vector3 gravity; //Gravitational force to apply in an inverted gravity zone
    [SerializeField] private Vector3 jumpDirection;
    [SerializeField] private float fallMultiplier = 2f; //Applies extra downwards force so that the character falls faster
    [SerializeField][Range(0f, 2000f)] private float jumpForce = 10f; //Force applied when jumping
    public bool isGrounded; //If the player is grounded set to true

    private void Awake()
    {
        //Getting Object References
        audioSource = GetComponentInChildren<AudioSource>();

        //Setting Default Properties
        gravity = Physics.gravity;
        jumpDirection = -gravity.normalized;
    }
    
    private void Update()
    {
        jumpDirection = (EnvironmentManager.Instance.transform.up).normalized;
    }

    private void FixedUpdate()
    {
        //This applies gravity in the opposite direction when not using gravity
        if (!rb.useGravity)
        {
            ApplyUpwardGravity();
        }

        if (!isGrounded)
        {
            //If the player is not grounded this applies extra force to increase the fallspeed
            if (rb.velocity.y < 0 && rb.useGravity)
            {
                rb.AddForce(gravity * fallMultiplier, ForceMode.Acceleration);
            }
            else if (rb.velocity.y > 0 && !rb.useGravity)
            {
                rb.AddForce(-gravity * fallMultiplier, ForceMode.Acceleration);
            }
        }
    }

    //Checking if Player is Grounded
    private void OnTriggerStay(Collider other) 
    {
        if (other.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    //Checking if Player has left Ground
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ground")
        {
            isGrounded = false;
        }
    }

    public void Jump()
    {
        //rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        if (isGrounded)
        {
            if (rb.useGravity)
            {
                rb.AddForce(jumpDirection * jumpForce, ForceMode.Impulse);
            }
            else if (!rb.useGravity)
            {
                rb.AddForce(-jumpDirection * jumpForce, ForceMode.Impulse);
            }
        }
    }

    //If in an inverted gravity zone an upwards force is applied equal to that of gravity
    private void ApplyUpwardGravity()
    {
        rb.AddForce(-gravity, ForceMode.Acceleration);
    }

    //rb.useGravity is disabled when the player enters an inverted Gravity Zone and enabled when the player leaves
    public void GravitySwitch(bool useGravity)
    {
        rb.useGravity = useGravity;
        groundCheckBottom.enabled = useGravity;
        groundCheckTop.enabled = !useGravity;
        isGrounded = false;
        camBottom.enabled = !useGravity;
        camTop.enabled = useGravity;
    }

    //Sends the current coin value to the UI controller
    public void UpdatePlayerCoins()
    {
        _coins++;
        HUDController.Instance.UpdateCoinValue(_coins);
    }

    //Sends the current gem value to the UI controller
    public void UpdatePlayerGems()
    {
        _gems++;
        HUDController.Instance.UpdateGemValue(_gems);
    }


}