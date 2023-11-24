using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class productTouch : MonoBehaviour
{
	//the script which handle the shop
	public shopGestion shopScript;

	//the product is buyed or not
	public bool isBuy;

	//the price of the product
	public int price;

	//the effect of the product
	public string effect;

	//the effects variable
	public GameObject playerSkin;
	public GameObject enemySkin;

	//the script for the life variable
	public PlayerCollision playerScript;

	void Start() {
		//get components
		shopScript = GameObject.Find("shopMenu").GetComponent<shopGestion>();
		playerScript = GameObject.Find("Player").GetComponent<PlayerCollision>();
	}

	void OnTouchDown() {
		if(shopScript.selectProduct != null) {
			//make the previous selected product unselected
			shopScript.selectProduct.GetComponent<Renderer>().material.color = this.gameObject.GetComponent<Renderer>().material.color;
		}

		//this product is selected
		shopScript.selectProduct = this.gameObject;

		shopScript.selectProduct.GetComponent<Renderer>().material.color = shopScript.selectColor;
	}
}
