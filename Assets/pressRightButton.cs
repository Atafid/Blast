using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class pressRightButton : MonoBehaviour
{
	//to know if the button is pressed
	public bool pressed;

	//the player and origine transforms
	public Transform playerTransform;
	public Transform origineTransform;
	public Transform leftBallTransform;
	public Transform rightBallTransform;

    // Update is called once per frame
    void Update()
    {
        if(pressed) {
        	//the player and the point of origine of the balls rotate around the enemy
        	playerTransform.RotateAround(Vector3.zero, Vector3.up, 60*Time.deltaTime);
        	origineTransform.RotateAround(Vector3.zero, Vector3.up,60*Time.deltaTime);
        	leftBallTransform.RotateAround(Vector3.zero, Vector3.up, 60*Time.deltaTime);
        	rightBallTransform.RotateAround(Vector3.zero, Vector3.up, 60*Time.deltaTime);
        }
    }

    //different functions to know if we press the button
    void OnTouchDown() {
    	pressed = true;
    }

    void OnTouchUp() {
    	pressed = false;
    }

    void OnTouchStay() {
    	pressed = true;
    }

    void OnTouchExit() {
    	pressed = false;
    }
}
