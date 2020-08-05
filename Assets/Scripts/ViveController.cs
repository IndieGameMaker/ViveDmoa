using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ViveController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
            SteamVR_Actions.{ActionSet}_{BindMapping}.GetStateDown({Controller})
            GetStateDown()
            GetState()
            GetStateUp();
        */
        if (SteamVR_Actions.default_InteractUI.GetStateDown(SteamVR_Input_Sources.LeftHand))
        {
            Debug.Log("Trigger Left Hand");
        }
    }
}
