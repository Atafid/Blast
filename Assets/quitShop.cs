using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quitShop : MonoBehaviour
{
	//the script to say it is closed
	public shopButton shopScript;

	//the scipt to handle the product selected
	public shopGestion gestionScript;

	//the default color of the product
	public Color productColor;

    // Start is called before the first frame update
    void Start()
    {
    	//get components
        shopScript = GameObject.Find("shopButton").GetComponent<shopButton>();
        gestionScript = GameObject.Find("shopMenu").GetComponent<shopGestion>();
    }

    void OnTouchDown() {
    	//elements of the shop = invisible
    	shopScript.shopMenu.SetActive(false);
    	shopScript.pageOne.SetActive(false);
    	shopScript.pageTwo.SetActive(false);
    	shopScript.pageThree.SetActive(false);
    	shopScript.pageFour.SetActive(false);
    	shopScript.startText.enabled = true;

    	if(gestionScript.selectProduct != null) {
			//selected product : color = normal
	    	gestionScript.selectProduct.GetComponent<Renderer>().material.color = productColor;
	    	gestionScript.selectProduct = null;
    	}
    }
}
