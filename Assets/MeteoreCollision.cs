using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoreCollision : MonoBehaviour
{
    //method to detect a collision
    void OnCollisionEnter(Collision collision) {
    	//when a meteore collide something : player, ground... it is destroyed
    	Destroy(this.gameObject);
    }
}
