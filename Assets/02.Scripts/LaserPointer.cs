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
    public float maxDistance = 10.0f;
    public Color defaultColor = Color.green; //new Color(0.0f, 1.0f, 0.0f, 0.0f);
    public Color clickedColor = Color.red;

    void Start()
    {
        pose = GetComponent<SteamVR_Behaviour_Pose>();    
        hand = pose.inputSource;
        CreateLine();  
    }

    void CreateLine()
    {
        line = this.gameObject.AddComponent<LineRenderer>();
        line.useWorldSpace = false;
        line.receiveShadows = false;

        //Start Point, End Point
        line.positionCount = 2;
        line.SetPosition(1, new Vector3(0, 0, maxDistance));

        line.startWidth = 0.05f;
        line.endWidth   = 0.005f;
    }
}
