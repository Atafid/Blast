using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tirButton : MonoBehaviour
{
    //the parameters for the player
	public Rigidbody PlayerRb;
	public Transform PlayerTransform;

	//the parameters for the balls
	public Rigidbody ball;
	public Transform origine;

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

    void OnTouchDown() {
    	if(timer <= 0) {
	    	//change color of button
	    	buttonMaterial.color = pressColor;

	    	//Create a new Rigidbody for the new ball that will be create
	       	Rigidbody clone;

	       	//instantiate the ball with the origine position and rotation
	       	clone = Instantiate(ball, origine.position, origine.rotation) as Rigidbody;

	       	//create a vector for the direction of the balls, this vector is between the player and the enemy
	       	Vector3 direction;
	       	direction = Vector3.zero - PlayerTransform.position;

	       	//add a force to the new ball, it now goes to the enemy
	       	clone.AddForce(direction*12500f*Time.deltaTime);

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
}
