using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VikanBossinTrigger : MonoBehaviour
{
    GameObject taisteluCanvas;
    GameObject vikanBossinSpritetin;
    GameObject voittoCanvas;

    public GameObject loppuDialogiCanvas;
    public GameObject dialogiCanvas;
    public GameObject taistelunManageri;
    public GameObject pelaaja;

    private IEnumerator AikaLasku;

    [SerializeField]
    private Stat vihuHealth;

    // Start is called before the first frame update
    void Start()
    {
        vikanBossinSpritetin = GameObject.Find("VikanBossinSpritetin");
        taisteluCanvas = GameObject.Find("TaisteluCanvas");
        voittoCanvas = GameObject.Find("YouWonCanvas");
        voittoCanvas.GetComponent<Canvas>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (taisteluCanvas.GetComponent<Canvas>().enabled == true && vikanBossinSpritetin.GetComponent<SpriteRenderer>().enabled == true)
        {
            if (Input.GetKeyDown(KeyCode.R) || vihuHealth.MyCurrentValue <= 10)
            {
                Debug.Log("VikaBossiTapettu");
                taisteluCanvas.GetComponent<Canvas>().enabled = false;
                loppuDialogiCanvas.GetComponent<Canvas>().enabled = true;
                Destroy(dialogiCanvas);
                Destroy(taistelunManageri);

                StartCoroutine(AjanLaskin());

            }

        }

    }

    IEnumerator AjanLaskin()

    {
        yield return new WaitForSeconds(20);
        voittoCanvas.GetComponent<Canvas>().enabled = true;
        Destroy(pelaaja);

    }


}
