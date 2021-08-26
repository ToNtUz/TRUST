using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{

    private Transform playerTransfrom;


    // Start is called before the first frame update
    void Start()
    {
        playerTransfrom = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 temp = transform.position;

        temp.x = playerTransfrom.position.x;
        temp.y = playerTransfrom.position.y;

        transform.position = temp;
    }



}
