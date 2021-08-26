using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovementTesti : CharacterTesti
{

    [SerializeField]
    private Stat health;


    private float initHealth = 100;

    GameObject taisteluCanvas;

    // Start is called before the first frame update


    protected override void Start()
    {
        taisteluCanvas = GameObject.Find("TaisteluCanvas");

        health.Initialize(initHealth, initHealth);


        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        GetInput();

        //health.MyCurrentValue = 100;

        base.Update();
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        health.MyCurrentValue -= 10;
        Debug.Log("osuuu myos");
    }*/

    private void GetInput()
    {

        if (taisteluCanvas.GetComponent<Canvas>().enabled == true)

        {

            direction = Vector2.zero;


            if (Input.GetKeyDown(KeyCode.I))
            {
                health.MyCurrentValue -= 10;
            }




            if (Input.GetKey(KeyCode.W))
            {
                direction += Vector2.up;
            }
            if (Input.GetKey(KeyCode.A))
            {
                direction += Vector2.left;
            }
            if (Input.GetKey(KeyCode.S))
            {
                direction += Vector2.down;
            }
            if (Input.GetKey(KeyCode.D))
            {
                direction += Vector2.right;
            }

        }

    }



}
