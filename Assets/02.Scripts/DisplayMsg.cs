using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayMsg : MonoBehaviour
{
    private Text msgText;

    void Start()
    {
        msgText = GetComponent<Text>();        
    }

    public void Message(string msg)
    {
        msgText.text = msg;
    }
}
