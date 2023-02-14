using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollTexture : MonoBehaviour
{
    [SerializeField]
    private float yScroll = 0.5f;
    [SerializeField]
    private float xScroll = 0.5f;

    void Update()
    {
        float xOffset = Time.time * xScroll;
        float yOffset = Time.time * yScroll;
        GetComponent<MeshRenderer>().material.mainTextureOffset = new Vector2(xOffset, yOffset);
    }
}
