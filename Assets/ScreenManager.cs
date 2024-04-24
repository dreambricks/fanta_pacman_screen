using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using UnityEngine.UI;

public class ScreenManager : MonoBehaviour
{
    public Texture idleScreen;
    public Texture playingScreen;
    private RawImage imagePanel;

    [SerializeField] private ArduinoCommunication arduinoCommunication;


    private void Start()
    {
        imagePanel = GetComponent<RawImage>();
    }


    private void Update()
    {
        string data = arduinoCommunication.GetLastestData();

        if (data == "0")
        {
            imagePanel.texture = idleScreen;

        }
        else if (data == "1") 
        {
            imagePanel.texture = playingScreen;

        }

    }
}
