using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerManager.Instance.audioSource.PlayOneShot(audioClip);
            PlayerManager.Instance.UpdatePlayerCoins();
            Destroy(this.gameObject);
        }
    }
}
