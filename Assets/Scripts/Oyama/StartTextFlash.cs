using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTextFlash : MonoBehaviour {

    SpriteRenderer mySpriteRenderer;

	// Use this for initialization
	void Start () {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

        mySpriteRenderer.color = new Color(1, 1, 1, Mathf.PingPong(Time.time, 1));

	}
}
