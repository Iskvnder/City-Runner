using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject menuCanvas;
    public bool isGameStarted = false;
    public float inMenuTime;

    public void startButton(){
        inMenuTime = Time.time;
        isGameStarted = true;
        menuCanvas.SetActive(false);
    }

    public void exitButton(){
        Application.Quit();
    }

}
