using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvaksenHavitys : MonoBehaviour
{

    GameObject alkuCanvas;

    public GameObject dialoginTrigger;

    public GameObject dialoginTrigger2;

    GameObject taistelunCanvas;

    private IEnumerator AjanLasku;

    // Start is called before the first frame update
    void Start()
    {

        alkuCanvas = GameObject.Find("AloitusCanvas");


        StartCoroutine(LaskeAikaa());

        taistelunCanvas = GameObject.Find("TaisteluCanvas");

    }

    IEnumerator LaskeAikaa()

    {
        yield return new WaitForSeconds(3);
        alkuCanvas.GetComponent<Canvas>().enabled = false;

        yield return new WaitForSeconds(15);
        Destroy(dialoginTrigger.gameObject);


    }

    IEnumerator LaskeAikaa2()

    {

        yield return new WaitForSeconds(10);
        Destroy(dialoginTrigger2.gameObject);

    }

    // Update is called once per frame
    void Update()
    {

    if (taistelunCanvas.GetComponent<Canvas>().enabled == true)
        {
            StartCoroutine(LaskeAikaa2());
        }

    }
}
