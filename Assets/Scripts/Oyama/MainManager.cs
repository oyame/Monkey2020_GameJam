using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour {

    public GameObject stage;

    public float stageSpeed;

    float addSpeedPosX = -20;

    public GameObject goalPoint;
    public SpriteRenderer fadeSprite;

    public OyamaPlayer Player;

    public GameObject GameOverText;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        stage.transform.position -= new Vector3(stageSpeed, 0, 0);

        if (stage.transform.position.x < addSpeedPosX)
        {
            stageSpeed += 0.01f;
            addSpeedPosX -= 20;
        }

        //ゲームオーバー
        if(Player.HP <= 0 || Player.FireHP == 0)
        {
            Player.enabled = false;
            stageSpeed = 0;

            fadeSprite.color += new Color(-1, -1, -1, 0.01f);

            if (fadeSprite.color.a > 1)
            {
                if (GameOverText.transform.position.y < 0)
                {
                    GameOverText.transform.position += new Vector3(0, 0.2f, 0);
                }
                else {
                    Invoke("BackTitle", 1);
                }
            }
        }

        //クリア
        if (Player.gameObject.transform.position.x > goalPoint.transform.position.x)
        {
            Player.enabled = false;
            stageSpeed = 0.01f;
            fadeSprite.color += new Color(0, 0, 0, 0.01f);

            if (fadeSprite.color.a > 1)
            {
                SceneManager.LoadScene(2);
            }
        }
    }

    void BackTitle()
    {
        SceneManager.LoadScene(0);
    }
}
