using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterTesti : MonoBehaviour
{


    [SerializeField]
    private float speed;


    protected Vector2 direction;

    private Rigidbody2D myRigidbody;

    public bool IsMoving
    {
        get
        {
            return direction.x != 0 || direction.y != 0;
        }
    }


    // Start is called before the first frame update
    protected virtual void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    protected virtual void Update()
    {
        HandleLayers();
        //Move();
    }

    private void FixedUpdate()
    {
        Move();
    }


    public void Move()
    {
        //transform.Translate(direction * speed * Time.deltaTime);

        //myRigidbody.velocity = direction.normalized * speed;



    }

    public void HandleLayers()
    {
        if (IsMoving)
        {


            ActivateLayer("WalkLayer");

        }

        else
        {
            ActivateLayer("IdleLayer");
        }
    }



    public void ActivateLayer(string layerName)
    {
 

    }

}