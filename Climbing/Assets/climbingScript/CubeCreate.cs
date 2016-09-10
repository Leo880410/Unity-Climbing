using UnityEngine;
using System.Collections;

public class CubeCreate : MonoBehaviour {

    public GameObject _ObjCreat;
    private Vector3 _CreatPosition;
    private GameObject _ObjClone;
    public static CubeCreate _instance = null;

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

	// Use this for initialization
	void Start () {
        _CreatPosition = new Vector3();
        _CreatPosition.z = 20f;
        CreatNewCube();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void CreatNewCube()
    {
        _CreatPosition.x = Random.Range(-50f, 10f);
        _CreatPosition.y = Random.Range(-10f, 30f);
        _CreatPosition.z = 20f;
        Instantiate(_ObjCreat, _CreatPosition, Quaternion.identity);
        //Debug.Log("X = " + _CreatPosition.x + "Y = " + _CreatPosition.y);
    }
}
