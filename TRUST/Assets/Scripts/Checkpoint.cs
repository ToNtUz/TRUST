using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour {

    private GameMaster gm;



    // Use this for initialization
    void Start () {
		 
        gm = GameObject.FindGameObjectWithTag("gm").GetComponent<GameMaster>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gm.lastCheckPointPos = transform.position;

        }
    }



    public void Restart()
    {
        gm.lastCheckPointPos = new Vector3(2.38f, 1.03f, -45.4f);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
