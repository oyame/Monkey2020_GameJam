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

    float[] RandomY = { 1, -1, -3 };

    public GameObject behindObj, middleObj, frontObj;

    void Awake()
    {
        int n = 20;

        while (n > 0)
        {
            n--;
            //レーンをランダムにY軸を移動させたい
            int i = Random.Range(0, 3);

            float tmp = RandomY[i];
            RandomY[i] = RandomY[0];
            RandomY[0] = tmp;

        }

        behindObj.transform.position = new Vector3(-7.5f, RandomY[0], 0);
        middleObj.transform.position = new Vector3(-7.5f, RandomY[1], 0);
        frontObj.transform.position = new Vector3(-7.5f, RandomY[2], 0);

        //for (int i = 0; i < RandomY.Length; i++)
        //{
        //    Debug.Log(RandomY[i]);
        //}
    }

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
