using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showWindows : MonoBehaviour
{
	//the shop menu
	public GameObject shopMenu;

	//the page of the menu
	public GameObject shopPage;

	//the other pages
	public GameObject pageOne;
	public GameObject pageTwo;
	public GameObject pageThree;

    // Start is called before the first frame update
    void Start()
    {
        //get components
        shopMenu = GameObject.Find("shopMenu");
    }

    void OnTouchDown() {
    	//change the shop color
    	shopMenu.GetComponent<Renderer>().material.color = this.GetComponent<Renderer>().material.color;
    	shopPage.SetActive(true);
    	
    	pageOne.SetActive(false);
    	pageTwo.SetActive(false);
    	pageThree.SetActive(false);
    }
}
