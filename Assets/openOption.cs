using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class openOption : MonoBehaviour
{
	//the option menu
	public GameObject optionMenu;

	//the text to make invisible
	public Text startText;

    // Start is called before the first frame update
    void Start()
    {
        //get the components
        optionMenu = GameObject.Find("optionMenu");
        startText = GameObject.Find("Start").GetComponent<Text>();

        //the menu is first inactive
        optionMenu.SetActive(false);
    }


    void OnTouchDown() {
    	//the menu is open
    	optionMenu.SetActive(true);
    	startText.enabled = false;
    }
}
