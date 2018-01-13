using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {

    public GameObject track;
    public GameObject wall;
    private Vector3 pos;
    public int dist;

	// Use this for initialization
	void Start () {
        
    }

    public void spawn()
    {
        Debug.Log(1234);
        pos = track.transform.position;
        Instantiate(wall, new Vector3(pos.x, 5, pos.z + dist), Quaternion.identity);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
