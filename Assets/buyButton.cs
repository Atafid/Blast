using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buyButton : MonoBehaviour
{
	//the shop script
	public shopGestion shopScript;

	//the script for the money
	public EnemyCollision moneyScript;

	//the select button
	public GameObject selectButton;

    // Start is called before the first frame update
    void Start()
    {
        shopScript = GameObject.Find("shopMenu").GetComponent<shopGestion>();
        moneyScript = GameObject.Find("Enemy").GetComponent<EnemyCollision>();
        selectButton = GameObject.Find("selectButton");
    }

    //if we touch the button
    void OnTouchDown() {
    	//if we have the money to buy the product, buy it
    	if(shopScript.selectProduct.GetComponent<productTouch>().price <= moneyScript.money) {
    		//retire the money
    		moneyScript.money -= shopScript.selectProduct.GetComponent<productTouch>().price;

    		//the product is buyed
    		shopScript.selectProduct.GetComponent<productTouch>().isBuy = true;

    		//the button = invisible
    		this.gameObject.SetActive(false);

    		switch(shopScript.selectProduct.GetComponent<productTouch>().effect) {
    			case "customPlayer":
    				selectButton.SetActive(true);
    				break;
    		}
    	}
    }
}
