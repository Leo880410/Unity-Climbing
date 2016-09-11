using UnityEngine;
using System.Collections;

public class ScreenSet : MonoBehaviour {

    float _screenWidth;
    float _screenHeight;

	// Use this for initialization
	void Start () {
        _screenWidth = Screen.width;
        _screenHeight = Screen.height;
        Debug.Log("screenwidth = " + _screenWidth + " screenH = " + _screenHeight);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("mouse ScreenToWorld  = " + Camera.main.ScreenToWorldPoint(Input.mousePosition));
            Debug.Log("mousePosition  = " + Input.mousePosition);
        }

	}

    public float getScreenWidth()
    {
        return _screenWidth;
    }

    public float getScreenHeight()
    {
        return _screenHeight;
    }
}
