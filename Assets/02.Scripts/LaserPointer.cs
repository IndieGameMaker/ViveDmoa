﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Valve.VR;

public class LaserPointer : MonoBehaviour
{
    private SteamVR_Behaviour_Pose pose;
    private SteamVR_Input_Sources hand;
    private SteamVR_Action_Boolean trigger;
    private SteamVR_Action_Boolean teleport;

    private Transform tr;
    private RaycastHit hit;

    private LineRenderer line;
    public float maxDistance = 10.0f;
    public Color defaultColor = Color.green; //new Color(0.0f, 1.0f, 0.0f, 0.0f);
    public Color clickedColor = Color.red;

    private GameObject currButton = null;
    private GameObject prevButton = null;

    public GameObject pointerPrefab;
    private GameObject pointer;

    public float fadeDuration = 0.2f;

    void Start()
    {
        tr = GetComponent<Transform>();
        pose = GetComponent<SteamVR_Behaviour_Pose>();    
        hand = pose.inputSource;

        trigger = SteamVR_Actions.default_InteractUI;
        teleport = SteamVR_Actions.default_Teleport;

        pointer = Instantiate(pointerPrefab);

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

        //line.numCornerVertices = 20;
        line.numCapVertices = 20;
        line.material = new Material(Shader.Find("Unlit/Color"));
        line.material.color = defaultColor;
    }

    void Update()
    {
        if (Physics.Raycast(tr.position, tr.forward, out hit, maxDistance))
        {
            line.SetPosition(1, new Vector3(0.0f, 0.0f, hit.distance));

            pointer.transform.position = hit.point + (hit.normal * 0.01f);
            pointer.transform.rotation = Quaternion.LookRotation(hit.normal);

            currButton = hit.collider.gameObject;
            if (currButton != prevButton)
            {
                //Current Button Send Event
                ExecuteEvents.Execute( currButton
                                     , new PointerEventData(EventSystem.current)
                                     , ExecuteEvents.pointerEnterHandler);

                //Previous Button Send Event
                ExecuteEvents.Execute( prevButton
                                     , new PointerEventData(EventSystem.current)
                                     , ExecuteEvents.pointerExitHandler); 
                prevButton = currButton;              
            }

            if (trigger.GetStateDown(hand))
            {
                ExecuteEvents.Execute( currButton
                                     , new PointerEventData(EventSystem.current)
                                     , ExecuteEvents.pointerClickHandler);
                line.material.color = clickedColor;
            }
            
            if (trigger.GetStateUp(hand))
            {
                line.material.color = defaultColor;
            }

            if (teleport.GetStateDown(hand))
            {
                SteamVR_Fade.Start(Color.black, 0.0f);
                StartCoroutine(this.Teleport(hit.point));
            }
        }
        else
        {
            line.SetPosition(1, new Vector3(0.0f, 0.0f, maxDistance));
            pointer.transform.position = tr.position + (tr.forward * maxDistance);
            pointer.transform.rotation = Quaternion.LookRotation(tr.forward);

            if (prevButton != null)
            {
                //Previous Button Send Event
                ExecuteEvents.Execute( prevButton
                                     , new PointerEventData(EventSystem.current)
                                     , ExecuteEvents.pointerExitHandler); 
                prevButton = null;
            }
        }
    }//Update

    IEnumerator Teleport(Vector3 pos)
    {
        tr.parent.transform.position = pos;
        yield return new WaitForSeconds(fadeDuration);
        SteamVR_Fade.Start(Color.clear, 0.2f);
    }

}
