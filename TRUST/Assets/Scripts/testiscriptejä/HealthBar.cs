using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    Image uf_bar_sm_energy;
    float maxHealth = 100f;
    public static float health;



    // Start is called before the first frame update
    void Start()
    {
        uf_bar_sm_energy = GetComponent<Image>();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        uf_bar_sm_energy.fillAmount = health / maxHealth;
    }
}
