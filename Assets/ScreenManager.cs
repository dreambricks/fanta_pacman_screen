using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ScreenManager : MonoBehaviour
{
    public Texture idleScreen;
    public Texture playingScreen;
    private RawImage imagePanel;


    [SerializeField] private ArduinoCommunication arduinoCommunication;


    private void Start()
    {
        imagePanel = GetComponent<RawImage>();

        // call this only to demo 
        //Invoke(nameof(ToggleTexture), 10.0f);
    }

    private void ToggleTexture()
    {
        if (imagePanel.texture != playingScreen) 
        {
            imagePanel.texture = playingScreen;
        }
        else
        {
            imagePanel.texture = idleScreen;
        }
        Invoke(nameof(ToggleTexture), 10.0f);
    }

    private void Update()
    {
        string data = arduinoCommunication.GetLastestData();

        if (data == "1")
        {
            imagePanel.texture = idleScreen;
        }
        else if (data == "2") 
        {
            imagePanel.texture = playingScreen;
        }
    }
}
