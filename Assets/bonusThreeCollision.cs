using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonusThreeCollision : MonoBehaviour
{
	//script to have the list of meteore 
	public TirEnemyApparition scriptList;

	//to find the script
	void Start() {
		scriptList = GameObject.Find("Ground").GetComponent<TirEnemyApparition>();
	}

    //detect a collision
    void OnCollisionEnter(Collision collision) {
    	if(collision.collider.name=="Player") {
    		bonusEffect();
    	}

    	if(collision.collider.name=="Meteore(Clone)") {
    		Destroy(collision.collider.gameObject);
    	}
    }

    //the effect of the bonus
    void bonusEffect() {
    	foreach(GameObject meteore in scriptList.listMeteore) {
    		Destroy(meteore);
    	}
    	Destroy(this.gameObject);
    }
}
