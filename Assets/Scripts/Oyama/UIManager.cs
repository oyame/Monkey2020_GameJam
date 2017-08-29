﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public OyamaPlayer playerScript;

    public Transform player;
    public Transform goal;

    public int root = 0;

    public Image sutaminaBar;
    public GameObject HolyFire;
    SpriteRenderer[] holyFires;

    //火がついている聖火アイコン、ついてない聖火アイコン
    public Sprite TrueFire, FalseFire;

	// Use this for initialization
	void Start () {
        holyFires = new SpriteRenderer[HolyFire.transform.childCount];

		for(int i = 0; i < holyFires.Length; i++)
        {
            holyFires[i] = HolyFire.transform.FindChild("HolyFire" + i).GetComponent<SpriteRenderer>();
        }
	}
	
	// Update is called once per frame
	void Update () {

        sutaminaBar.fillAmount = playerScript.HP / 100;

        for (int i = 0; i < holyFires.Length; i++)
        {
            if (i + 1 > playerScript.FireHP)
            {
                holyFires[i].sprite = FalseFire;
            }
            else {
                holyFires[i].sprite = TrueFire;
            }
        }

        Root();

    }

    void Root()
    {
        Vector3 playerPos = player.transform.position;
        Vector3 goalPos = goal.transform.position;

        playerPos = Camera.main.ScreenToWorldPoint(player.transform.position);
        goalPos = Camera.main.ScreenToWorldPoint(goal.transform.position);

        root = (int)goalPos.x - (int)playerPos.x;

        Debug.Log(root);

    }
}
