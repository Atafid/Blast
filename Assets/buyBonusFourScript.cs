using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buyBonusFourScript : MonoBehaviour
{
    //the game object for the script for the method for the bonus effect
	public GameObject Ground;

	//the script to have the number of buyed bonus
	public PlayerCollision playerScript;

	void Start() {
		//find the game object
		Ground = GameObject.Find("Ground");

		//get the script
		playerScript = GameObject.Find("Player").GetComponent<PlayerCollision>();
	}

    //detect a collision
    void OnTouchDown() {
    	//get the script component and call the function
    	Ground.GetComponent<invisibleObstacle>().makeInvisible();
    	
    	playerScript.buyBonusFour--;

    	if(playerScript.buyBonusFour==0) {
    		this.gameObject.SetActive(false);
    	}
    }
}
