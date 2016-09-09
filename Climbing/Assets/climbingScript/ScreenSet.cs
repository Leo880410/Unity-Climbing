using UnityEngine;
using System.Collections;

public class ScreenSet : MonoBehaviour {

	// Use this for initialization
	void Start () {
        float screenwidth;
        float screenH;
        screenwidth = Screen.width;
        screenH = Screen.height;
        Debug.Log("screenwidth = " + screenwidth + " screenH = " + screenH);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
