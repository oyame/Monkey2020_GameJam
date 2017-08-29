using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour {


    //オーディオ
    public AudioClip audioClip1;

    public AudioClip audioClip2;

    public AudioClip audioClip3;

    public AudioClip audioClip4;

    public AudioClip audioClip5;

    public AudioClip audioClip6;

    private AudioSource audioSource;



    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

	}
    void OnTriggerEnter2D(Collider2D col)
    {

        string layerName = LayerMask.LayerToName(col.gameObject.layer);

        if (layerName == "CollisionPlayer")
        {
            audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.clip = audioClip1;
            audioSource.Play();
        }

        if (layerName == "CollisionFire")
        {
            audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.clip = audioClip2;
            audioSource.Play();
        }

        if (layerName == "CollisionAll")
        {
            audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.clip = audioClip3;
            audioSource.Play();
        }

        if (layerName == "CollisionDead")
        {
            audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.clip = audioClip4;
            audioSource.Play();
        }

        if (layerName == "CollisionHeal")
        {
            audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.clip = audioClip5;
            audioSource.Play();
        }

        if (layerName == "CollisionFireHeal")
        {
            audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.clip = audioClip6;
            audioSource.Play();
        }

    }
}
