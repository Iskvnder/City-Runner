using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public GameObject playerObject;
    public Animator playerAnimator;

    void Update()
    {
        gameOverAnimation();
    }

    void gameOverAnimation(){

        PlayerController playerInfo = playerObject.GetComponent<PlayerController>();
        if(playerInfo.isTouched == true){
            playerAnimator.SetTrigger("isDead");
        }
    }
}
