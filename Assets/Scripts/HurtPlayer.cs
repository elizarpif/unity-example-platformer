using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour {

    public int damageToGive;

    private LevelManager myLevelMeneger;
	// Use this for initialization
	void Start () {
        myLevelMeneger = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            myLevelMeneger.HurtPlayer(damageToGive);
            // myLevelMeneger.Respawn();
        }
    }
}
