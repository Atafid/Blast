using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

//it is possible to save and load data
[System.Serializable]
public class EnemyCollision : MonoBehaviour
{
	//the current score
	public int score;

	//the current money
	public int money;

	//the cuurent life of the enemy
	public int life;

	//to display the score
	public Text scoreText;

	//to display the money
	public Text moneyText;

	//the differents lives appearances
	public Rigidbody threeLife;
	public Rigidbody twoLife;
	public Rigidbody oneLife;

	Rigidbody clone;

	//the levels
	public int currentLevel;
	public int nextLevel;

	public Text currentLevelText;
	public Text nextLevelText;

	public int enemyToKill;
	public int killEnemies;

	public float percentDown;
	public Text percentDownText;

	//the position of the lives
	public Vector3 posLife = new Vector3(0.0f, 3.5f, -5.5f);

	//script to save and load data
	public saveAndLoadInt saveAndLoadScript;

    // Start is called before the first frame update
    void Start()
    {
        //get the texts components
		scoreText = GameObject.Find("Score").GetComponent<Text>();
		moneyText = GameObject.Find("Money").GetComponent<Text>();
		currentLevelText = GameObject.Find("currentLevel").GetComponent<Text>();
		nextLevelText = GameObject.Find("nextLevel").GetComponent<Text>();
		percentDownText = GameObject.Find("percentDown").GetComponent<Text>();

		//get the script file
		saveAndLoadScript = GameObject.Find("Ground").GetComponent<saveAndLoadInt>();

		//load the money
		money = saveAndLoadScript.loadInt(money, "money.blast");

		//random life
		life = Random.Range(1, 4);

		//instantiate the lives on the scene in function of the number of lives
		switch(life) {
			case 3:
				clone = Instantiate(threeLife, posLife, Quaternion.identity) as Rigidbody;
				break;

			case 2:
				clone = Instantiate(twoLife, posLife, Quaternion.identity) as Rigidbody;
				break;

			case 1:
				clone = Instantiate(oneLife, posLife, Quaternion.identity) as Rigidbody;
				break;
		}

		//the level is load
		currentLevel = saveAndLoadScript.loadInt(currentLevel, "currentLevel.blast");

		nextLevel = currentLevel+1;

		//the enemy to kill are set to 1
		enemyToKill = currentLevel;
		killEnemies = 0;
    }

    //to know if we collide something
    void OnCollisionEnter(Collision collision) {
    	//if we collide the enemy
    	if(collision.collider.name=="Ball(Clone)") {
    		//elimine the velocity effect of the collision
    		this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

    		//replace the object
    		//this.transform.position = Vector3.up*1.5f;

    		//update the number of lives on the screen
    		switch(life) {
				case 3:
					Destroy(GameObject.Find("threeLife(Clone)"));
					clone = Instantiate(twoLife, posLife, Quaternion.identity) as Rigidbody;
					break;

				case 2:
					Destroy(GameObject.Find("twoLife(Clone)"));
					clone = Instantiate(oneLife, posLife, Quaternion.identity) as Rigidbody;
					break;

				case 1:
					Destroy(GameObject.Find("oneLife(Clone)"));
					break;
			}

			//decrease the life
    		life -= 1;
    	}
    }

    // Update is called once per frame
    void Update()
    {
        //display the current score at each frame
        scoreText.text = "Score : " + score;
        moneyText.text = "Money : " + money;

        //display the variables of the level at each frame
        currentLevelText.text = "From : " + currentLevel;
        nextLevelText.text = "To : " + nextLevel;
        percentDownText.text = killEnemies + " / " + enemyToKill;

        //if the enemy is dead
        if(life==0) {
			//it respawn in the sky, without velocity
    		this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
    		this.transform.position = Vector3.up*10f;

    		//inrcrease the score
    		score ++;

    		//increase the money
    		money += Random.Range(1, 4);

    		//new random life
    		life = Random.Range(1, 4);

    		//instantiate the lives on the scene in function of the number of lives
			switch(life) {
				case 3:
					clone = Instantiate(threeLife, posLife, Quaternion.identity) as Rigidbody;
					break;

				case 2:
					clone = Instantiate(twoLife, posLife, Quaternion.identity) as Rigidbody;
					break;

				case 1:
					clone = Instantiate(oneLife, posLife, Quaternion.identity) as Rigidbody;
					break;
			}

			//we have killed another enemy
			killEnemies++;
			percentDown = (killEnemies/enemyToKill*100f);
        }

        //to change of level, if we have killed all enemies
        if(killEnemies==enemyToKill) {
        	//update the variables
        	currentLevel++;
        	nextLevel++;

        	enemyToKill = currentLevel;
        	killEnemies = 0;
        	percentDown = 0;

        	//save the variable
        	saveAndLoadScript.saveInt(currentLevel, "currentLevel.blast");
        }
    }
}

