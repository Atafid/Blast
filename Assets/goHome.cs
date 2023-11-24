using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class goHome : MonoBehaviour
{
    //the script for the home menu
    public startButton homeScript;

    //the script for the game over variable
    public PlayerCollision playerScript;

    //the start button
    public GameObject start;

    //the start text
    public Text startText;

    void Start() {
    	startText = GameObject.Find("Start").GetComponent<Text>();
    }

    void OnTouchDown() {
    	//go to home menu
    	homeScript.Start();
    	startText.enabled = true;
    	homeScript.background.SetActive(true);
    	start.SetActive(true);

    	//the game is not over anymore
    	playerScript.isGameOver = false;
    }
}
