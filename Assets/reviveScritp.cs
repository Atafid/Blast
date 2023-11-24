using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reviveScritp : MonoBehaviour
{
    //the life variable
    public PlayerCollision playerScript;

    //the die button
    public GameObject dieButton;

    void Start() {
    	playerScript = GameObject.Find("Player").GetComponent<PlayerCollision>();
    	dieButton = GameObject.Find("dieButton");
    }

    void OnTouchDown() {
    	Time.timeScale = 1;
    	playerScript.lifePlayer--;

    	this.gameObject.SetActive(false);
    	dieButton.SetActive(false);

    }
}
