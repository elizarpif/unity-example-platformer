using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour {
    public Sprite flagClosed, flagOpen;
    private SpriteRenderer mySpriteRenderer;
    private bool checkPointActive;

	// Use this for initialization
	void Start () {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            mySpriteRenderer.sprite = flagOpen;
            checkPointActive = true;
        }
    }
}
