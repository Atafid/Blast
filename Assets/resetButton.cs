using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resetButton : MonoBehaviour
{
	//the script for the score variable
	public EnemyCollision enemyScript;

	//the script for the game over variable
	public PlayerCollision playerScript;

	//script to have the list of meteore 
	public TirEnemyApparition scriptList;

	//the transform of the player
	public Transform playerTransform;

	//the transform for ball positon
	public Transform ballTransform;
	public Transform leftBallTransform;
	public Transform rightBallTransform;

	//the start position of the player
	public Vector3 playerPos;

	//the start position of the balls
	public Vector3 ballPos;
	public Vector3 leftBallPos;
	public Vector3 rightBallPos;

	//the obstacles transform
	public Transform obstacleTransform;
	public Transform obstacleOne;
	public Transform obstacleTwo;
	public Transform obstacleThree;
	public Transform obstacleFour;

	//the higscore
	public int highscore;

	//the highscoreText
	public Text higscoreText;

	//the game over text
	public Text gameOver;

	//the menu back
	public GameObject background;

	//the home button
	public GameObject homeButton;

	//the button for buyed bonus
	public GameObject bonusThreeButton;
	public GameObject bonusFourButton;

	//script to save and load data
	public saveAndLoadInt saveAndLoadScript;

    // Start is called before the first frame update
    void Start()
    {
    	//get the player and balls positions at the begin of the game
    	playerPos = playerTransform.position;
    	ballPos = ballTransform.position;
    	leftBallPos = leftBallTransform.position;
    	rightBallPos = rightBallTransform.position;

        //get the text for the highscore
        higscoreText = GameObject.Find("Highscore").GetComponent<Text>();

        //get component of the game over text and make it invisible
		gameOver = GameObject.Find("Game Over").GetComponent<Text>();

		//get the script file
		saveAndLoadScript = GameObject.Find("Ground").GetComponent<saveAndLoadInt>();

		//load the highscore
		highscore = saveAndLoadScript.loadInt(highscore, "highscore.blast");

		//text = invisible
		higscoreText.enabled = false;
		gameOver.enabled = false;
		background.SetActive(false);
		homeButton.SetActive(false);

		//the button is invisible and untouchable
		this.gameObject.GetComponent<Renderer>().enabled = false;
		this.gameObject.GetComponent<Collider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
    	//if the game is over, actualize the highscore
        if(playerScript.isGameOver) {
        	if(highscore <= enemyScript.score) {
        		highscore = enemyScript.score;
        	}


	        //display the highscore
	        higscoreText.text = "Highscore : " + highscore;

	        //text = visible
			higscoreText.enabled = true;
			gameOver.enabled = true;
			background.SetActive(true);
			homeButton.SetActive(true);

			//the button is visible and touchable
			this.gameObject.GetComponent<Renderer>().enabled = true;
			this.gameObject.GetComponent<Collider>().enabled = true;

			//save the highscore
			saveAndLoadScript.saveInt(highscore, "highscore.blast");

			//save the money
			saveAndLoadScript.saveInt(enemyScript.money, "money.blast");
        }
    }

    //if the button is pressed
    public void OnTouchDown() {
    	//destroy all meteore on the screen
    	foreach(GameObject meteore in scriptList.listMeteore) {
    		Destroy(meteore);
    	}

    	//destroy all bonus on the screen
    	foreach(GameObject bonus in scriptList.listBonus) {
    		Destroy(bonus);
    	}

    	//reinitialize the player and balls positions and rotations
    	playerTransform.position = playerPos;
    	playerTransform.rotation = Quaternion.identity;

    	ballTransform.position = ballPos;
    	ballTransform.rotation = Quaternion.identity;
    	leftBallTransform.position = leftBallPos;
    	leftBallTransform.rotation = Quaternion.identity;
    	rightBallTransform.position = rightBallPos;
    	rightBallTransform.rotation = Quaternion.identity;

    	//reinitialize the rotation of the obstacle
    	obstacleTransform.rotation = Quaternion.Euler(90, 0, 0);
    	obstacleOne.rotation = Quaternion.Euler(90, 0, 0);
    	obstacleTwo.rotation = Quaternion.Euler(90, 0, 0);
    	obstacleThree.rotation = Quaternion.Euler(90, 0, 0);
    	obstacleFour.rotation = Quaternion.Euler(90, 0, 0);

    	//reinitialize the number of enemies killed
    	enemyScript.killEnemies = 0;

    	//reinitialize the score
    	enemyScript.score = 0;

    	//if we have buyed bonus, display the buttons
		if(playerScript.buyBonusThree!=0) {
			bonusThreeButton.SetActive(true);
		}

		if(playerScript.buyBonusFour!=0) {
			bonusFourButton.SetActive(true);
		}

    	//text = invisible
		higscoreText.enabled = false;
		gameOver.enabled = false;
		background.SetActive(false);
		homeButton.SetActive(false);

		//the button is invisible and untouchable
		this.gameObject.GetComponent<Renderer>().enabled = false;
		this.gameObject.GetComponent<Collider>().enabled = false;

		//the game is active
		playerScript.isGameOver = false;
		Time.timeScale = 1;
    }
}
