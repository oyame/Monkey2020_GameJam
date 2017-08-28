using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour {

    public SpriteRenderer fadeSprite;

    bool startFlag = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space) && startFlag == false)
        {
            startFlag = true;
        }

        if (startFlag)
        {
            fadeSprite.color += new Color(0, 0, 0, 0.01f);

            //フェードがかかったらメインへ遷移
            if (fadeSprite.color.a > 1)
            {
                SceneManager.LoadScene(1);
            }
        }

	}
}
