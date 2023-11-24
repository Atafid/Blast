using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteoreBoss : MonoBehaviour
{
	//to konw if it is grouding
	public bool isGrounding;

	//the vectors to have the angle between player and boss meteore
	public Transform playerTransform;
	public Vector3 playerVector;
	public Vector3 tirVector;

	//the angle between player and boss meteore
	public float leftAngle;

	void Start() {
		//get the player transform component
		playerTransform = GameObject.Find("Player").GetComponent<Transform>();
	}

    // Update is called once per frame
    void Update()
    {
    	//the vectors are updated at each frame
    	playerVector = playerTransform.position;
        tirVector = this.gameObject.transform.position;

        if(isGrounding) {
        	//the angle is calculate
        	leftAngle = Vector3.SignedAngle(tirVector, playerVector, Vector3.up);
        	
        	//if the player is a left of the tir, rotate left, else, rotate right
        	if(leftAngle < 0) {
        		this.gameObject.transform.RotateAround(Vector3.zero, Vector3.down, 40*Time.deltaTime);
        	}

        	else {
				this.gameObject.transform.RotateAround(Vector3.zero, Vector3.up, 40*Time.deltaTime);
        	}
        }
    }

    //if there is a collision
    void OnCollisionEnter(Collision collision) {
    	//if is on the ground
    	if(collision.collider.name=="Ground") {
    		isGrounding = true;
    		this.gameObject.transform.rotation = Quaternion.identity;
    	}

    	//if collide a player tir, destroy it
    	if(collision.collider.name=="Ball(Clone)" || collision.collider.name=="Bonus 1(Clone)" || collision.collider.name=="Bonus 2(Clone)" || collision.collider.name=="Bonus 3(Clone)" || collision.collider.name=="Bonus 4(Clone)") {
    		Destroy(this.gameObject);
    	}

    	//if it collides a meteore, destroy it and reset the rotation
    	if(collision.collider.name=="Meteore(Clone)") {
    		Destroy(collision.collider.gameObject);
    		this.gameObject.transform.rotation = Quaternion.identity;
    	}

    	//if it collides a meteore boss, destroy it and reset the rotation
    	if(collision.collider.name=="meteoreBoss(Clone)") {
    		Destroy(collision.collider.gameObject);
    		this.gameObject.transform.rotation = Quaternion.identity;
    	}
    }
}
