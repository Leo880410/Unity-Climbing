using UnityEngine;
using System.Collections;

public class CubeDestory : MonoBehaviour {

    public GameObject CreatManagerObject;
    private CubeCreate CreatManager;

	// Use this for initialization
	void Start () {
        CreatManager = CreatManagerObject.GetComponent<CubeCreate>();
	}
	
	// Update is called once per frame
	void Update () {

	}
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "HandLeft" || collision.gameObject.tag =="HandRight")
        {
            DestoryAndCreat();
        }
    }
    void DestoryAndCreat()
    {
        CreatManager.CreatNewCube();
        Destroy(gameObject);
    }
}
