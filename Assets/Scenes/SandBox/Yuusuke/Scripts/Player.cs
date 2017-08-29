using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    [SerializeField]
    private Text _textCountdown;

    public int HP;      //スタミナ
    public int FireHP;  //聖火  

    public GameObject FirstLane;
    public GameObject SecondLane;
    public GameObject ThirdLane;

    int LaneNumber = 2;

    bool isHitting = false;      //ダメージを受けたか

    //SpriteRendererコンポーネント
    SpriteRenderer spRenderer;

    // Use this for initialization
    void Start()
    {

        spRenderer = GetComponent<SpriteRenderer>();

        _textCountdown.text = "";

        StartCoroutine("CountDown");

    }

    // Update is called once per frame
    void Update()
    {

        LaneMove();

    }

    void LaneMove()
    {
        Vector3 nowPos = transform.position;                    //現在の座標
        Vector3 FirstLanePos = FirstLane.transform.position;    //1レーン目の座標
        Vector3 SecondLanePos = SecondLane.transform.position;  //2レーン目の座標
        Vector3 ThirdLanePos = ThirdLane.transform.position;    //3レーン目の座標

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            LaneNumber -= 1;
            if (LaneNumber < 1)
            {
                LaneNumber = 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            LaneNumber += 1;
            if (LaneNumber > 3)
            {
                LaneNumber = 3;
            }
        }

        switch (LaneNumber)
        {
            case 1:
                transform.position = Vector3.Lerp(nowPos, FirstLanePos, Time.deltaTime * 10);
                break;
            case 2:
                transform.position = Vector3.Lerp(nowPos, SecondLanePos, Time.deltaTime * 10);
                break;
            case 3:
                transform.position = Vector3.Lerp(nowPos, ThirdLanePos, Time.deltaTime * 10);
                break;
        }

    }


    void OnTriggerEnter2D(Collider2D col)
    {

        string layerName = LayerMask.LayerToName(col.gameObject.layer);
        if (isHitting == false)
        {
            if (layerName == "CollisionPlayer")
            {
                Debug.Log("いいぞ。01");
                StartCoroutine("Damage");
                HP -= 10;
            }

            if (layerName == "CollisionFire")
            {
                Debug.Log("いいぞ。02");
                StartCoroutine("Damage");
                FireHP -= 1;
            }

            if (layerName == "CollisionAll")
            {
                Debug.Log("いいぞ。03");
                StartCoroutine("Damage");
                HP -= 10;
                FireHP -= 1;
            }

            if (layerName == "CollisionDead")
            {
                Debug.Log("いいぞ。04");
                HP -= 100;
                FireHP -= 3;
            }

            if (layerName == "CollisionHeal")
            {
                Debug.Log("いいぞ。05");
                HP += 30;
            }

            if (layerName == "CollisionFireHeal")
            {
                Debug.Log("いいぞ。06");
                FireHP += 1;
            }
        }

    }

    IEnumerator Damage()
    {

        //while文を8回ループ
        int count = 8;

        isHitting = true;

        while (count > 0)
        {
            //透明にする
            spRenderer.material.color = new Color(1, 1, 1, 0);

            //0.05秒待つ
            yield return new WaitForSeconds(0.05f);

            //元に戻す
            spRenderer.material.color = new Color(1, 1, 1, 1);

            //0.05秒待つ
            yield return new WaitForSeconds(0.05f);

            count--;
        }

        isHitting = false;

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
