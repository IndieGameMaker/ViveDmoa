using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ViveController : MonoBehaviour
{
    //Hand Controller
    public SteamVR_Input_Sources leftHand = SteamVR_Input_Sources.LeftHand;
    public SteamVR_Input_Sources rightHand = SteamVR_Input_Sources.RightHand;
    public SteamVR_Input_Sources any = SteamVR_Input_Sources.Any;   

    //Trigger Button
    public SteamVR_Action_Boolean trigger = SteamVR_Actions.default_InteractUI; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (trigger.GetStateDown(leftHand))
        {
            Debug.Log("Left hand trigger down");
        }
        if (trigger.GetState(rightHand))
        {
            Debug.Log($"Right Hand trigger click = {Time.time}");
        }
        /*
            SteamVR_Actions.{ActionSet}_{BindMapping}.GetStateDown({Controller})
            GetStateDown()
            GetState()
            GetStateUp();
        */
        // if (SteamVR_Actions.default_InteractUI.GetStateDown(SteamVR_Input_Sources.LeftHand))
        // {
        //     Debug.Log("Trigger Left Hand");
        // }
    }
}
