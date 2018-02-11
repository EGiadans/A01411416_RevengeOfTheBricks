using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Brick : MonoBehaviour {
    public AudioClip crack;
    public Sprite[] hitSprites;
    public static int breakableCount = 0;
    public GameObject smoke;


    //public Color color;
    //public GameObject thisBrick;
    

    private int timesHit;
    private LevelManager levelManager;
    private bool isBreakable;

	// Use this for initialization
	void Start () {
        isBreakable = (this.tag == "Breakable");

        //Beto humo
        //smoke.GetComponent<Renderer>().material.color = thisBrick.GetComponent<SpriteRenderer>().color;


        if (isBreakable)
        {
            breakableCount++;
        }
        timesHit = 0;

        levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(breakableCount);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(crack, transform.position, 0.8f);

        if (isBreakable)
        {
            HandleHits();
        }
    }

    private void HandleHits()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        

        if(timesHit >= maxHits)
        {
            breakableCount--;
            levelManager.BrickDestroyed();
            PuffSmoke();
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }

    }

    private void PuffSmoke()
    {
        GameObject smokePuff = Instantiate(smoke,transform.position,Quaternion.identity);
        //smokePuff.GetComponent<ParticleSystem>().MainModule.startColor = color;
        
        ParticleSystem ps = smokePuff.GetComponent<ParticleSystem>();
        var main = ps.main;
        main.startColor = gameObject.GetComponent<SpriteRenderer>().color;
        
        


    }

    private void LoadSprites()
    {
        int spriteIndex = timesHit - 1;

        if (hitSprites[spriteIndex] != null)
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        } else
        {
            Debug.LogError("Brick sprite missing");
        }
    }
}
