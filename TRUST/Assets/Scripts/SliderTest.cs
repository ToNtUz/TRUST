using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SliderTest : MonoBehaviour
{
    public Slider mainSlider;
    GameObject fightSlider;
    public int i = 1;
    public float lerpspeed;

    void Start()
    {
        mainSlider.maxValue = 10;
        mainSlider.minValue = 1;
        mainSlider.wholeNumbers = true;
        mainSlider.value = 1;


    }

    public void ValueChange(float value)
    {



    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.H))
        //{
        //    mainSlider.value = 7;

        //    //Debug.Log("New value " + value);
        //    Debug.Log("Changed value " + mainSlider.value);

        //    /*if (value > 6)
        //    {
        //        Debug.Log("over 6");
        //    }*/
        //}

        //for (i = 1; i < 10; i++)
        //{
        //    Debug.Log("Arvo nousee");
        //    //mainSlider.value = Mathf. (Time.deltaTime * lerpspeed);

        //}

        fightSlider = GameObject.Find("Slider");

        Scene nykyinenScene = SceneManager.GetActiveScene();
        string sceneNimi = nykyinenScene.name;

        if (sceneNimi == "Taistelu" && Input.GetKeyDown(KeyCode.T))
        {

            Debug.Log("Value set to: ");
        }

    }




    // video: https://www.youtube.com/watch?v=L5wniFiuUbY


}
