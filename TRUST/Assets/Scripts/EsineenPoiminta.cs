using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsineenPoiminta : MonoBehaviour
{

    [SerializeField]
    private Stat health;

    [SerializeField]
    private Stat mana;

    public GameObject nykyinenEsine = null;
    public PoimittavaEsine nykyinenEsineScript = null;
    public Inventory inventory;
    //public Inventory TaisteluInventory; 



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKey(KeyCode.E) && nykyinenEsine)
        {
            //tarkista onko tama tavara inventoryyn laitettava
            //Check if you can put this item into inventory
            if (nykyinenEsineScript.inventory)
            {
                inventory.LisaaEsine(nykyinenEsine);
            }
        }
        //Kayta esine
        //Use item
        if (Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.G) && health.MyCurrentValue != 100)
        {
            //Tarkista onko inventoryssa esine
            //Check if there is an item in the inventory
            GameObject potion = inventory.EtsiEsineTyyppi("Health");
            if ((potion != null))
            {
                //kayta esine - vaikutus
                //Use item - effect
                Debug.Log("Esine kaytettiin");

                //poista esine invista
                //Delete item from inventory
                inventory.PoistaEsine(potion);
                health.MyCurrentValue += 10;
            }


        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button2) || Input.GetKeyDown(KeyCode.H) && mana.MyCurrentValue != 100)
        {
            //Tarkista onko inventoryssa esine
            //Check if there is an item in the inventory
            GameObject stamina = inventory.EtsiEsineTyyppi("Stamina");
            if ((stamina != null))
            {

                //kayta esine - vaikutus
                Debug.Log("Esine kaytettiin");

                //poista esine invista
                inventory.PoistaEsine(stamina);
                mana.MyCurrentValue += 15;
            }
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Poimittava"))
        {
            Debug.Log(other.name);
            nykyinenEsine = other.gameObject;
            nykyinenEsineScript = nykyinenEsine.GetComponent<PoimittavaEsine>();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Poimittava"))
        {
            if(other.gameObject == nykyinenEsine)
            {
                nykyinenEsine = null;
            }

        }

        }

}
