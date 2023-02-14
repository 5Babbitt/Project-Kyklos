using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSpeedCheck : MonoBehaviour
{
    public Rigidbody norm;
    public Rigidbody slow;
    private float normSpeed;
    private float slowSpeed;
    private float deltaVal;

    public Text normalSpeed;
    public Text effectSpeed;
    public Text delta;
    public Text collectibles;
    public Text gold;

    void Update()
    {
        normSpeed = norm.velocity.magnitude;
        normalSpeed.text = normSpeed.ToString();
        slowSpeed = slow.velocity.magnitude;
        effectSpeed.text = slowSpeed.ToString();

        deltaVal = normSpeed - slowSpeed;
        delta.text = "Delta:" + deltaVal.ToString();
    }

    public void UpdateCollectibleDisplay(int coin)
    {
        collectibles.text = "Collectibles: " + coin.ToString();
    }

    public void UpdateGoldDisplay(int goldAmount)
    {
        gold.text = "Gold: " + goldAmount.ToString();
    }

}
