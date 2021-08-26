using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatBarHandler : MonoBehaviour
{

    GameObject orcOsumaVihuun;
    GameObject hOrcOsumaVihuun;
    GameObject humanOsumaVihuun;
    GameObject hHumanOsumaVihuun;
    GameObject elfOsumaVihuun;
    GameObject hElfOsumaVihuun;
    GameObject osumaPelaajaan;

    public AudioClip hitSoundArcher;
    public AudioSource audioSourceArcher;
    public AudioClip hitSoundOrc;
    public AudioSource audioSourceOrc;
    public AudioClip hitSoundElf;
    public AudioSource audioSourceElf;
    public AudioClip hitSoundPelaaja;
    public AudioSource audioSourcePelaaja;



    GameObject pelaajaElfM;
    GameObject pelaajaElfF;
    GameObject pelaajaHumanM;
    GameObject pelaajaHumanF;
    GameObject pelaajaOrcM;
    GameObject pelaajaOrcF;

    GameObject skeletonSpritetin;
    GameObject goblinSpritetin;
    GameObject hSkeletonSpritetin;
    GameObject ekanBossinSpritetin;
    GameObject tokanBossinSpritetin;
    GameObject gloopSpritetin;
    GameObject vikanBossinSpritetin;

    GameObject taistelevaCanvas;


    [SerializeField] private RectTransform barTransform;
    [SerializeField] private RectTransform hitZoneTransform;
    [SerializeField] private Animator hitBarAnimator;

    [SerializeField]
    private Stat health;

    [SerializeField]
    private Stat mana;

    [SerializeField]
    private Stat vihuHealth;

    private IEnumerator AikaLasku;
    private IEnumerator AikaLasku2;
    private IEnumerator AikaLasku3;
    private IEnumerator AikaLasku4;




    // Start is called before the first frame update
    void Start()
    {

        RandomizeHitArea();
        orcOsumaVihuun = GameObject.Find("OrcVihuOsuma");
        orcOsumaVihuun.GetComponent<Image>().enabled = false;
        hOrcOsumaVihuun = GameObject.Find("HuonoOrcVihuOsuma");
        hOrcOsumaVihuun.GetComponent<Image>().enabled = false;


        humanOsumaVihuun = GameObject.Find("HumanVihuOsuma");
        humanOsumaVihuun.GetComponent<Image>().enabled = false;
        hHumanOsumaVihuun = GameObject.Find("HuonoHumanVihuOsuma");
        hHumanOsumaVihuun.GetComponent<Image>().enabled = false;

        elfOsumaVihuun = GameObject.Find("ElfVihuOsuma");
        elfOsumaVihuun.GetComponent<Image>().enabled = false;
        hElfOsumaVihuun = GameObject.Find("HuonoElfVihuOsuma");
        hElfOsumaVihuun.GetComponent<Image>().enabled = false;

        osumaPelaajaan = GameObject.Find("PelaajaOsuma");
        osumaPelaajaan.GetComponent<Image>().enabled = false;

        skeletonSpritetin = GameObject.Find("SkeletonSpritetin");
        goblinSpritetin = GameObject.Find("GoblinSpritetin");
        hSkeletonSpritetin = GameObject.Find("HSkeletonSpritetin");
        ekanBossinSpritetin = GameObject.Find("EkanBossinSpritetin");
        gloopSpritetin = GameObject.Find("GloopSpritetin");
        tokanBossinSpritetin = GameObject.Find("TokanBossinSpritetin");
        vikanBossinSpritetin = GameObject.Find("VikanBossinSpritetin");

        pelaajaElfM = GameObject.Find("elf_Male");
        pelaajaElfF = GameObject.Find("elf_Female");
        pelaajaHumanM = GameObject.Find("human_Male");
        pelaajaHumanF = GameObject.Find("human_Female");
        pelaajaOrcM = GameObject.Find("orc_Male");
        pelaajaOrcF = GameObject.Find("orc_Female");

        taistelevaCanvas = GameObject.Find("TaisteluCanvas");

        //StartCoroutine(AjanLaskin());
        //StartCoroutine(AjanLaskin2());
        //StartCoroutine(AjanLaskin3());
        //StartCoroutine(AjanLaskin4());
    }

    public void RandomizeHitArea()
    {
        Vector2 tmpPos = hitZoneTransform.anchoredPosition;

        tmpPos.x = Random.Range(20f, 180f);
        hitZoneTransform.anchoredPosition = tmpPos;


        //Debug.LogError("new area" + hitZoneTransform.anchoredPosition);
    }

    IEnumerator AjanLaskin()

    {
        audioSourceOrc.Play();
        yield return new WaitForSeconds(1);
        orcOsumaVihuun.GetComponent<Image>().enabled = false;
        hOrcOsumaVihuun.GetComponent<Image>().enabled = false;

    }

    IEnumerator AjanLaskin2()
    {
        audioSourceArcher.Play();
        yield return new WaitForSeconds(1);
        humanOsumaVihuun.GetComponent<Image>().enabled = false;
        hHumanOsumaVihuun.GetComponent<Image>().enabled = false;
    }

    IEnumerator AjanLaskin3()
    {
        audioSourceElf.Play();
        yield return new WaitForSeconds(1);
        elfOsumaVihuun.GetComponent<Image>().enabled = false;
        hElfOsumaVihuun.GetComponent<Image>().enabled = false;
    }

    IEnumerator AjanLaskin4()
    {
        audioSourcePelaaja.Play();
        yield return new WaitForSeconds(1);
        osumaPelaajaan.GetComponent<Image>().enabled = false;
    }





    // Update is called once per frame
    void Update()
    {
        if (taistelevaCanvas.GetComponent<Canvas>().enabled == true)
        {
            // 
            if (Input.GetKeyDown(KeyCode.T))
            {
                float xPos = barTransform.anchoredPosition.x;


                float xHitArea = hitZoneTransform.anchoredPosition.x;


                float MinVal = xHitArea - 5f;

                float MaxVal = xHitArea + 5f;

                float vahMinVal = MinVal - 15f;

                float vahMaxVal = MaxVal + 15f;


                //HSkeleton
                if (xPos >= MinVal && xPos <= MaxVal && mana.MyCurrentValue >= 0 && hSkeletonSpritetin.GetComponent<SpriteRenderer>().enabled == true)
                {

                    if (pelaajaOrcF.activeSelf || pelaajaOrcM.activeSelf)
                    {
                        Debug.LogError("Orc: Paras osuma, ja manaa on, Hskeletoniin, tee 25 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 25;
                        mana.MyCurrentValue -= 2;
                        orcOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin());
                    }

                    if (pelaajaHumanF.activeSelf || pelaajaHumanM.activeSelf)
                    {
                        Debug.LogError("Human: Paras osuma, ja manaa on, Hskeletoniin, tee 25 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 25;
                        mana.MyCurrentValue -= 2;
                        humanOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin2());
                    }

                    if (pelaajaElfF.activeSelf || pelaajaElfM.activeSelf)
                    {
                        Debug.LogError("Elf: Paras osuma, ja manaa on, Hskeletoniin, tee 25 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 25;
                        mana.MyCurrentValue -= 2;
                        elfOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin3());
                    }

                    //Debug.LogError("Paras osuma, ja manaa on, Hskeletoniin, tee 20 damagee");
                    //RandomizeHitArea();
                    //vihuHealth.MyCurrentValue -= 15;
                    //mana.MyCurrentValue -= 2;
                    //osumaVihuun1.GetComponent<Image>().enabled = true;

                    //StartCoroutine(AjanLaskin());
                }


                else if (xPos >= vahMinVal && xPos <= vahMaxVal && mana.MyCurrentValue >= 0 && hSkeletonSpritetin.GetComponent<SpriteRenderer>().enabled == true)
                {

                    if (pelaajaOrcF.activeSelf || pelaajaOrcM.activeSelf)
                    {
                        Debug.LogError("Orc: Huono osuma, ja  manaa on, Hskeletoniin, tee 20 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 20;
                        mana.MyCurrentValue -= 2;
                        hOrcOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin());
                    }

                    if (pelaajaHumanF.activeSelf || pelaajaHumanM.activeSelf)
                    {
                        Debug.LogError("Human: Huono osuma, ja  manaa on, Hskeletoniin, tee 20 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 20;
                        mana.MyCurrentValue -= 2;
                        hHumanOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin2());
                    }

                    if (pelaajaElfF.activeSelf || pelaajaElfM.activeSelf)
                    {
                        Debug.LogError("Elf: Huono osuma, ja  manaa on, Hskeletoniin, tee 20 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 20;
                        mana.MyCurrentValue -= 2;
                        hElfOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin3());
                    }

                    //Debug.LogError("Huono osuma, ja  manaa on, Hskeletoniin, tee 10 damagee");
                    //RandomizeHitArea();
                    //vihuHealth.MyCurrentValue -= 10;
                    //osumaVihuun1.GetComponent<Image>().enabled = true;

                    //StartCoroutine(AjanLaskin());
                }

                else if (xPos >= MinVal && xPos <= MaxVal && mana.MyCurrentValue == 0 && hSkeletonSpritetin.GetComponent<SpriteRenderer>().enabled == true)
                {

                    if (pelaajaOrcF.activeSelf || pelaajaOrcM.activeSelf)
                    {
                        Debug.LogError("Orc: Paras osuma, mutta ei manaa, Hskeletoniin, tee 20 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 20;
                        mana.MyCurrentValue -= 2;
                        orcOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin());
                    }

                    if (pelaajaHumanF.activeSelf || pelaajaHumanM.activeSelf)
                    {
                        Debug.LogError("Human: Paras osuma, mutta ei manaa, Hskeletoniin, tee 20 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 20;
                        mana.MyCurrentValue -= 2;
                        humanOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin2());
                    }

                    if (pelaajaElfF.activeSelf || pelaajaElfM.activeSelf)
                    {
                        Debug.LogError("Elf: Paras osuma, mutta ei manaa, Hskeletoniin, tee 20 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 20;
                        mana.MyCurrentValue -= 2;
                        elfOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin3());
                    }

                    //Debug.LogError("Paras osuma, mutta ei manaa, Hskeletoniin, tee 10 damagee");
                    //RandomizeHitArea();
                    //vihuHealth.MyCurrentValue -= 10;
                    //mana.MyCurrentValue -= 2;
                    //osumaVihuun1.GetComponent<Image>().enabled = true;

                    //StartCoroutine(AjanLaskin());

                }

                else if (xPos >= vahMinVal && xPos <= vahMaxVal && mana.MyCurrentValue == 0 && hSkeletonSpritetin.GetComponent<SpriteRenderer>().enabled == true)
                {

                    if (pelaajaOrcF.activeSelf || pelaajaOrcM.activeSelf)
                    {
                        Debug.LogError("Orc: Huono osuma, ja ei manaa, Hskeletoniin, tee 15 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 15;
                        mana.MyCurrentValue -= 2;
                        orcOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin());
                    }

                    if (pelaajaHumanF.activeSelf || pelaajaHumanM.activeSelf)
                    {
                        Debug.LogError("Human: Huono osuma, ja ei manaa, Hskeletoniin, tee 15 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 15;
                        mana.MyCurrentValue -= 2;
                        hHumanOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin2());
                    }

                    if (pelaajaElfF.activeSelf || pelaajaElfM.activeSelf)
                    {
                        Debug.LogError("Elf: Huono osuma, ja ei manaa, Hskeletoniin, tee 15 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 15;
                        mana.MyCurrentValue -= 2;
                        hElfOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin3());
                    }

                    //Debug.LogError("Huono osuma, ja ei manaa, Hskeletoniin, tee 5 damagee");
                    //RandomizeHitArea();
                    //vihuHealth.MyCurrentValue -= 5;
                    //osumaVihuun1.GetComponent<Image>().enabled = true;

                    //StartCoroutine(AjanLaskin());
                }



                //Skeleton Skeleton Skeleton Skeleton Skeleton Skeleton Skeleton Skeleton Skeleton Skeleton Skeleton Skeleton Skeleton 

                else if (xPos >= MinVal && xPos <= MaxVal && mana.MyCurrentValue >= 0 && skeletonSpritetin.GetComponent<SpriteRenderer>().enabled == true)
                {

                    if (pelaajaOrcF.activeSelf || pelaajaOrcM.activeSelf)
                    {
                        Debug.LogError("Orc: Paras osuma, ja manaa on, Skeletoniin, tee 20 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 20;
                        mana.MyCurrentValue -= 2;
                        orcOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin());
                    }

                    if (pelaajaHumanF.activeSelf || pelaajaHumanM.activeSelf)
                    {
                        Debug.LogError("Human: Paras osuma, ja manaa on, Skeletoniin, tee 20 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 20;
                        mana.MyCurrentValue -= 2;
                        humanOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin2());
                    }

                    if (pelaajaElfF.activeSelf || pelaajaElfM.activeSelf)
                    {
                        Debug.LogError("Elf: Paras osuma, ja manaa on, Skeletoniin, tee 20 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 20;
                        mana.MyCurrentValue -= 2;
                        elfOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin3());
                    }

                }

                else if (xPos >= vahMinVal && xPos <= vahMaxVal && mana.MyCurrentValue >= 0 && skeletonSpritetin.GetComponent<SpriteRenderer>().enabled == true)
                {

                    if (pelaajaOrcF.activeSelf || pelaajaOrcM.activeSelf)
                    {
                        Debug.LogError("Orc: Huono osuma, ja  manaa on, Skeletoniin, tee 15 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 15;
                        mana.MyCurrentValue -= 2;
                        hOrcOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin());
                    }

                    if (pelaajaHumanF.activeSelf || pelaajaHumanM.activeSelf)
                    {
                        Debug.LogError("Human: Huono osuma, ja  manaa on, Skeletoniin, tee 15 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 15;
                        mana.MyCurrentValue -= 2;
                        hHumanOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin2());
                    }

                    if (pelaajaElfF.activeSelf || pelaajaElfM.activeSelf)
                    {
                        Debug.LogError("Elf: Huono osuma, ja  manaa on, Skeletoniin, tee 15 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 15;
                        mana.MyCurrentValue -= 2;
                        hElfOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin3());
                    }

                }

                else if (xPos >= MinVal && xPos <= MaxVal && mana.MyCurrentValue == 0 && skeletonSpritetin.GetComponent<SpriteRenderer>().enabled == true)
                {

                    if (pelaajaOrcF.activeSelf || pelaajaOrcM.activeSelf)
                    {
                        Debug.LogError("Orc: Paras osuma, mutta ei manaa, Skeletoniin, tee 15 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 15;
                        mana.MyCurrentValue -= 2;
                        orcOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin());
                    }

                    if (pelaajaHumanF.activeSelf || pelaajaHumanM.activeSelf)
                    {
                        Debug.LogError("Human: Paras osuma, mutta ei manaa, Skeletoniin, tee 15 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 15;
                        mana.MyCurrentValue -= 2;
                        humanOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin2());
                    }

                    if (pelaajaElfF.activeSelf || pelaajaElfM.activeSelf)
                    {
                        Debug.LogError("Elf: Paras osuma, mutta ei manaa, Skeletoniin, tee 15 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 15;
                        mana.MyCurrentValue -= 2;
                        elfOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin3());
                    }

                }

                else if (xPos >= vahMinVal && xPos <= vahMaxVal && mana.MyCurrentValue == 0 && skeletonSpritetin.GetComponent<SpriteRenderer>().enabled == true)
                {

                    if (pelaajaOrcF.activeSelf || pelaajaOrcM.activeSelf)
                    {
                        Debug.LogError("Orc: Huono osuma, ja ei manaa, Skeletoniin, tee 10 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 10;
                        mana.MyCurrentValue -= 2;
                        hOrcOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin());
                    }

                    if (pelaajaHumanF.activeSelf || pelaajaHumanM.activeSelf)
                    {
                        Debug.LogError("Human: Huono osuma, ja ei manaa, Skeletoniin, tee 10 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 10;
                        mana.MyCurrentValue -= 2;
                        hHumanOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin2());
                    }

                    if (pelaajaElfF.activeSelf || pelaajaElfM.activeSelf)
                    {
                        Debug.LogError("Elf: Huono osuma, ja ei manaa, Skeletoniin, tee 10 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 10;
                        mana.MyCurrentValue -= 2;
                        hElfOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin3());
                    }
                }



                //Goblini Goblini Goblini Goblini Goblini Goblini Goblini Goblini Goblini Goblini Goblini 
                else if (xPos >= MinVal && xPos <= MaxVal && mana.MyCurrentValue >= 0 && goblinSpritetin.GetComponent<SpriteRenderer>().enabled == true)
                {
                    if (pelaajaOrcF.activeSelf || pelaajaOrcM.activeSelf)
                    {
                        Debug.LogError("Orc: Paras osuma, ja manaa on, Gobliniin, tee 15 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 15;
                        mana.MyCurrentValue -= 2;
                        orcOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin());
                    }

                    if (pelaajaHumanF.activeSelf || pelaajaHumanM.activeSelf)
                    {
                        Debug.LogError("Human: Paras osuma, ja manaa on, Gobliniin, tee 15 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 15;
                        mana.MyCurrentValue -= 2;
                        humanOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin2());
                    }

                    if (pelaajaElfF.activeSelf || pelaajaElfM.activeSelf)
                    {
                        Debug.LogError("Elf: Paras osuma, ja manaa on, Gobliniin, tee 15 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 15;
                        mana.MyCurrentValue -= 2;
                        elfOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin3());
                    }

                }

                else if (xPos >= vahMinVal && xPos <= vahMaxVal && mana.MyCurrentValue >= 0 && goblinSpritetin.GetComponent<SpriteRenderer>().enabled == true)
                {
                    if (pelaajaOrcF.activeSelf || pelaajaOrcM.activeSelf)
                    {
                        Debug.LogError("Orc: Huono osuma, ja manaa on, Gobliniin, tee 10 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 10;
                        mana.MyCurrentValue -= 2;
                        hOrcOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin());
                    }

                    if (pelaajaHumanF.activeSelf || pelaajaHumanM.activeSelf)
                    {
                        Debug.LogError("Human: Huono osuma, ja manaa on, Gobliniin, tee 10 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 10;
                        mana.MyCurrentValue -= 2;
                        hHumanOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin2());
                    }

                    if (pelaajaElfF.activeSelf || pelaajaElfM.activeSelf)
                    {
                        Debug.LogError("Elf: Huono osuma, ja manaa on, Gobliniin, tee 10 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 10;
                        mana.MyCurrentValue -= 2;
                        hElfOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin3());
                    }
                }

                else if (xPos >= MinVal && xPos <= MaxVal && mana.MyCurrentValue == 0 && goblinSpritetin.GetComponent<SpriteRenderer>().enabled == true)
                {

                    if (pelaajaOrcF.activeSelf || pelaajaOrcM.activeSelf)
                    {
                        Debug.LogError("Orc: Paras osuma, mutta ei manaa, Gobliniin, tee 10 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 15;
                        mana.MyCurrentValue -= 2;
                        orcOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin());
                    }

                    if (pelaajaHumanF.activeSelf || pelaajaHumanM.activeSelf)
                    {
                        Debug.LogError("Human: Paras osuma, mutta ei manaa, Gobliniin, tee 10 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 15;
                        mana.MyCurrentValue -= 2;
                        humanOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin2());
                    }

                    if (pelaajaElfF.activeSelf || pelaajaElfM.activeSelf)
                    {
                        Debug.LogError("Elf: Paras osuma, mutta ei manaa, Gobliniin, tee 10 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 15;
                        mana.MyCurrentValue -= 2;
                        elfOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin3());
                    }

                }

                else if (xPos >= vahMinVal && xPos <= vahMaxVal && mana.MyCurrentValue == 0 && goblinSpritetin.GetComponent<SpriteRenderer>().enabled == true)
                {
                    if (pelaajaOrcF.activeSelf || pelaajaOrcM.activeSelf)
                    {
                        Debug.LogError("Orc: Huono osuma, ja ei manaa, Gobliniin, tee 5 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 5;
                        mana.MyCurrentValue -= 2;
                        hOrcOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin());
                    }

                    if (pelaajaHumanF.activeSelf || pelaajaHumanM.activeSelf)
                    {
                        Debug.LogError("Human: Huono osuma, ja ei manaa, Gobliniin, tee 5 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 5;
                        mana.MyCurrentValue -= 2;
                        hHumanOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin2());
                    }

                    if (pelaajaElfF.activeSelf || pelaajaElfM.activeSelf)
                    {
                        Debug.LogError("Elf: Huono osuma, ja ei manaa, Gobliniin, tee 5 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 5;
                        mana.MyCurrentValue -= 2;
                        hElfOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin3());
                    }
                }


                //Gloop
                else if (xPos >= MinVal && xPos <= MaxVal && mana.MyCurrentValue >= 0 && gloopSpritetin.GetComponent<SpriteRenderer>().enabled == true)
                {
                    if (pelaajaOrcF.activeSelf || pelaajaOrcM.activeSelf)
                    {
                        Debug.LogError("Orc: Paras osuma, ja manaa on, Glooppiin, tee 12 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 12;
                        mana.MyCurrentValue -= 2;
                        orcOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin());
                    }

                    if (pelaajaHumanF.activeSelf || pelaajaHumanM.activeSelf)
                    {
                        Debug.LogError("Human: Paras osuma, ja manaa on, Glooppiin, tee 12 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 12;
                        mana.MyCurrentValue -= 2;
                        humanOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin2());
                    }

                    if (pelaajaElfF.activeSelf || pelaajaElfM.activeSelf)
                    {
                        Debug.LogError("Elf: Paras osuma, ja manaa on, Glooppiin, tee 12 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 12;
                        mana.MyCurrentValue -= 2;
                        elfOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin3());
                    }

                }

                else if (xPos >= vahMinVal && xPos <= vahMaxVal && mana.MyCurrentValue >= 0 && gloopSpritetin.GetComponent<SpriteRenderer>().enabled == true)
                {
                    if (pelaajaOrcF.activeSelf || pelaajaOrcM.activeSelf)
                    {
                        Debug.LogError("Orc: Huono osuma, ja manaa on, Glooppiin, tee 8 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 8;
                        mana.MyCurrentValue -= 2;
                        hOrcOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin());
                    }

                    if (pelaajaHumanF.activeSelf || pelaajaHumanM.activeSelf)
                    {
                        Debug.LogError("Human: Huono osuma, ja manaa on, Glooppiin, tee 8 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 8;
                        mana.MyCurrentValue -= 2;
                        hHumanOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin2());
                    }

                    if (pelaajaElfF.activeSelf || pelaajaElfM.activeSelf)
                    {
                        Debug.LogError("Elf: Huono osuma, ja manaa on, Glooppiin, tee 8 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 8;
                        mana.MyCurrentValue -= 2;
                        hElfOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin3());
                    }
                }

                else if (xPos >= MinVal && xPos <= MaxVal && mana.MyCurrentValue == 0 && gloopSpritetin.GetComponent<SpriteRenderer>().enabled == true)
                {

                    if (pelaajaOrcF.activeSelf || pelaajaOrcM.activeSelf)
                    {
                        Debug.LogError("Orc: Paras osuma, mutta ei manaa, Glooppiin, tee 8 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 8;
                        mana.MyCurrentValue -= 2;
                        orcOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin());
                    }

                    if (pelaajaHumanF.activeSelf || pelaajaHumanM.activeSelf)
                    {
                        Debug.LogError("Human: Paras osuma, mutta ei manaa, Glooppiin, tee 8 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 8;
                        mana.MyCurrentValue -= 2;
                        humanOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin2());
                    }

                    if (pelaajaElfF.activeSelf || pelaajaElfM.activeSelf)
                    {
                        Debug.LogError("Elf: Paras osuma, mutta ei manaa, Glooppiin, tee 8 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 8;
                        mana.MyCurrentValue -= 2;
                        elfOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin3());
                    }

                }

                else if (xPos >= vahMinVal && xPos <= vahMaxVal && mana.MyCurrentValue == 0 && gloopSpritetin.GetComponent<SpriteRenderer>().enabled == true)
                {
                    if (pelaajaOrcF.activeSelf || pelaajaOrcM.activeSelf)
                    {
                        Debug.LogError("Orc: Huono osuma, ja ei manaa, Glooppiin, tee 5 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 5;
                        mana.MyCurrentValue -= 2;
                        hOrcOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin());
                    }

                    if (pelaajaHumanF.activeSelf || pelaajaHumanM.activeSelf)
                    {
                        Debug.LogError("Human: Huono osuma, ja ei manaa, Glooppiin, tee 5 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 5;
                        mana.MyCurrentValue -= 2;
                        hHumanOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin2());
                    }

                    if (pelaajaElfF.activeSelf || pelaajaElfM.activeSelf)
                    {
                        Debug.LogError("Elf: Huono osuma, ja ei manaa, Glooppiin, tee 5 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 5;
                        mana.MyCurrentValue -= 2;
                        hElfOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin3());
                    }
                }



                //EkaBossi
                else if (xPos >= MinVal && xPos <= MaxVal && mana.MyCurrentValue >= 0 && ekanBossinSpritetin.GetComponent<SpriteRenderer>().enabled == true)
                {
                    if (pelaajaOrcF.activeSelf || pelaajaOrcM.activeSelf)
                    {
                        Debug.LogError("Orc: Paras osuma, ja manaa on, Bossi1, tee 10 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 10;
                        mana.MyCurrentValue -= 2;
                        orcOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin());
                    }

                    if (pelaajaHumanF.activeSelf || pelaajaHumanM.activeSelf)
                    {
                        Debug.LogError("Human: Paras osuma, ja manaa on, Bossi1, tee 10 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 10;
                        mana.MyCurrentValue -= 2;
                        humanOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin2());
                    }

                    if (pelaajaElfF.activeSelf || pelaajaElfM.activeSelf)
                    {
                        Debug.LogError("Elf: Paras osuma, ja manaa on, Bossi1, tee 10 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 10;
                        mana.MyCurrentValue -= 2;
                        elfOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin3());
                    }

                }

                else if (xPos >= vahMinVal && xPos <= vahMaxVal && mana.MyCurrentValue >= 0 && ekanBossinSpritetin.GetComponent<SpriteRenderer>().enabled == true)
                {
                    if (pelaajaOrcF.activeSelf || pelaajaOrcM.activeSelf)
                    {
                        Debug.LogError("Orc: Huono osuma, ja manaa on, Bossi1, tee 7 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 7;
                        mana.MyCurrentValue -= 2;
                        hOrcOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin());
                    }

                    if (pelaajaHumanF.activeSelf || pelaajaHumanM.activeSelf)
                    {
                        Debug.LogError("Human: Huono osuma, ja manaa on, Bossi1, tee 7 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 7;
                        mana.MyCurrentValue -= 2;
                        hHumanOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin2());
                    }

                    if (pelaajaElfF.activeSelf || pelaajaElfM.activeSelf)
                    {
                        Debug.LogError("Elf: Huono osuma, ja manaa on, Bossi1, tee 7 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 7;
                        mana.MyCurrentValue -= 2;
                        hElfOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin3());
                    }
                }

                else if (xPos >= MinVal && xPos <= MaxVal && mana.MyCurrentValue == 0 && ekanBossinSpritetin.GetComponent<SpriteRenderer>().enabled == true)
                {
                    if (pelaajaOrcF.activeSelf || pelaajaOrcM.activeSelf)
                    {
                        Debug.LogError("Orc: Paras osuma, ja ei manaa, Bossi1, tee 7 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 7;
                        mana.MyCurrentValue -= 2;
                        orcOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin());
                    }

                    if (pelaajaHumanF.activeSelf || pelaajaHumanM.activeSelf)
                    {
                        Debug.LogError("Human: Paras osuma, ja ei manaa, Bossi1, tee 7 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 7;
                        mana.MyCurrentValue -= 2;
                        humanOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin2());
                    }

                    if (pelaajaElfF.activeSelf || pelaajaElfM.activeSelf)
                    {
                        Debug.LogError("Elf: Paras osuma, ja ei manaa, Bossi1, tee 7 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 7;
                        mana.MyCurrentValue -= 2;
                        elfOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin3());
                    }

                }

                else if (xPos >= vahMinVal && xPos <= vahMaxVal && mana.MyCurrentValue == 0 && ekanBossinSpritetin.GetComponent<SpriteRenderer>().enabled == true)
                {
                    if (pelaajaOrcF.activeSelf || pelaajaOrcM.activeSelf)
                    {
                        Debug.LogError("Orc: Huono osuma, ja manaa on, Bossi1, tee 3 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 3;
                        mana.MyCurrentValue -= 2;
                        hOrcOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin());
                    }

                    if (pelaajaHumanF.activeSelf || pelaajaHumanM.activeSelf)
                    {
                        Debug.LogError("Human: Huono osuma, ja manaa on, Bossi1, tee 3 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 3;
                        mana.MyCurrentValue -= 2;
                        hHumanOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin2());
                    }

                    if (pelaajaElfF.activeSelf || pelaajaElfM.activeSelf)
                    {
                        Debug.LogError("Elf: Huono osuma, ja manaa on, Bossi1, tee 3 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 3;
                        mana.MyCurrentValue -= 2;
                        hElfOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin3());
                    }
                }

                //TokaBossi
                else if (xPos >= MinVal && xPos <= MaxVal && mana.MyCurrentValue >= 0 && tokanBossinSpritetin.GetComponent<SpriteRenderer>().enabled == true)
                {
                    if (pelaajaOrcF.activeSelf || pelaajaOrcM.activeSelf)
                    {
                        Debug.LogError("Orc: Paras osuma, ja manaa on, Bossi2, tee 8 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 8;
                        mana.MyCurrentValue -= 2;
                        orcOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin());
                    }

                    if (pelaajaHumanF.activeSelf || pelaajaHumanM.activeSelf)
                    {
                        Debug.LogError("Human: Paras osuma, ja manaa on, Bossi2, tee 8 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 8;
                        mana.MyCurrentValue -= 2;
                        humanOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin2());
                    }

                    if (pelaajaElfF.activeSelf || pelaajaElfM.activeSelf)
                    {
                        Debug.LogError("Elf: Paras osuma, ja manaa on, Bossi2, tee 8 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 8;
                        mana.MyCurrentValue -= 2;
                        elfOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin3());
                    }

                }

                else if (xPos >= vahMinVal && xPos <= vahMaxVal && mana.MyCurrentValue >= 0 && tokanBossinSpritetin.GetComponent<SpriteRenderer>().enabled == true)
                {
                    if (pelaajaOrcF.activeSelf || pelaajaOrcM.activeSelf)
                    {
                        Debug.LogError("Orc: Huono osuma, ja manaa on, Bossi2, tee 5 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 5;
                        mana.MyCurrentValue -= 2;
                        hOrcOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin());
                    }

                    if (pelaajaHumanF.activeSelf || pelaajaHumanM.activeSelf)
                    {
                        Debug.LogError("Human: Huono osuma, ja manaa on, Bossi2, tee 5 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 5;
                        mana.MyCurrentValue -= 2;
                        hHumanOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin2());
                    }

                    if (pelaajaElfF.activeSelf || pelaajaElfM.activeSelf)
                    {
                        Debug.LogError("Elf: Huono osuma, ja manaa on, Bossi2, tee 5 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 5;
                        mana.MyCurrentValue -= 2;
                        hElfOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin3());
                    }
                }

                else if (xPos >= MinVal && xPos <= MaxVal && mana.MyCurrentValue == 0 && tokanBossinSpritetin.GetComponent<SpriteRenderer>().enabled == true)
                {
                    if (pelaajaOrcF.activeSelf || pelaajaOrcM.activeSelf)
                    {
                        Debug.LogError("Orc: Paras osuma, ja ei manaa, Bossi2, tee 5 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 5;
                        mana.MyCurrentValue -= 2;
                        orcOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin());
                    }

                    if (pelaajaHumanF.activeSelf || pelaajaHumanM.activeSelf)
                    {
                        Debug.LogError("Human: Paras osuma, ja ei manaa, Bossi2, tee 5 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 5;
                        mana.MyCurrentValue -= 2;
                        humanOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin2());
                    }

                    if (pelaajaElfF.activeSelf || pelaajaElfM.activeSelf)
                    {
                        Debug.LogError("Elf: Paras osuma, ja ei manaa, Bossi2, tee 5 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 5;
                        mana.MyCurrentValue -= 2;
                        elfOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin3());
                    }

                }

                else if (xPos >= vahMinVal && xPos <= vahMaxVal && mana.MyCurrentValue == 0 && tokanBossinSpritetin.GetComponent<SpriteRenderer>().enabled == true)
                {
                    if (pelaajaOrcF.activeSelf || pelaajaOrcM.activeSelf)
                    {
                        Debug.LogError("Orc: Huono osuma, ja manaa on, Bossi2, tee 3 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 3;
                        mana.MyCurrentValue -= 2;
                        hOrcOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin());
                    }

                    if (pelaajaHumanF.activeSelf || pelaajaHumanM.activeSelf)
                    {
                        Debug.LogError("Human: Huono osuma, ja manaa on, Bossi2, tee 3 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 3;
                        mana.MyCurrentValue -= 2;
                        hHumanOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin2());
                    }

                    if (pelaajaElfF.activeSelf || pelaajaElfM.activeSelf)
                    {
                        Debug.LogError("Elf: Huono osuma, ja manaa on, Bossi2, tee 3 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 3;
                        mana.MyCurrentValue -= 2;
                        hElfOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin3());
                    }
                }


                // Vika bossi Vika bossi Vika bossi Vika bossi Vika bossi Vika bossi Vika bossi Vika bossi 
                else if (xPos >= MinVal && xPos <= MaxVal && mana.MyCurrentValue >= 0 && vikanBossinSpritetin.GetComponent<SpriteRenderer>().enabled == true)
                {
                    if (pelaajaOrcF.activeSelf || pelaajaOrcM.activeSelf)
                    {
                        Debug.LogError("Orc: Paras osuma, ja manaa on, Vika bossi, tee 5 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 5;
                        mana.MyCurrentValue -= 2;
                        orcOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin());
                    }

                    if (pelaajaHumanF.activeSelf || pelaajaHumanM.activeSelf)
                    {
                        Debug.LogError("Human: Paras osuma, ja manaa on, Vika bossi, tee 5 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 5;
                        mana.MyCurrentValue -= 2;
                        humanOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin2());
                    }

                    if (pelaajaElfF.activeSelf || pelaajaElfM.activeSelf)
                    {
                        Debug.LogError("Elf: Paras osuma, ja manaa on, Vika bossi, tee 5 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 5;
                        mana.MyCurrentValue -= 2;
                        elfOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin3());
                    }

                }

                else if (xPos >= vahMinVal && xPos <= vahMaxVal && mana.MyCurrentValue >= 0 && vikanBossinSpritetin.GetComponent<SpriteRenderer>().enabled == true)
                {
                    if (pelaajaOrcF.activeSelf || pelaajaOrcM.activeSelf)
                    {
                        Debug.LogError("Orc: Huono osuma, ja manaa on, Vika bossi, tee 3 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 3;
                        mana.MyCurrentValue -= 2;
                        hOrcOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin());
                    }

                    if (pelaajaHumanF.activeSelf || pelaajaHumanM.activeSelf)
                    {
                        Debug.LogError("Human: Huono osuma, ja manaa on, Vika bossi, tee 3 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 3;
                        mana.MyCurrentValue -= 2;
                        hHumanOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin2());
                    }

                    if (pelaajaElfF.activeSelf || pelaajaElfM.activeSelf)
                    {
                        Debug.LogError("Elf: Huono osuma, ja manaa on, Vika bossi, tee 3 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 3;
                        mana.MyCurrentValue -= 2;
                        hElfOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin3());
                    }
                }

                else if (xPos >= MinVal && xPos <= MaxVal && mana.MyCurrentValue == 0 && vikanBossinSpritetin.GetComponent<SpriteRenderer>().enabled == true)
                {
                    if (pelaajaOrcF.activeSelf || pelaajaOrcM.activeSelf)
                    {
                        Debug.LogError("Orc: Paras osuma, ja ei manaa, Vika bossi, tee 3 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 3;
                        mana.MyCurrentValue -= 2;
                        orcOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin());
                    }

                    if (pelaajaHumanF.activeSelf || pelaajaHumanM.activeSelf)
                    {
                        Debug.LogError("Human: Paras osuma, ja ei manaa, Vika bossi, tee 3 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 3;
                        mana.MyCurrentValue -= 2;
                        humanOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin2());
                    }

                    if (pelaajaElfF.activeSelf || pelaajaElfM.activeSelf)
                    {
                        Debug.LogError("Elf: Paras osuma, ja ei manaa, Vika bossi, tee 3 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 3;
                        mana.MyCurrentValue -= 2;
                        elfOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin3());
                    }

                }

                else if (xPos >= vahMinVal && xPos <= vahMaxVal && mana.MyCurrentValue == 0 && vikanBossinSpritetin.GetComponent<SpriteRenderer>().enabled == true)
                {
                    if (pelaajaOrcF.activeSelf || pelaajaOrcM.activeSelf)
                    {
                        Debug.LogError("Orc: Huono osuma, ja manaa on, Vika bossi, tee 1 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 1;
                        mana.MyCurrentValue -= 2;
                        hOrcOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin());
                    }

                    if (pelaajaHumanF.activeSelf || pelaajaHumanM.activeSelf)
                    {
                        Debug.LogError("Human: Huono osuma, ja manaa on, Vika bossi, tee 1 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 1;
                        mana.MyCurrentValue -= 2;
                        hHumanOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin2());
                    }

                    if (pelaajaElfF.activeSelf || pelaajaElfM.activeSelf)
                    {
                        Debug.LogError("Elf: Huono osuma, ja manaa on, Vika bossi, tee 1 damagee");
                        RandomizeHitArea();
                        vihuHealth.MyCurrentValue -= 1;
                        mana.MyCurrentValue -= 2;
                        hElfOsumaVihuun.GetComponent<Image>().enabled = true;

                        StartCoroutine(AjanLaskin3());
                    }
                }


                // else if (xPos >= MinVal != xPos <= MaxVal)
                else
                {
                    Debug.LogError("Ohi, otit damagee");
                    RandomizeHitArea();
                    health.MyCurrentValue -= 15;
                    mana.MyCurrentValue -= 2;

                    osumaPelaajaan.GetComponent<Image>().enabled = true;

                    StartCoroutine(AjanLaskin4());
                }

            }
        }
    }
}