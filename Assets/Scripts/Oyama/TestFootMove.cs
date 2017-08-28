using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFootMove : MonoBehaviour {

    public float maxRotateNum;

    public float addRotateNum;

    float unko = 0;

	// Use this for initialization
	void Start () {
        unko = transform.eulerAngles.z;
    }
	
	// Update is called once per frame
	void Update () {

        unko += addRotateNum;

        transform.eulerAngles = new Vector3(0, 0, Mathf.Sin(unko * Mathf.Deg2Rad) * 50);

        
	}
}
