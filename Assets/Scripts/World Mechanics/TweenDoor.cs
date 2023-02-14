using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenDoor : MonoBehaviour
{
    [SerializeField] private GameObject door;
    [SerializeField] private Transform openPos;
    [SerializeField] private Transform closedPos;
    [SerializeField] private AudioSource doorSound;

    public void OpenDoor()
    {
        LeanTween.moveLocalY(door, openPos.position.y, 0.5f);
        doorSound.Play();
    }

    public void CloseDoor()
    {
        LeanTween.moveLocalY(door, closedPos.position.y, 0.5f);
        doorSound.Play();
    }
}
