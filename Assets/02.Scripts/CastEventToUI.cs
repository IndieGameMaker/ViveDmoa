using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; //<==
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
        IPointerEnterHandler handler = e.target.GetComponent<IPointerEnterHandler>();
        if (handler == null) return;

        handler.OnPointerEnter(new PointerEventData(EventSystem.current));
    }

    //Laser Pointer Exit
    void OnPointerExit(object sender, PointerEventArgs e)
    {
        IPointerExitHandler handler = e.target.GetComponent<IPointerExitHandler>();
        if (handler == null) return;

        handler.OnPointerExit(new PointerEventData(EventSystem.current));
    }

    //Laser Pointer Click
    void OnPointerClick(object sender, PointerEventArgs e)
    {
        IPointerClickHandler handler = e.target.GetComponent<IPointerClickHandler>();
        if (handler == null) return;

        handler.OnPointerClick(new PointerEventData(EventSystem.current));
    }

}
