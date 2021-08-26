using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    public GameObject invCanvas;
    public GameObject[] inventory = new GameObject[5];
    public Image korvattavaKuva;
    public Image korvattavaKuva1;
    public Image korvattavaKuva2;
    public Image korvattavaKuva3;
    public Image korvattavaKuva4;
    public Button[] InventoryButtons = new Button[5];
    //public Button[] TaisteluInventoryButtons = new Button[5];
    GameObject spritePoistin;

    private void Start()
    {
        invCanvas = GameObject.Find("InventoryCanvas");
        spritePoistin = GameObject.Find("SpritePoistin");

    }

    public void LisaaEsine(GameObject esine)
    {

       
        bool esineLisatty = false;

        //etsi eka avoin paikka invissä
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null)
            {
                inventory[i] = esine;
                //Paivita UI
                //korvattavaKuva.GetComponent<Image>().overrideSprite = esine.GetComponent<SpriteRenderer>().sprite;
                InventoryButtons[i].image.overrideSprite = esine.GetComponent<SpriteRenderer>().sprite;
                //InventoryButtons[i].GetComponentInChildren<Image>().overrideSprite = esine.GetComponent<SpriteRenderer>().sprite;
                Debug.Log(esine.name + " lisattiin");
                esineLisatty = true;
                //tee jotain tavaralla
                esine.SendMessage("TeeToimi");
                break;
            }
        }

        //inventory tayna
        if (!esineLisatty)
        {
            Debug.Log("inventory tayna - tavaraa ei lisatty");
        }

         
    }

    public GameObject EtsiEsineTyyppi(string esineTyyppi)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] != null)
            {
                if (inventory[i].GetComponent<PoimittavaEsine>().esineTyyppi == esineTyyppi)
                {
                    //Etsittavan tyyppinen esine loydetty
                    return inventory[i];
                }
            }
        }   
        //Tietyn tyyppinen esine ei loydetty
        return null;
    }

    public void PoistaEsine(GameObject esine)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == esine)
            {
                //Etsittavan tyyppinen esine loydetty - poista se
                inventory[i] = null; 
                Debug.Log(esine.name + " poistettu inventorysta");
                InventoryButtons[i].image.overrideSprite = spritePoistin.GetComponent<SpriteRenderer>().sprite;
                break;
            }
        }
    }

}
