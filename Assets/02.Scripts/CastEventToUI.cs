using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.Extras;

public class CastEventToUI : MonoBehaviour
{
    private SteamVR_LaserPointer laserPointer;

    void Awake()
    {
        laserPointer = GetComponent<SteamVR_LaserPointer>();        
    }

    void OnEnable()
    {
        laserPointer.PointerIn    += OnPointerEnter;
        laserPointer.PointerOut   += OnPointerExit;
        laserPointer.PointerClick += OnPointerClick;
    }

    void OnDisable()
    {
        laserPointer.PointerIn    -= OnPointerEnter;
        laserPointer.PointerOut   -= OnPointerExit;
        laserPointer.PointerClick -= OnPointerClick;        
    }

    
    //Laser Pointer Hover
    void OnPointerEnter(object sender, PointerEventArgs e)
    {

    }

    //Laser Pointer Exit
    void OnPointerExit(object sender, PointerEventArgs e)
    {

    }

    //Laser Pointer Click
    void OnPointerClick(object sender, PointerEventArgs e)
    {

    }

}
