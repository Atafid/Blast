using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonusTwoCollision : MonoBehaviour
{
	//the script to have the money variable
	public EnemyCollision enemyScript;

	void Start() {
		enemyScript = GameObject.Find("Enemy").GetComponent<EnemyCollision>();
	}

    //detect a collision
    void OnCollisionEnter(Collision collision) {
    	if(collision.collider.name=="Player") {
    		bonusEffect();
    	}

    	if(collision.collider.name=="meteore(Clone)") {
    		Destroy(collision.collider.gameObject);
    	}
    }

    //the effect of the bonus
    void bonusEffect() {
    	enemyScript.money += 10;
    	Destroy(this.gameObject);
    }
}
