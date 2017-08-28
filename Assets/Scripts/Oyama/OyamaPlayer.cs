using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyamaPlayer : MonoBehaviour
{

    public float HP;      //スタミナ
    public int FireHP;  //聖火  

    public GameObject FirstLane;
    public GameObject SecondLane;
    public GameObject ThirdLane;

    public SpriteRenderer BodyRenderer;
    public SpriteRenderer LeftLegRenderer;
    public SpriteRenderer RightLegRenderer;

    int LaneNumber = 2;

    public float decreaseHPNum = 0.1f;

    bool jumpFlag = false;

    float sumTime = 0;
    float leftLegRota, rightLegRota;


    // Use this for initialization
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        HP -= decreaseHPNum;

        
        if (Input.GetKeyDown(KeyCode.Space) && jumpFlag == false)
        {
            jumpFlag = true;
            HP -= 5;
            //1.5秒後にジャンプフラグを切ります
            Invoke("EndJump", 1);
        }

        if (jumpFlag)
        {
            LeftLegRenderer.gameObject.transform.eulerAngles = new Vector3(0, 0, -50);
            RightLegRenderer.gameObject.transform.eulerAngles = new Vector3(0, 0, 50);
        }
        else {
            sumTime += Time.deltaTime * 5;
            LeftLegRenderer.gameObject.transform.eulerAngles = new Vector3(0, 0, Mathf.Sin(180 * sumTime * Mathf.Deg2Rad) * 50);
            RightLegRenderer.gameObject.transform.eulerAngles = new Vector3(0, 0, Mathf.Sin(-180 * sumTime * Mathf.Deg2Rad) * 50);

        }

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
                BodyRenderer.sortingOrder = 3;
                LeftLegRenderer.sortingOrder = RightLegRenderer.sortingOrder = 2;

                transform.position = Vector3.Lerp(nowPos, FirstLanePos, Time.deltaTime * 10);
                break;
            case 2:
                BodyRenderer.sortingOrder = 9;
                LeftLegRenderer.sortingOrder = RightLegRenderer.sortingOrder = 8;

                transform.position = Vector3.Lerp(nowPos, SecondLanePos, Time.deltaTime * 10);
                break;
            case 3:
                BodyRenderer.sortingOrder = 15;
                LeftLegRenderer.sortingOrder = RightLegRenderer.sortingOrder = 14;

                transform.position = Vector3.Lerp(nowPos, ThirdLanePos, Time.deltaTime * 10);
                break;
        }

    }


    void OnTriggerEnter2D(Collider2D col)
    {

        string layerName = LayerMask.LayerToName(col.gameObject.layer);

        if (layerName == "CollisionPlayer")
        {
            Debug.Log("いいぞ。01");
            HP -= 10;
        }
        
        //水関係はジャンプで回避可能
        if (layerName == "CollisionFire" && jumpFlag == false)
        {
            Debug.Log("いいぞ。02");
            FireHP -= 1;
        }

        if (layerName == "CollisionAll")
        {
            Debug.Log("いいぞ。03");
            HP -= 10;
            FireHP -= 1;
        }

        //海面はジャンプ中なら回避判定
        if (layerName == "CollisionDead" && jumpFlag == false)
        {
            Debug.Log("いいぞ。04");
            HP -= 100;
            FireHP -= 3;
        }

        if (layerName == "CollisionHeal")
        {
            Debug.Log("いいぞ。05");
            HP += 30;
            if (HP > 100) HP = 100;
            Destroy(col.gameObject);
        }

        if (layerName == "CollisionFireHeal")
        {
            Debug.Log("いいぞ。06");
            //ジャンプでくぐってなければスタミナにダメージ
            if (jumpFlag == false) { HP -= 5; }
            FireHP += 1;
            if (FireHP > 3) FireHP = 3;
        }

    }

    void EndJump()
    {
        jumpFlag = false;
    }

}
