using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewPlayerPos : MonoBehaviour {

    private GameMaster gm;
    public int safepointit;
    private Vector2 viimeinenSafepoint;


 
	// Use this for initialization
	void Start () {

        gm = GameObject.FindGameObjectWithTag("gm").GetComponent<GameMaster>();

        transform.position = gm.lastCheckPointPos;
		                             
	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadScene("PaaKentta");

        }
	}
}
