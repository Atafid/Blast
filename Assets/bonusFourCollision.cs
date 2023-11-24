using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonusFourCollision : MonoBehaviour
{
	//the game object for the script for the method for the bonus effect
	public GameObject Ground;

	void Start() {
		//find the game object
		Ground = GameObject.Find("Ground");
	}

    //detect a collision
    void OnCollisionEnter(Collision collision) {
    	if(collision.collider.name=="Player") {
    		//get the script component and call the function
    		Ground.GetComponent<invisibleObstacle>().makeInvisible();
    		Destroy(this.gameObject);
    	}

    	if(collision.collider.name=="meteore(Clone)") {
    		Destroy(collision.collider.gameObject);
    	}
    }
}
