using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class LaserPointer : MonoBehaviour
{
    private SteamVR_Behaviour_Pose pose;
    private SteamVR_Input_Sources hand;
    private SteamVR_Action_Boolean trigger;

    private LineRenderer line;
    

    void Start()
    {
        pose = GetComponent<SteamVR_Behaviour_Pose>();    
        hand = pose.inputSource;    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
