﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    private LevelManager myLevelManager;
    public int coinValue;

	// Use this for initialization
	void Start () {
        myLevelManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            myLevelManager.AddCoins(coinValue);
            Destroy(gameObject);
        }
    }
}
