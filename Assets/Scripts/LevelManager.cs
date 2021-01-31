using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public float waitToRespawn;
    public PlayerController1 myPlayer;
	// Use this for initialization
	void Start () {
        myPlayer = FindObjectOfType<PlayerController1>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Respawn()
    {
        StartCoroutine("RespawnCo");
    }
    public IEnumerator RespawnCo()
    {
        myPlayer.gameObject.SetActive(false);

        yield return new WaitForSeconds(waitToRespawn);

        myPlayer.transform.position = myPlayer.respawnPosition;
        myPlayer.gameObject.SetActive(true);
    }
}
