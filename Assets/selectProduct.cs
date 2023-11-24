using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectProduct : MonoBehaviour
{
	//the script to have the selected product
	public shopGestion shopScript;

	//the effects variables
	public MeshFilter playerMesh;
	public MeshCollider playerCollider;
	public Transform playerTransform;

	public MeshFilter enemyMesh;
	public MeshCollider enemyCollider;
	public Transform enemyTransform;

    // Start is called before the first frame update
    void Start()
    {
    	//get components
        shopScript = GameObject.Find("shopMenu").GetComponent<shopGestion>();

        playerMesh = GameObject.Find("Player").GetComponent<MeshFilter>();
        playerCollider = GameObject.Find("Player").GetComponent<MeshCollider>();
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();

        enemyMesh = GameObject.Find("Enemy").GetComponent<MeshFilter>();
        enemyCollider = GameObject.Find("Enemy").GetComponent<MeshCollider>();
        enemyTransform = GameObject.Find("Enemy").GetComponent<Transform>();
    }

    void OnTouchDown() {
    	//different effect in function of the selected product effect
    	switch(shopScript.selectProduct.GetComponent<productTouch>().effect) {
    		//if the effect is a skin for the player
    		case "customPlayer":
    			//change the appearance of the player
    			playerMesh.sharedMesh = shopScript.selectProduct.GetComponent<productTouch>().playerSkin.GetComponent<MeshFilter>().sharedMesh;
    			playerCollider.sharedMesh = shopScript.selectProduct.GetComponent<productTouch>().playerSkin.GetComponent<MeshCollider>().sharedMesh;
    			playerTransform.localScale = shopScript.selectProduct.GetComponent<productTouch>().playerSkin.GetComponent<Transform>().localScale;
    			break;

    		//if the effect is a skin for the enemy
    		case "customEnemy":
    			//change the appearance of the enemy
    			enemyMesh.sharedMesh = shopScript.selectProduct.GetComponent<productTouch>().enemySkin.GetComponent<MeshFilter>().sharedMesh;
    			enemyCollider.sharedMesh = shopScript.selectProduct.GetComponent<productTouch>().enemySkin.GetComponent<MeshCollider>().sharedMesh;
    			enemyTransform.localScale = shopScript.selectProduct.GetComponent<productTouch>().enemySkin.GetComponent<Transform>().localScale;
    			break;

    		//if the effect is to buy a life
    		case "buyLife":
    			shopScript.selectProduct.GetComponent<productTouch>().playerScript.lifePlayer++;
    			Debug.Log(shopScript.selectProduct.GetComponent<productTouch>().playerScript.lifePlayer);
    			break;

    		//if the effect is to buy a bonus three
    		case "buyBonusThree":
    			shopScript.selectProduct.GetComponent<productTouch>().playerScript.buyBonusThree++;
    			Debug.Log(shopScript.selectProduct.GetComponent<productTouch>().playerScript.buyBonusThree);
    			break;

    		//if the effect is to buy a bonus four
    		case "buyBonusFour":
    			shopScript.selectProduct.GetComponent<productTouch>().playerScript.buyBonusFour++;
    			Debug.Log(shopScript.selectProduct.GetComponent<productTouch>().playerScript.buyBonusFour);
    			break;

    	}
    }
}
