using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemController : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerManager.Instance.audioSource.PlayOneShot(audioClip);
            PlayerManager.Instance.UpdatePlayerGems();
            Destroy(this.gameObject);
        }
    }
}
