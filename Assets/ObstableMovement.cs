using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstableMovement : MonoBehaviour
{
	//the transform of the obstacle
    public Transform ObstacleTransform;

    //script to have the current level
    public EnemyCollision enemyScript;

    //speed of the rotation
    public float speed;

    //the sense of rotation
    public bool leftMove = true;

    //the timer to know if we change the movement
    public float changeMovement;

    //called at the begin
    void Start() {
    	//the transform
    	ObstacleTransform = this.transform;
    	
    	//the timer is a random number between 0 and 10
    	changeMovement = Random.Range(0.0f, 10.0f);

    	//get the script
    	enemyScript = GameObject.Find("Enemy").GetComponent<EnemyCollision>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    	//to know in which direction we turn
    	if(leftMove) {
    		//update the speed
    		if(enemyScript.currentLevel<40) {
    			speed += (enemyScript.currentLevel+20)*Time.deltaTime;
    		}

    		else {
    			speed += 70*Time.deltaTime;
    		}

    		ObstacleTransform.rotation = Quaternion.Euler(90, 0, speed);
    	}

    	else {
    		//update the speed
    		if(enemyScript.currentLevel<40) {
    			speed -= (enemyScript.currentLevel+20)*Time.deltaTime;
    		}

    		else {
    			speed -= 70*Time.deltaTime;
    		}

    		ObstacleTransform.rotation = Quaternion.Euler(90, 0, speed);
    	}

    	if(enemyScript.currentLevel > 10) {
    		//update the time at each frame
	       	changeMovement -= Time.deltaTime;

	        //if the timer is finished, we restart it and change the sens of the movement
	        if(changeMovement<0) {
	        	leftMove = !leftMove;
	        	Start();
	        }
    	}
    }
}
