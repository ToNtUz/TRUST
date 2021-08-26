using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2 : MonoBehaviour
{
    public Transform playerTransfrom;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerTransfrom = GameObject.FindGameObjectWithTag("Player").transform;

        Vector3 temp = transform.position;

        temp.x = playerTransfrom.position.x;
        temp.y = playerTransfrom.position.y;

        transform.position = temp;
    }
}
