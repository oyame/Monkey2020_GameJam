using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 nowPos = transform.position;

        nowPos.x -= 0.1f;

        transform.position = nowPos;
    }
}
