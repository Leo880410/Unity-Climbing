using UnityEngine;
using System.Collections;

public class EditLevelCreatObject : MonoBehaviour {

    public GameObject _ObjObstacle;
    public GameObject _ObjTarget;

    private ArrayList _ObsList;
    private GameObject _ObjTargetInstance;
    private bool isTargetSet;
	// Use this for initialization
	void Start () {
        _ObsList = new ArrayList();
        isTargetSet = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void CreatObstacle(Vector3 position)
    {
        _ObsList.Add(Instantiate(_ObjObstacle, position, Quaternion.identity) as GameObject);
    }

    public void CreatTarget(Vector3 position)
    {
        if (!isTargetSet)
        {
            _ObjTargetInstance = Instantiate(_ObjTarget, position, Quaternion.identity) as GameObject;
            isTargetSet = true;
        }
    }

    public void ClearAllObj()
    {
        for (int i = 0; i < _ObsList.Count; i++)
        {
            Destroy((GameObject)_ObsList[i]);
        }
        Destroy(_ObjTargetInstance);
        isTargetSet = false;
    }
}
