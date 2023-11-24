using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whichObstacle : MonoBehaviour
{
	//the ennemy collision script
    public EnemyCollision enemyScript;

    //the differents obstacle game object
    public GameObject obstacle;
    public GameObject obstacleOne;
    public GameObject obstacleTwo;
    public GameObject obstacleThree;
    public GameObject obstacleFour;

    //to know if we have change the obstacle
    public bool isChange = true;

    // Start is called before the first frame update
    void Start()
    {
        if(enemyScript.currentLevel <= 5) {
        	obstacleFour.transform.position = Vector3.zero;
        }

        if(enemyScript.currentLevel > 5 && enemyScript.currentLevel <= 15) {
        	obstacleThree.transform.position = Vector3.zero;
        }

        if(enemyScript.currentLevel > 15 && enemyScript.currentLevel <= 25) {
        	obstacleTwo.transform.position = Vector3.zero;
        }

        if(enemyScript.currentLevel > 25 && enemyScript.currentLevel <= 35) {
        	obstacleOne.transform.position = Vector3.zero;
        }

        if(enemyScript.currentLevel > 35) {
        	obstacle.transform.position = Vector3.zero;
        }
    }

    // Update is called once per frame
    void Update()
    {
    	switch(enemyScript.currentLevel) {
    		case 5:
    			isChange = false;
    			break;

    		case 15:
    			isChange = false;
    			break;

    		case 25:
    			isChange = false;
    			break;

    		case 35:
    			isChange = false;
    			break;
    	}

        if(!isChange) {
        	switch(enemyScript.currentLevel) {
        		case 6:
        			obstacleFour.transform.position = Vector3.left*100;
        			obstacleThree.transform.position = Vector3.zero;
        			isChange = true;
        			break;

        		case 16:
        			obstacleThree.transform.position = Vector3.left*100;
        			obstacleTwo.transform.position = Vector3.zero;
        			isChange = true;
        			break;

        		case 26:
        			obstacleTwo.transform.position = Vector3.left*100;
        			obstacleOne.transform.position = Vector3.zero;
        			isChange = true;
        			break;

        		case 36:
        			obstacleOne.transform.position = Vector3.left*100;
        			obstacle.transform.position = Vector3.zero;
        			isChange = true;
        			break;
        	}
        }
    }
}
