using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TaistelustaPoistuminen : MonoBehaviour
{
    GameObject gameOverCanvas;
    GameObject taisteluCanvas;
    GameObject pelattavatHahmot;
    GameObject hitBar;
    GameObject aikaLaskuri;
    GameObject voittoCanvas;
    public GameObject loppuDialogiCanvas;
    public GameObject dialogiCanvas;
    public GameObject pelaaja;

    GameObject skeletonSpritetin;
    GameObject goblinSpritetin;
    GameObject hSkeletonSpritetin;
    GameObject gloopSpritetin;
    GameObject tokanBossinSpritetin;
    GameObject ekaBossiSprietin;
    GameObject vikanBossinSpritetin;

    private IEnumerator AikaLasku;


    [SerializeField]
    private Stat health;

    [SerializeField]
    private Stat mana;

    [SerializeField]
    private Stat vihuHealth;

    [SerializeField]
    Text aikalaskuriTeksi;

    //[SerializeField]
    //Text aikalaskuriTeksi2;


    float nykyinenAika;
    float aloitusAika = 25f;
    float nykyinenAika2;
    float aloitusAikaPitak = 60f;




    void Start()
    {
        taisteluCanvas = GameObject.Find("TaisteluCanvas");
        GameObject myCanvas = GameObject.Find("YouDiedCanvas");
        gameOverCanvas = GameObject.Find("YouDiedCanvas");
        gameOverCanvas.GetComponent<Canvas>().enabled = false;
        pelattavatHahmot = GameObject.Find("CharacterList");
        hitBar = GameObject.Find("HitBar");
        aikaLaskuri = GameObject.Find("Aikalaskuri");
        voittoCanvas = GameObject.Find("YouWonCanvas");
        voittoCanvas.GetComponent<Canvas>().enabled = false;
        //loppuDialogiCanvas = GameObject.Find("DialogiCanvasKLoppu");
        loppuDialogiCanvas.GetComponent<Canvas>().enabled = false;

        nykyinenAika = aloitusAika;
        nykyinenAika2 = aloitusAikaPitak;

        skeletonSpritetin = GameObject.Find("SkeletonSpritetin");
        goblinSpritetin = GameObject.Find("GoblinSpritetin");
        hSkeletonSpritetin = GameObject.Find("HSkeletonSpritetin");
        ekaBossiSprietin = GameObject.Find("EkanBossinSpritetin");
        gloopSpritetin = GameObject.Find("GloopSpritetin");
        tokanBossinSpritetin = GameObject.Find("TokanBossinSpritetin");
        vikanBossinSpritetin = GameObject.Find("VikanBossinSpritetin");
    }

    //IEnumerator AjanLaskin()
    //{
    //    yield return new WaitForSeconds(15);
    //    voittoCanvas.GetComponent<Canvas>().enabled = true;
    //    Destroy(pelaaja);
    //}


    void Update()
    {

        if (taisteluCanvas.GetComponent<Canvas>().enabled == true != hSkeletonSpritetin.GetComponent<SpriteRenderer>().enabled == true)
        {
            nykyinenAika -= 1 * Time.deltaTime;
            aikalaskuriTeksi.text = nykyinenAika.ToString("0.0");


            if (Input.GetKeyDown(KeyCode.J) || vihuHealth.MyCurrentValue == 0)
            {
                taisteluCanvas.GetComponent<Canvas>().enabled = false;
                Debug.Log("toimiii");
                vihuHealth.MyCurrentValue = 100;
                skeletonSpritetin.GetComponent<SpriteRenderer>().enabled = false;
                goblinSpritetin.GetComponent<SpriteRenderer>().enabled = false;
                ekaBossiSprietin.GetComponent<SpriteRenderer>().enabled = false;
                gloopSpritetin.GetComponent<SpriteRenderer>().enabled = false;
                tokanBossinSpritetin.GetComponent<SpriteRenderer>().enabled = false;

            }

            if (Input.GetKeyDown(KeyCode.B) || health.MyCurrentValue == 0 || nykyinenAika <= 0)
            {
                nykyinenAika = 0;
                gameOverCanvas.SetActive(true);
                Destroy(pelattavatHahmot.gameObject);
                Destroy(hitBar.gameObject);
                Destroy(aikaLaskuri.gameObject);
                gameOverCanvas.GetComponent<Canvas>().enabled = true;
                skeletonSpritetin.GetComponent<SpriteRenderer>().enabled = false;
                goblinSpritetin.GetComponent<SpriteRenderer>().enabled = false;
                ekaBossiSprietin.GetComponent<SpriteRenderer>().enabled = false;
                gloopSpritetin.GetComponent<SpriteRenderer>().enabled = false;
                tokanBossinSpritetin.GetComponent<SpriteRenderer>().enabled = false;

            }

            if (taisteluCanvas.GetComponent<Canvas>().enabled == false)
            {
                nykyinenAika = 25f;
            }
        }

        if (taisteluCanvas.GetComponent<Canvas>().enabled==true && hSkeletonSpritetin.GetComponent<SpriteRenderer>().enabled == true)
        {
            nykyinenAika2 -= 1 * Time.deltaTime;
            aikalaskuriTeksi.text = nykyinenAika2.ToString("0.0");

            if (Input.GetKeyDown(KeyCode.J) || vihuHealth.MyCurrentValue == 0)
            {
                taisteluCanvas.GetComponent<Canvas>().enabled = false;
                Debug.Log("toimiii");
                vihuHealth.MyCurrentValue = 100;
                hSkeletonSpritetin.GetComponent<SpriteRenderer>().enabled = false;
            }

            if (Input.GetKeyDown(KeyCode.B) || health.MyCurrentValue == 0 || nykyinenAika2 <= 0)
            {
                nykyinenAika2 = 0;
                gameOverCanvas.SetActive(true);
                Destroy(pelattavatHahmot.gameObject);
                Destroy(hitBar.gameObject);
                Destroy(aikaLaskuri.gameObject);
                gameOverCanvas.GetComponent<Canvas>().enabled = true;

            }

            if (taisteluCanvas.GetComponent<Canvas>().enabled == false)
            {
               nykyinenAika2 = 25f;
            }
        }

        //if (taisteluCanvas.GetComponent<Canvas>().enabled == true && vikanBossinSpritetin.GetComponent<SpriteRenderer>().enabled == true)
        //{
        //    if (Input.GetKeyDown(KeyCode.R) || vihuHealth.MyCurrentValue <= 10)
        //    {
        //        Debug.Log("VikaBossiTapettu");
        //        taisteluCanvas.GetComponent<Canvas>().enabled = false;
        //        skeletonSpritetin.GetComponent<SpriteRenderer>().enabled = false;
        //        goblinSpritetin.GetComponent<SpriteRenderer>().enabled = false;
        //        ekaBossiSprietin.GetComponent<SpriteRenderer>().enabled = false;
        //        gloopSpritetin.GetComponent<SpriteRenderer>().enabled = false;
        //        tokanBossinSpritetin.GetComponent<SpriteRenderer>().enabled = false;
        //        loppuDialogiCanvas.GetComponent<Canvas>().enabled = true;
        //        Destroy(dialogiCanvas);

        //        StartCoroutine(AjanLaskin());

        //    }

        //}

    }
}


