using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class EndMenuController : MonoBehaviour
{
    
    public GameObject playerObject;
    public GameObject endMenuCanvas;
    public GameObject spawnObject;
    private bool onGoing = true;
    public TextMeshProUGUI resultText;
    
    void Start(){
        endMenuCanvas.SetActive(false);
    }
    void Update(){

        onGoingCheck();
        gameOver();
    }


    void onGoingCheck(){

        PlayerController playerInfo = playerObject.GetComponent<PlayerController>();
        ObstacleSpawner spawnInfo = spawnObject.GetComponent<ObstacleSpawner>();

        if(playerInfo.isTouched == false)
            {
                onGoing = true;
            }
            else {
                onGoing = false; 
                resultText.text = spawnInfo.timeTracker();
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                }

    }

    void gameOver(){
        if(onGoing == false){
            endMenuCanvas.SetActive(true);
        }
    }


    public void restartButton(){
        SceneManager.LoadScene(0);
    }

    public void exitButton(){
        Application.Quit();
    }
}
