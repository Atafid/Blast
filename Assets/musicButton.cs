using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicButton : MonoBehaviour
{
    //to know if music is activate
    public bool isMusic;

    void OnTouchDown() {
    	isMusic = !isMusic;
    	Debug.Log(isMusic);
    }
}
