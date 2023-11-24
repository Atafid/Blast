using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invisibleObstacle : MonoBehaviour
{
	//obstacle game object
    public GameObject obstacle;
    public GameObject obstacleOne;
    public GameObject obstacleTwo;
    public GameObject obstacleThree;
    public GameObject obstacleFour;

    //timer 
    public float timer = 10.0f;

    //to know if the obstacle is active
    public bool isInactive;

    // Update is called once per frame
    void Update()
    {
        //if the obstacle is inactive
        if(isInactive) {
        	//start the timer
        	timer -= Time.deltaTime;

        	//when the timer finish, restart it and make the obstacle active
        	if(timer < 0) {
        		timer = 10.0f;

        		//obstacle is visible
        		obstacle.SetActive(true);
                obstacleOne.SetActive(true);
                obstacleTwo.SetActive(true);
                obstacleThree.SetActive(true);
                obstacleFour.SetActive(true);

        		isInactive = false;
        	}
        }
    }

    //method to make the obstacle invisible
    public void makeInvisible() {
    	//obstacle is invisible
    	obstacle.SetActive(false);
        obstacleOne.SetActive(false);
        obstacleTwo.SetActive(false);
        obstacleThree.SetActive(false);
        obstacleFour.SetActive(false);

    	isInactive = true;
    }
}
