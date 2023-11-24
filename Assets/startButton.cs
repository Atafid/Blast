using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startButton : MonoBehaviour
{
	//the different elements of the menu
	public GameObject background;

	public Text startText;

	public resetButton resetScript;

	//the script for the buyed bonus
	public PlayerCollision playerScript;

	//the elements invisible
	public Text scoreText;

	public Text lvlText;

	public Text percentDownText;

	public Text nextLvlText;

	public Text moneyText;

	public Text gameOverText;

	public Text highScoreText;

	public GameObject bonusThreeButton;
	public GameObject bonusFourButton;

    // Start is called before the first frame update
    public void Start()
    {
    	//game is not start
        Time.timeScale = 0;

        playerScript = GameObject.Find("Player").GetComponent<PlayerCollision>();

        //get component text
        startText = GameObject.Find("Start").GetComponent<Text>();
        scoreText = GameObject.Find("Score").GetComponent<Text>();
		moneyText = GameObject.Find("Money").GetComponent<Text>();
		lvlText = GameObject.Find("currentLevel").GetComponent<Text>();
		nextLvlText = GameObject.Find("nextLevel").GetComponent<Text>();
		percentDownText = GameObject.Find("percentDown").GetComponent<Text>();
		gameOverText = GameObject.Find("Game Over").GetComponent<Text>();
		highScoreText = GameObject.Find("Highscore").GetComponent<Text>();

		//text = invisible
		scoreText.enabled = false;
		moneyText.enabled = false;
		lvlText.enabled = false;
		nextLvlText.enabled = false;
		percentDownText.enabled = false;
		gameOverText.enabled = false;
		highScoreText.enabled = false;
    }

    void OnTouchDown() {
    	//text = invisible
    	startText.enabled = false;
    	background.SetActive(false);
    	this.gameObject.SetActive(false);

    	//text visible
    	scoreText.enabled = true;
		moneyText.enabled = true;
		lvlText.enabled = true;
		nextLvlText.enabled = true;
		percentDownText.enabled = true;

		//if we have buyed bonus, display the buttons
		if(playerScript.buyBonusThree!=0) {
			bonusThreeButton.SetActive(true);
		}

		else {
			bonusThreeButton.SetActive(false);
		}

		if(playerScript.buyBonusFour!=0) {
			bonusFourButton.SetActive(true);
		}

		else {
			bonusFourButton.SetActive(false);
		}

    	//reset the game
    	resetScript.OnTouchDown();

    	//game start
    	Time.timeScale = 1;
    }
}
