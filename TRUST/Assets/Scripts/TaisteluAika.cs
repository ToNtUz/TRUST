using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class TaisteluAika : MonoBehaviour
//{
//    float nykyinenAika;
//    float aloitusAika = 30f;
//    GameObject kuolemaCanvas;
//    GameObject taisteluCanvas;

//    [SerializeField] Text aikalaskuriTeksi;



//    // Start is called before the first frame update
//    void Start()
//    {
//        nykyinenAika = aloitusAika;
//        kuolemaCanvas = GameObject.Find("YouDiedCanvas");
//        taisteluCanvas = GameObject.Find("TaisteluCanvas");
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (taisteluCanvas.GetComponent<Canvas>().enabled == true)
//        {

//            nykyinenAika -= 1 * Time.deltaTime;
//            aikalaskuriTeksi.text = nykyinenAika.ToString("0.0");

//            if (nykyinenAika <= 0)
//            {
//                nykyinenAika = 0;
//                kuolemaCanvas.GetComponent<Canvas>().enabled = true;

//            }

//        }

//        if (taisteluCanvas.GetComponent<Canvas>().enabled == false)
//        {
//            nykyinenAika = 30f;
//        }




//    }
//}
