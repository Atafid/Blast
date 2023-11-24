using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vibrateButton : MonoBehaviour
{
    //to know if there is vibration
    public bool isVibration;

    void OnTouchDown() {
    	isVibration = !isVibration;
    	Debug.Log(isVibration);
    }
}
