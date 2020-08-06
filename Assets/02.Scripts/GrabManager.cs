using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class GrabManager : MonoBehaviour
{
    private SteamVR_Action_Boolean grab;
    private SteamVR_Input_Sources hand;

    private Transform grabObject;
    private bool isTouched;

    // Start is called before the first frame update
    void Start()
    {
        grab = SteamVR_Actions.default_GrabGrip;
        hand = SteamVR_Input_Sources.Any;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTouched == true && grab.GetStateDown(hand))
        {
            grabObject.SetParent(this.transform);
        }
        if (isTouched == true && grab.GetStateUp(hand))
        {
            grabObject.SetParent(null);
            isTouched = false;
            grabObject = null;
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("BALL"))
        {
            isTouched = true;
            grabObject = coll.transform;
        }
    }
}
