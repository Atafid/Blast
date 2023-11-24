using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
	public bool isGameOver;

	//the lifes of the player
	public int lifePlayer;

	//the buyed bonus to destroy meteore
	public int buyBonusThree;
	public int buyBonusFour;

	//the button to revive
	public GameObject reviveButton;

	//the button to die
	public GameObject dieButton;

	void Start() {
		//buttons = invisible
		reviveButton.SetActive(false);
		dieButton.SetActive(false);
	}

    //to know if we collide something
    void OnCollisionEnter(Collision collision) {
    	//if we collide a meteore
    	if(collision.collider.name=="Meteore(Clone)" || collision.collider.name=="meteoreBoss(Clone)") {
    		//freeze the game
    		Time.timeScale = 0;

    		Destroy(collision.collider);

    		if(lifePlayer==0) {
    			isGameOver = true;
    		}

    		else {
    			//buttons = invisible
				reviveButton.SetActive(true);
				dieButton.SetActive(true);
    		}
    	}
    }
}
