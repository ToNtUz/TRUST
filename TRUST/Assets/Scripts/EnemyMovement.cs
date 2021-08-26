using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{

    protected Vector2 direction;
    public float speed = 2f;
    public float huomausEtaisyys = 6f;
    public float laheisyys = 2f;
    private Transform target;

    private Rigidbody2D myRigidbody;
    private Animator myAnimator;




    //public float speed;
    //private float waitTime;
    //public float startWaitTime;
    //public Transform[] movespots;
    //private int randomSpot;




    public bool IsMoving
    {
        get
        {
            return direction.x != 0 || direction.y != 0;
        }
    }

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();



        //waitTime = startWaitTime;
        //randomSpot = Random.Range(0, movespots.Length);
    }

    void Update()
    {
        HandleLayers();

        Move();










        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        if (Vector2.Distance(transform.position, target.position) < huomausEtaisyys && (Vector2.Distance(transform.position, target.position) > laheisyys))
        {
            direction = (target.transform.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }






        //transform.position = Vector2.MoveTowards(transform.position, movespots[randomSpot].position, speed * Time.deltaTime);


        //if (Vector2.Distance(transform.position, movespots[randomSpot].position) < 0.2f)
        //{
        //    transform.position = Vector2.MoveTowards(transform.position, movespots[randomSpot].position, speed * Time.deltaTime);

        //    if (waitTime <= 0)
        //    {
        //        randomSpot = Random.Range(0, movespots.Length);
        //        waitTime = startWaitTime;
        //    }
        //    else
        //    {
        //        waitTime -= Time.deltaTime;
        //    }
        //}



    }


    public void HandleLayers()
    {
        if (IsMoving)
        {


            ActivateLayer("WalkLayer");


            myAnimator.SetFloat("x", direction.x);
            myAnimator.SetFloat("y", direction.y);
        }

        else
        {
            ActivateLayer("IdleLayer");
        }
    }

    public void Move()
    {
        //transform.Translate(direction * speed * Time.deltaTime);

        myRigidbody.velocity = direction.normalized * speed;



    }

    public void ActivateLayer(string layerName)
    {
        for (int i = 0; i < myAnimator.layerCount; i++)
        {
            myAnimator.SetLayerWeight(i, 0);
        }

        myAnimator.SetLayerWeight(myAnimator.GetLayerIndex(layerName), 1);


    }




}
