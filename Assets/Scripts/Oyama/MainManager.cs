using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour {

    [SerializeField]
    private Text _textCountdown;

    public GameObject stage;

    public float stageSpeed;

    float addSpeedPosX = -20;

    public GameObject goalPoint;
    public SpriteRenderer fadeSprite;

    public OyamaPlayer Player;

    public GameObject GameOverText;

    float[] RandomY = { 1, -1, -3 };

    public GameObject behindObj, middleObj, frontObj;

    public GameObject GameOverObj;
    GameObject gameoverCorsol;

    bool gameoverFlag = false;

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

        Player.enabled = false;
        gameoverCorsol = GameOverObj.transform.FindChild("カーソル").gameObject;
        GameOverObj.SetActive(false);

        _textCountdown.text = "";

        StartCoroutine("CountDown");

    }

    // Update is called once per frame
    void Update()
    {
        if (_textCountdown.gameObject.active) return;
        else Player.enabled = true;

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
                    if (gameoverFlag == false)
                    {
                        gameoverFlag = true;
                        Invoke("GameOverSelect", 1);
                    }
                }

                if (GameOverObj.active)
                {
                    if (Input.GetKeyDown(KeyCode.UpArrow))
                    {

                        gameoverCorsol.transform.position = new Vector3(0, -2, 0);

                    }

                    if (Input.GetKeyDown(KeyCode.DownArrow))
                    {
                        gameoverCorsol.transform.position = new Vector3(0, -4, 0);
                    }

                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        switch ((int)gameoverCorsol.transform.position.y)
                        {
                            //リトライ
                            case -2:
                                SceneManager.LoadScene(1);
                                break;

                            //タイトル
                            case -4:
                                SceneManager.LoadScene(0);
                                break;

                        }
                    }
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

    void GameOverSelect()
    {
        GameOverObj.SetActive(true);
    }

    IEnumerator CountDown()
    {
        _textCountdown.gameObject.SetActive(true);


        _textCountdown.text = "3";
        yield return new WaitForSeconds(1.0f);


        _textCountdown.text = "2";
        yield return new WaitForSeconds(1.0f);


        _textCountdown.text = "1";
        yield return new WaitForSeconds(1.0f);


        _textCountdown.text = "GO!";
        yield return new WaitForSeconds(1.0f);

        _textCountdown.text = "";
        _textCountdown.gameObject.SetActive(false);

    }
}
