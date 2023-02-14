using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelTween : MonoBehaviour
{
    [SerializeField] private float panelVerticalOffset = 1080f;
    [SerializeField] private float panelHorizontalOffset = 1920f;
    [SerializeField] private float panelOrigin = 0f;
    [SerializeField] private float tweenTime = 0.5f;

    public void OnClickBack()
    {
        LeanTween.moveLocalY(gameObject, panelOrigin, tweenTime);
    }

    public void OnClickBackHorizontal()
    {
        LeanTween.moveLocalX(gameObject, panelOrigin, tweenTime);
    }
    
    public void OnClickOptions()
    {
        LeanTween.moveLocalY(gameObject, panelVerticalOffset, tweenTime);
    }

    public void OnClickPlay()
    {
        LeanTween.moveLocalY(gameObject, -panelVerticalOffset, tweenTime);
    }

    public void OnClickCredits()
    {
        LeanTween.moveLocalX(gameObject, -panelHorizontalOffset, tweenTime);
    }
}
