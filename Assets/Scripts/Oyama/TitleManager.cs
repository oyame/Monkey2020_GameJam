using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour {

    public SpriteRenderer fadeSprite;

    public GameObject setumei;

    bool startFlag = false;

	// Use this for initialization
	void Start () {
        setumei.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {


        if (Input.GetKeyDown(KeyCode.Space) && setumei.active == true && startFlag == false)
        {

            GetComponent<AudioSource>().Play();
            startFlag = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && setumei.active == false)
        {
            setumei.SetActive(true);
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
