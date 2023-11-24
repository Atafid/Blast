using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quitOption : MonoBehaviour
{
	//the script to display the option menu
	public openOption optionScript;

    void OnTouchDown() {
    	optionScript.optionMenu.SetActive(false);
    	optionScript.startText.enabled = true;
    }
}
