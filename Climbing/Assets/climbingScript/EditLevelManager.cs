using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EditLevelManager : MonoBehaviour {

    public EditLevelCreatObject _EditCreatManager;
    public Dropdown _LevelDropDown;
    public Dropdown _StateDropDown;
    public Dropdown _ObjDropDown;
    const int levelSet = 3;
    const int stateSet = 50;

    //關卡
    //private int nowLevel;
    //關卡中的第幾階段
    //private int nowState;

    //允許使用者點擊的最右邊x軸座標，避免點選UI 誤觸function
    const int _rightLimitPoint = 1010;


    private int[] _objCount = new int[levelSet];

    //state的vector3座標陣列
    private Vector3[][] _obstaclePosition = new Vector3[levelSet][];
    //目前關卡中 target物件的座標
    private Vector3[] _targetObjPosition = new Vector3[levelSet];

    void initialization()
    {
        for (int i = 0; i < levelSet; i++)
        {
            _obstaclePosition[i] = new Vector3[stateSet];
        }
    }

	// Use this for initialization
	void Start () {

        initialization();
	}
	
	// Update is called once per frame
	void Update () {
        int level = int.Parse(_LevelDropDown.options[_LevelDropDown.value].text);

        if (Input.GetKeyDown(KeyCode.Mouse0) && Input.mousePosition.x <= _rightLimitPoint)
        {
            //Debug.Log(_LevelDropDown.options[_LevelDropDown.value].text);
            //Debug.Log(int.Parse(_StateDropDown.options[_StateDropDown.value].text));
            if (_ObjDropDown.options[_ObjDropDown.value].text == "障礙物")
            {
                _EditCreatManager.CreatObstacle(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                _obstaclePosition[level][_objCount[level]] = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                _objCount[level]++;
            }
            else if (_ObjDropDown.options[_ObjDropDown.value].text == "目標物")
            {
                _EditCreatManager.CreatTarget(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                _targetObjPosition[level] = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }

        }
	}

    //按下Save按鈕 將物件座標寫檔
    public void SaveButtonClick()
    {
        int level = int.Parse(_LevelDropDown.options[_LevelDropDown.value].text);
        string fileName = Application.dataPath + "/Level" + level + ".txt";
        string space = " ";
        Debug.Log("fileName = " + fileName);
        using (System.IO.StreamWriter sw = new System.IO.StreamWriter(fileName))
        {
            for (int i = 0; i < _objCount[level]; i++)
            {
                if (i < _objCount[level] - 1)
                    space = " ";
                else
                {
                    space = "\r\n";
                }
                sw.Write(_obstaclePosition[level][i] + space);
                Debug.Log("write = " + _obstaclePosition[level][i] + space);
            }
            sw.WriteLine(_targetObjPosition[level]);
            Debug.Log("_targetObjPosition = " + _targetObjPosition[level]);
            sw.Close();
            sw.Dispose();
        }
    }
}
