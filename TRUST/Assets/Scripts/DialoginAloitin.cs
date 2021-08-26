using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoginAloitin : MonoBehaviour
{

    //public string ladattavaSecene;

    public GameObject dialogiCanvas;

    void Start()
    {
        //dialogiCanvas = GameObject.Find("DialogiCanvasMies");
        dialogiCanvas.GetComponent<Canvas>().enabled = false;

    }

    IEnumerator ajanLaskin()
    {
        yield return new WaitForSeconds(6);
        Destroy(this.gameObject);
    }

    IEnumerator ajanLaskin2()
    {
        yield return new WaitForSeconds(8);
        Destroy(this.gameObject);
    }


    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            Debug.Log("Dialogiin");
            dialogiCanvas.GetComponent<Canvas>().enabled = true;
        }

        if (this.tag == "DTrigger" && other.CompareTag("Player"))
        {
            Debug.Log("Dialogiin tuhotaan");
            dialogiCanvas.GetComponent<Canvas>().enabled = true;
            StartCoroutine(ajanLaskin());
        }

        if (this.tag == "DTrigger2" && other.CompareTag("Player"))
        {
            Debug.Log("Dialogiin2 tuhotaan");
            dialogiCanvas.GetComponent<Canvas>().enabled = true;
            StartCoroutine(ajanLaskin2());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            dialogiCanvas.GetComponent<Canvas>().enabled = false;

        }

    }
}