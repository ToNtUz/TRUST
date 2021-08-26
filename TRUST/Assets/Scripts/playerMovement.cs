using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : Character
{


    GameObject alkuCanvas;
    GameObject taisteluCanvas;
    GameObject dialogiCanvas1;
    GameObject dialogiCanvas2;
    GameObject dialogiCanvas3;

    [SerializeField]
    private Stat health;

    [SerializeField]
    private Stat mana;


    private float initHealth = 100;

    private float initMana = 100;


    // Start is called before the first frame update
    protected override void Start()
    {

        health.Initialize(initHealth, initHealth);
        mana.Initialize(initMana, initMana);

        alkuCanvas = GameObject.Find("AloitusCanvas");
        taisteluCanvas = GameObject.Find("TaisteluCanvas");
        dialogiCanvas1 = GameObject.Find("DialogiCanvasKVihu");
        dialogiCanvas2 = GameObject.Find("DialogiCanvasKGoblin");
        dialogiCanvas3 = GameObject.Find("DialogiCanvasKGoblinBoss");


        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        GetInput();

        //health.MyCurrentValue = 100;

        base.Update();

        if(alkuCanvas.GetComponent<Canvas>().enabled == true)
        {
            direction = Vector2.zero;
        }
        
        if (taisteluCanvas.GetComponent<Canvas>().enabled == true)
        {
            direction = Vector2.zero;
        }

        if (dialogiCanvas1.GetComponent<Canvas>().enabled == true)
        {
            Debug.Log("ei voi liikkua");
            direction = Vector2.zero;
        }

        if (dialogiCanvas2.GetComponent<Canvas>().enabled == true)
        {
            Debug.Log("ei voi liikkua");
            direction = Vector2.zero;
        }

        if (dialogiCanvas3.GetComponent<Canvas>().enabled == true)
        {
            Debug.Log("ei voi liikkua");
            direction = Vector2.zero;
        }


    }

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.CompareTag("DTrigger"))
    //    {
    //        direction = Vector2.zero;
    //        Debug.Log("Ei voi liikkua");
    //    }
    //}



    private void GetInput()
    {

        direction = Vector2.zero;


        //if (Input.GetKey(KeyCode.W))
        if (0 < Input.GetAxis("Vertical") || Input.GetKey(KeyCode.W))
        {
            direction += Vector2.up;
        }
        if (0 > Input.GetAxis("Horizontal") ||  Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;
        }
        if (0 > Input.GetAxis("Vertical"))
        {
            direction += Vector2.down;
        }
        if (0 < Input.GetAxis("Horizontal") || Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
        }
    }



}
