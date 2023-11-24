using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonusOneCollision : MonoBehaviour
{
	//the script to have the level variable
	public EnemyCollision enemyScript;

	//to find the script
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
    	enemyScript.currentLevel++;
    	enemyScript.nextLevel++;
    	Destroy(this.gameObject);
    }
}
