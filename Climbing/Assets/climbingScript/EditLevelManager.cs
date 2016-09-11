using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EditLevelManager : MonoBehaviour {

    public EditLevelCreatObject _EditCreatManager;
    public Dropdown _LevelDropDown;
    public Dropdown _StateDropDown;
    public Dropdown _ObjDropDown;

    private int nowLevel;
    private int nowState;
    private string nowAddThing;
    const int _rightLimitPoint = 1010;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Mouse0) && Input.mousePosition.x <= _rightLimitPoint)
        {
            if (_ObjDropDown.options[_ObjDropDown.value].text == "障礙物")
            {
                _EditCreatManager.CreatObstacle(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            }
            else if (_ObjDropDown.options[_ObjDropDown.value].text == "目標物")
            {
                _EditCreatManager.CreatTarget(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            }
            Debug.Log(_LevelDropDown.options[_LevelDropDown.value].text);
            Debug.Log(_StateDropDown.options[_StateDropDown.value].text);
        }
	}
}
