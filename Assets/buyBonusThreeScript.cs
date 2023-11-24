using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buyBonusThreeScript : MonoBehaviour
{
    //script to have the list of meteore 
	public TirEnemyApparition scriptList;

	//the script to know if we have buy bonus
	public PlayerCollision playerScript;

	//to find the script
	void Start() {
		scriptList = GameObject.Find("Ground").GetComponent<TirEnemyApparition>();
		playerScript = GameObject.Find("Player").GetComponent<PlayerCollision>();
	}

	void OnTouchDown() {
		bonusEffect();
		playerScript.buyBonusThree--;

		if(playerScript.buyBonusThree==0) {
			this.gameObject.SetActive(false);
		}
	}

	//the effect of the bonus
    void bonusEffect() {
    	//destroy all meteore on the screen
    	foreach(GameObject meteore in scriptList.listMeteore) {
    		Destroy(meteore);
    	}
    }
}
