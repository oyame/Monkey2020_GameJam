using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c_Player : MonoBehaviour {


    public SpriteRenderer LeftLegRenderer;
    public SpriteRenderer RightLegRenderer;

    float sumTime;

    float move = 0.2f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        sumTime += Time.deltaTime * 4;

        LeftLegRenderer.gameObject.transform.eulerAngles = new Vector3(0, 0, Mathf.Sin(180 * sumTime * Mathf.Deg2Rad) * 360);
        RightLegRenderer.gameObject.transform.eulerAngles = new Vector3(0, 0, Mathf.Sin(-180 * sumTime * Mathf.Deg2Rad) * 360);
        if (transform.eulerAngles.y == 180)
        {
            move = -0.2f;
        }

        transform.position += new Vector3(move, 0, 0);
    }
}
