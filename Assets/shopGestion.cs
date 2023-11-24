using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopGestion : MonoBehaviour
{
	//the selected Product
	public GameObject selectProduct;

	//the color of selected product
	public Color selectColor;

	//the buy button
	public GameObject buyButton;

	//the select button
	public GameObject selectButton;

	void Start() {
		buyButton = GameObject.Find("buyButton");
		selectButton = GameObject.Find("selectButton");
	}

	void Update() {
		//if the select product is assigned
		if(selectProduct != null) {
			//if the product is not already buyed
			if(!selectProduct.GetComponent<productTouch>().isBuy) {
				//the button to buy is visible
				buyButton.SetActive(true);
				selectButton.SetActive(false);
			}

			else {
				buyButton.SetActive(false);
				selectButton.SetActive(true);
			}
		}
	}
}
