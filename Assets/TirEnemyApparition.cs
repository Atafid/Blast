using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TirEnemyApparition : MonoBehaviour
{
	//the rigigbody to create a meteore, the prefab
    public GameObject meteore;

    //the rigidbody to create a boss meterore, the prefab
    public GameObject meteoreBoss;

    //the rigidbodies to create the bonus
    public GameObject firstBonus;
    public GameObject secondBonus;
    public GameObject thirdBonus;
    public GameObject fourthBonus;

    //to choose the bonus type
    public int bonusType;

    //the radius of the circle where the meteore spawn
    public float circleRadius = 5.1f;

    //the different position of the meteore;
    public float zPos; 
    public float xPos;
    public float yPos = 20.0f;
    public Vector3 Pos;

    //the different position of the bonus;
    public float zPosBonus; 
    public float xPosBonus;
    public float yPosBonus = 5.0f;
    public Vector3 PosBonus;

    //to know on which side of the circle the meteore spawn
    public int cirlceHalf;

    //to know on which side of the circle the bonus spawn
    public int cirlceHalfBonus;

    //the ennemy collision script
    public EnemyCollision enemyScript;

    //a timer to spawn the new meteore
    public float timerEnemie;

    //a timer for the bonus to spawn
    public float timerBonus;

    //to know is the tir is a big tir
    public int tirBoss;

    //the list of tir on the screen
    public List<GameObject> listMeteore;

    //the list of the bonus on the screen
    public List<GameObject> listBonus;

    void Start() {
    	//initialize the timer enemie
    	if(enemyScript.currentLevel < 50) {
    		timerEnemie = (-1.5f/49.0f)*enemyScript.currentLevel+(2.0f-(-1.5f/49.0f));
    	}

    	else {
    		timerEnemie = 0.5f;
    	}

    	timerBonus = Random.Range(20.0f, 60.0f);
    	
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    	//update the timer at each frame
       timerEnemie -= Time.deltaTime;
       timerBonus -= Time.deltaTime;


       //if the timer is finished, restart it and create and new meteore
       if(timerEnemie < 0) {
       		createMeteore();
       		if(enemyScript.currentLevel < 50) {
    			timerEnemie = (-1.5f/49.0f)*enemyScript.currentLevel+(2.0f-(-1.5f/49.0f));
	    	}

	    	else {
	    		timerEnemie = 0.5f;
	    	}
       }

       if(timerBonus < 0) {
       		createBonus();
       		timerBonus = Random.Range(20.0f, 60.0f);
       }

    }

    //method to create a new meteore
    void createMeteore() {
    	//the z position is a random float on the diameter of the circle
    	zPos = Random.Range(-circleRadius, circleRadius);

    	//the x position is calculate with the formule x^2+y^2=r^2 <=> x=sqrt(r^2-y^2)
        xPos = Mathf.Sqrt(circleRadius*circleRadius-zPos*zPos);

        //to know on which side of the circle the meteore spawn
        cirlceHalf = Random.Range(0,2);

        //if it is one, spawn down of the circle, spawn up
        if(cirlceHalf==1) {
        	xPos *= -1;
        }

	    //create a new rigidbody for the new clone meteore
	    GameObject clone;
	    Rigidbody cloneRb;

	    //create a quaternion to apply to the meteor
	    Quaternion angle = new Quaternion(0f, 90f, 90f, 1);

	    //the position of the clone will be define by 3 parameters
	    Pos = new Vector3(xPos, yPos, zPos);

        //1/10 to have a tir boss
        tirBoss = Random.Range(0, 5);

        if(tirBoss == 2) {
        	//create a new meteore with the defined position and null rotation
	        clone = Instantiate(meteoreBoss, Pos, Quaternion.identity);
        }

        else {
	        //create a new meteore with the defined position and a defined rotation
	        clone = Instantiate(meteore, Pos, angle);
	    }

	    //the rigidbody of the clone
	    cloneRb = clone.GetComponent<Rigidbody>();

	    //Add a force to the meteore that simulate a low gravity
	    cloneRb.AddForce(Physics.gravity*cloneRb.mass*cloneRb.mass*Random.Range(1,3));

	    //add the clone to the list of meteore
	    listMeteore.Add(clone);
    }

    //method to create a new bonus
    void createBonus() {
    	//to choose the bonus type
    	bonusType = Random.Range(0, 4);

    	//the z position is a random float on the diameter of the circle
    	zPosBonus = Random.Range(-circleRadius, circleRadius);

    	//the x position is calculate with the formule x^2+y^2=r^2 <=> x=sqrt(r^2-y^2)
        xPosBonus = Mathf.Sqrt(circleRadius*circleRadius-zPosBonus*zPosBonus);

        //to know on which side of the circle the bonus spawn
        cirlceHalfBonus = Random.Range(0,2);

        //change the position in function of the number 
        if(cirlceHalfBonus==1) {
        	xPosBonus *= -1;
        }

        //the position of the bonus
        PosBonus = new Vector3(xPosBonus, yPosBonus, zPosBonus);

    	GameObject cloneBonus;

    	switch(bonusType) {
    		case 0:
    			cloneBonus = Instantiate(firstBonus, PosBonus, Quaternion.identity);
    			listBonus.Add(cloneBonus);
    			break;

    		case 1:
    			cloneBonus = Instantiate(secondBonus, PosBonus, Quaternion.identity);
    			listBonus.Add(cloneBonus);
    			break;

    		case 2:
    			cloneBonus = Instantiate(thirdBonus, PosBonus, Quaternion.identity);
    			listBonus.Add(cloneBonus);
    			break;

    		case 3:
    			cloneBonus = Instantiate(fourthBonus, PosBonus, Quaternion.identity);
    			listBonus.Add(cloneBonus);
    			break;
    	}
    }
}
