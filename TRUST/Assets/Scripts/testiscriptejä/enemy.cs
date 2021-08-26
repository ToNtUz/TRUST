using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HealthBar.health -= 10f;
        Debug.Log("osuuu");
    }

}
