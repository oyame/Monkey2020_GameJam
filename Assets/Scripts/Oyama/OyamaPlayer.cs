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

    //オーディオ
    public AudioClip audioClip1;

    public AudioClip audioClip2;

    public AudioClip audioClip3;

    public AudioClip audioClip4;

    public AudioClip audioClip5;

    public AudioClip audioClip6;

    public AudioClip audioClip7;

    private AudioSource audioSource;


    bool isHitting = false;      //ダメージを受けたか

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
            audioSource = gameObject.GetComponent<AudioSource>();

            audioSource.clip = audioClip7;

            audioSource.Play();

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

        if (isHitting == false)
        {
            if (layerName == "CollisionPlayer")
            {
                //再生

                audioSource = gameObject.GetComponent<AudioSource>();

                audioSource.clip = audioClip1;

                audioSource.Play();

                StartCoroutine("Damage");

                HP -= 10;



            }

            //水関係はジャンプで回避可能
            if (layerName == "CollisionFire" && jumpFlag == false)
            {
                FireHP -= 1;

                //再生

                audioSource = gameObject.GetComponent<AudioSource>();

                audioSource.clip = audioClip2;

                StartCoroutine("Damage");

                audioSource.Play();
            }

            if (layerName == "CollisionAll")
            {
                HP -= 10;
                FireHP -= 1;

                //再生

                audioSource = gameObject.GetComponent<AudioSource>();

                audioSource.clip = audioClip3;

                StartCoroutine("Damage");

                audioSource.Play();

            }

            //海面はジャンプ中なら回避判定
            if (layerName == "CollisionDead" && jumpFlag == false)
            {
                HP -= 100;
                FireHP -= 3;

                //再生

                audioSource = gameObject.GetComponent<AudioSource>();

                audioSource.clip = audioClip4;

                StartCoroutine("Damage");

                audioSource.Play();
            }

            if (layerName == "CollisionHeal")
            {
                HP += 30;
                if (HP > 100) HP = 100;
                Destroy(col.gameObject);

                //再生

                audioSource = gameObject.GetComponent<AudioSource>();

                audioSource.clip = audioClip5;

                audioSource.Play();
            }

            if (layerName == "CollisionFireHeal")
            {
                //ジャンプでくぐってなければスタミナにダメージ
                if (jumpFlag == false) {
                    StartCoroutine("Damage");
                    HP -= 5;
                }
                FireHP += 1;
                if (FireHP > 3) FireHP = 3;

                //再生

                audioSource = gameObject.GetComponent<AudioSource>();

                audioSource.clip = audioClip6;

                audioSource.Play();
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
            BodyRenderer.material.color = new Color(1, 1, 1, 0);
            LeftLegRenderer.material.color = new Color(1, 1, 1, 0);
            RightLegRenderer.material.color = new Color(1, 1, 1, 0);

            //0.05秒待つ
            yield return new WaitForSeconds(0.05f);

            //元に戻す
            BodyRenderer.material.color = new Color(1, 1, 1, 1);
            LeftLegRenderer.material.color = new Color(1, 1, 1, 1);
            RightLegRenderer.material.color = new Color(1, 1, 1, 1);

            //0.05秒待つ
            yield return new WaitForSeconds(0.05f);

            count--;
        }

        isHitting = false;

    }

    void EndJump()
    {
        jumpFlag = false;
    }

}
