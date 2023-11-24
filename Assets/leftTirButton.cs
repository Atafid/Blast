using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftTirButton : MonoBehaviour
{
	//the player transform
	public Transform playerTransform;

	//the parameters of the clone
	public Rigidbody ball;
    public Transform posBall;

    //timer to not have to many balls
	public float timer;

    //button color change
	public Color defaultColor;
	public Color pressColor;
	public Material buttonMaterial;

	void Start() {
		buttonMaterial = this.GetComponent<Renderer>().material;
	}

	void FixedUpdate() {
		if(timer > 0) {
			timer -= Time.deltaTime;
		}
	}

    //when we click the button
    void OnTouchDown() {
    	if(timer <= 0) {
	    	//change color of button
	    	buttonMaterial.color = pressColor;

	    	//create and instatiate a new ball
	    	Rigidbody clone;

	    	clone = Instantiate(ball, posBall.position, Quaternion.identity);

	    	//the direction that will take the ball is an orthogonal vector of the direction to the enemy
	    	Vector3 direction;
	    	Vector3 leftDirection;

	    	direction = Vector3.zero-playerTransform.position;
	    	leftDirection = rotate90(direction);

	    	//Add a force to the new ball
	    	clone.AddForce(leftDirection*12500f*Time.deltaTime);

	    	timer = 0.25f;
	    }
    }

    void OnTouchUp() {
    	//change color of button
    	buttonMaterial.color = defaultColor;
    }

    void OnTouchExit() {
    	//change color of button
    	buttonMaterial.color = defaultColor;
    }

    //method to rotate a vector of 90°
    Vector3 rotate90(Vector3 vect) {
    	return new Vector3(vect.z, 0, -vect.x);
    }
}
