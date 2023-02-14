using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private int _collectibles;
    private int _gold;
    public GameObject canvas;
    PlayerSpeedCheck _UI;

    void Start()
    {
        _UI = canvas.GetComponent<PlayerSpeedCheck>();
    }


    public void UpdatePlayerCollectibles()
    {
        _collectibles++;
        _UI.UpdateCollectibleDisplay(_collectibles);
    }

    public void UpdateGold()
    {
        _gold++;
        _UI.UpdateGoldDisplay(_gold);
    }


}
