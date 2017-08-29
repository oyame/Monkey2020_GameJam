using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearManager : MonoBehaviour {

    public SpriteRenderer fadeSprite;

    public GameObject c_Player;

	// Use this for initialization
	void Start () {

        fadeSprite.color = new Color(1, 1, 1, 1);
    }
	
	// Update is called once per frame
	void Update () {
        fadeSprite.color -= new Color(0, 0, 0, 0.01f);

        int oppai = Random.Range(0, 15);

        //遊び
        if (oppai == 1)
        {
            GameObject unko = Instantiate(c_Player, new Vector3(11, Random.Range(0, -9), 0), Quaternion.Euler(0,180,0));
            Destroy(unko, 5);
        }
        else if(oppai == 2) {
            GameObject unko = Instantiate(c_Player, new Vector3(-11, Random.Range(0, -9), 0), Quaternion.identity);
            Destroy(unko, 5);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Title");
        }

    }
}
