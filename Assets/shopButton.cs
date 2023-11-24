using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shopButton : MonoBehaviour
{
	//the menu
	public GameObject shopMenu;

	//the text to make invisible
	public Text startText;

	//pages of the menu
	public GameObject pageOne;
	public GameObject pageTwo;
	public GameObject pageThree;
	public GameObject pageFour;

	//the buy button
	public GameObject buyButton;

	//the select button
	public GameObject selectButton;

    // Start is called before the first frame update
    void Start()
    {
    	//get the components
        shopMenu = GameObject.Find("shopMenu");
        startText = GameObject.Find("Start").GetComponent<Text>();
        pageOne = GameObject.Find("shopOne");
        pageTwo = GameObject.Find("shopTwo");
        pageThree = GameObject.Find("shopThree");
        pageFour = GameObject.Find("shopFour");
        buyButton = GameObject.Find("buyButton");
        selectButton = GameObject.Find("selectButton");

        //the menu is first inactive
        shopMenu.SetActive(false);
        pageOne.SetActive(false);
        pageTwo.SetActive(false);
        pageThree.SetActive(false);
        pageFour.SetActive(false);

        buyButton.SetActive(false);
        selectButton.SetActive(false);
    }

    void OnTouchDown() {
    	shopMenu.SetActive(true);
    	shopMenu.GetComponent<Renderer>().material.color = GameObject.Find("shopWindowsOne").GetComponent<Renderer>().material.color;
    	pageOne.SetActive(true);
    	buyButton.SetActive(false);
    	selectButton.SetActive(false);
    	startText.enabled = false;
    }
}
