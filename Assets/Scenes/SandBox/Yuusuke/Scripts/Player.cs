using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int HP;      //スタミナ
    public int FireHP;  //聖火

    public float speed = 5;     //移動スピード
  

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        float x = Input.GetAxisRaw("Horizontal"); ;
        float y = Input.GetAxisRaw("Vertical");

        // 移動する向きを求める
        Vector2 direction = new Vector2(x, y).normalized;

        // 移動する向きとスピードを代入する
        GetComponent<Rigidbody2D>().velocity = direction * speed;




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
