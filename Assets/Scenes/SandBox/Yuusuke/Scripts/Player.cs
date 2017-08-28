using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int HP;      //スタミナ
    public int FireHP;  //聖火  

    public GameObject FirstLane;
    public GameObject SecondLane;
    public GameObject ThirdLane;

    int LaneNumber = 2;

    // Use this for initialization
    void Start()
    {


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

        if (layerName == "CollisionPlayer")
        {
            Debug.Log("いいぞ。01");
            HP -= 10;
        }

        if (layerName == "CollisionFire")
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
