using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TaisteluTrigger : MonoBehaviour
{
    private IEnumerator AikaLasku;

    //public string ladattavaSecene;

    GameObject taisteluCanvas;

    public Image vihunKuva;

    public GameObject vihollisenKuva;

    public GameObject Spritetin;

    GameObject skeletonSpritetin;

    GameObject goblinSpritetin;

    GameObject hSkeletonSpritetin;

    GameObject gloopSpritetin;

    GameObject bossi1Spritetin;
    GameObject bossi2Spritetin;
    GameObject vikanBossinSpritetin;






    void Start()
    {
        taisteluCanvas = GameObject.Find("TaisteluCanvas");
        vihollisenKuva = GameObject.Find("VihuKuva");
        skeletonSpritetin = GameObject.Find("SkeletonSpritetin");
        goblinSpritetin = GameObject.Find("GoblinSpritetin");
        hSkeletonSpritetin = GameObject.Find("HSkeletonSpritetin");
        gloopSpritetin = GameObject.Find("GloopSpritetin");
        bossi1Spritetin = GameObject.Find("EkanBossinSpritetin");
        bossi2Spritetin = GameObject.Find("TokanBossinSpritetin");
        vikanBossinSpritetin = GameObject.Find("VikanBossinSpritetin");
        taisteluCanvas.GetComponent<Canvas>().enabled = false;
        skeletonSpritetin.GetComponent<SpriteRenderer>().enabled = false;
        goblinSpritetin.GetComponent<SpriteRenderer>().enabled = false;
        hSkeletonSpritetin.GetComponent<SpriteRenderer>().enabled = false;
        bossi1Spritetin.GetComponent<SpriteRenderer>().enabled = false;
        bossi2Spritetin.GetComponent<SpriteRenderer>().enabled = false;
        gloopSpritetin.GetComponent<SpriteRenderer>().enabled = false;
        vikanBossinSpritetin.GetComponent<SpriteRenderer>().enabled = false;

    }

    IEnumerator AjanLaskin()
    {
        yield return new WaitForSeconds(30);
        taisteluCanvas.GetComponent<Canvas>().enabled = true;
        Debug.Log("Taisteluun vikan bossin kanssa");
        //Destroy(this.gameObject);
        taisteluCanvas.GetComponent<Canvas>().enabled = true;
        vikanBossinSpritetin.GetComponent<SpriteRenderer>().enabled = true;
        vihollisenKuva.GetComponent<Image>().overrideSprite = vikanBossinSpritetin.GetComponent<SpriteRenderer>().sprite; 

    }


    void OnTriggerEnter2D(Collider2D other)
    {

        if (this.gameObject.tag == "HSkeleton" && other.CompareTag("Player"))
        {
            Debug.Log("Taisteluun harjoitus luurangon kanssa");
            Destroy(this.gameObject);
            taisteluCanvas.GetComponent<Canvas>().enabled = true;
            hSkeletonSpritetin.GetComponent<SpriteRenderer>().enabled = true;
            vihollisenKuva.GetComponent<Image>().overrideSprite = hSkeletonSpritetin.GetComponent<SpriteRenderer>().sprite; ;

        }

        if (this.gameObject.tag == "Skeleton" &&  other.CompareTag("Player"))
        {
            Debug.Log("Taisteluun luurangon kanssa");
            Destroy(this.gameObject);
            taisteluCanvas.GetComponent<Canvas>().enabled = true;
            skeletonSpritetin.GetComponent<SpriteRenderer>().enabled = true;
            vihollisenKuva.GetComponent<Image>().overrideSprite = skeletonSpritetin.GetComponent<SpriteRenderer>().sprite; ;

        }

        if (this.gameObject.tag == "Goblin" && other.CompareTag("Player"))
        {
            Debug.Log("Taisteluun goblinin kanssa");
            Destroy(this.gameObject);
            taisteluCanvas.GetComponent<Canvas>().enabled = true;
            goblinSpritetin.GetComponent<SpriteRenderer>().enabled = true;
            vihollisenKuva.GetComponent<Image>().overrideSprite = goblinSpritetin.GetComponent<SpriteRenderer>().sprite; ;

        }

        if (this.gameObject.tag == "Gloob" && other.CompareTag("Player"))
        {
            Debug.Log("Taisteluun gloopin kanssa");
            Destroy(this.gameObject);
            taisteluCanvas.GetComponent<Canvas>().enabled = true;
            gloopSpritetin.GetComponent<SpriteRenderer>().enabled = true;
            vihollisenKuva.GetComponent<Image>().overrideSprite = gloopSpritetin.GetComponent<SpriteRenderer>().sprite; ;

        }

        if (this.gameObject.tag == "Bossi1" && other.CompareTag("Player"))
        {
            Debug.Log("Taisteluun ekan bossin kanssa");
            Destroy(this.gameObject);
            taisteluCanvas.GetComponent<Canvas>().enabled = true;
            bossi1Spritetin.GetComponent<SpriteRenderer>().enabled = true;
            vihollisenKuva.GetComponent<Image>().overrideSprite = bossi1Spritetin.GetComponent<SpriteRenderer>().sprite; ;

        }

        if (this.gameObject.tag == "Bossi2" && other.CompareTag("Player"))
        {
            Debug.Log("Taisteluun tokan bossin kanssa");
            Destroy(this.gameObject);
            taisteluCanvas.GetComponent<Canvas>().enabled = true;
            bossi2Spritetin.GetComponent<SpriteRenderer>().enabled = true;
            vihollisenKuva.GetComponent<Image>().overrideSprite = bossi2Spritetin.GetComponent<SpriteRenderer>().sprite; ;

        }

        if (this.gameObject.tag == "Friend" && other.CompareTag("Player"))
        {
            StartCoroutine(AjanLaskin());
        }
    }


}
