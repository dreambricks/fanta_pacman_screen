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
    public Texture endScreen;
    public VideoPlayer vpEndScreen;
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
            vpEndScreen.Play();
            imagePanel.texture = endScreen;
            Invoke(nameof(SetIdledScreen), 6.0f);
        }
        else if (data == "1") 
        {
            vpEndScreen.Stop();
            vpEndScreen.Prepare();
            imagePanel.texture = playingScreen;

        }
    }

    private void SetIdledScreen()
    {
        imagePanel.texture = idleScreen;
    }
}
