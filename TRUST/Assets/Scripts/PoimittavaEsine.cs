using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoimittavaEsine : MonoBehaviour
{

    public bool inventory;      //jos totta, tama tavara voidaan lisata inviin
    public string esineTyyppi;  //Kertoo esineen tyypin

    public void TeeToimi()
    {
        //poimi ja laita inventoryyn
        gameObject.SetActive(false);
    }

}



/* Videot jarjestyksessa: 
 * https://www.youtube.com/watch?v=gGUtoy4Knnw Picking up Objects 
 * https://www.youtube.com/watch?v=VwE-Oo8Sn9A&t Adding an Item to Inventory 
 * https://www.youtube.com/watch?v=xFSAvnlmreE&t Unlocking and Opening Doors 
 * https://www.youtube.com/watch?v=ZIR8Kk5F13Y&t Using an Item From Inventory
 * https://www.youtube.com/watch?v=1w4Iw0Klnh4&t Adding Inventory UI 
 * */
