using UnityEngine;
using System.Collections;

public class CubeCreate : MonoBehaviour {

    public GameObject _ObjCreat;
    private Vector3 _CreatPosition;
    private GameObject _ObjClone;
    public static CubeCreate _instance = null;
	// Use this for initialization
	void Start () {
        _CreatPosition = new Vector3();
        _CreatPosition.z = 10f;
        CreatNewCube();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void CreatNewCube()
    {
        _CreatPosition.x = Random.Range(-5f, 5f);
        _CreatPosition.y = Random.Range(-5f, 5f);
        _CreatPosition.z = 10f;
        Instantiate(_ObjCreat, _CreatPosition, Quaternion.identity);
    }
}
