using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dieScript : MonoBehaviour
{
	//the game over variable
	public PlayerCollision playerScript;

	//the revive button
	public GameObject reviveButton;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerCollision>();
        reviveButton = GameObject.Find("reviveButton");
    }

    void OnTouchDown() {
    	playerScript.isGameOver = true;

    	this.gameObject.SetActive(false);
    	reviveButton.SetActive(false);
    }
}
