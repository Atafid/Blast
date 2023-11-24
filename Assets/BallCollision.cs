using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
	//to know if we collide something
    void OnCollisionEnter(Collision collision) {
    	//if we collide something, enemy, ground, obstacle... destroy the ball
    	Destroy(this.gameObject);
    }
}
