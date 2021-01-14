using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ClothSelect : MonoBehaviour
{
    //public Fields for get text
    // public Text txt;

    //private integer type for check Cloth Select Count
    private int counter = 0;
    //clothSelectExit_Button refernce get field
    [SerializeField] GameObject clothSelectExit_Button;

    //public GameObjects Arrays for get GameObjects
    public GameObject[] before;
    public GameObject[] after;

    [Header("Cloth Select Exit")]
    //Unity function for perform actions
    public UnityEvent AfterClothExit;
   
    void Update()
    {
        try
        {
            //If Left Mouse button press
            if (Input.GetMouseButtonDown(0))
            {
                //Cast array from camera at the position of mouse
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                //Get Raycast Information
                RaycastHit hit;

                //if Ray hit to someone
                if (Physics.Raycast(ray, out hit))
                {
                    //Display name of hit object
                   // txt.text = hit.transform.name.ToString();

                    //Convert string name of hit object into integer
                    int d = int.Parse(hit.transform.name);

                    //Loop for active and Deactive gameobjects after click
                    for (int i = 0; i <= before.Length; i++)
                    {
                        //if value of i is equal to hit game object
                        if (i == d)
                        {
                            //Start Coroutine AnimPlay
                            StartCoroutine(AnimPlay(hit,i));

                            //Add 1 if cloth Select
                            counter ++;
                        }
                       
                    }
                    //if counter value is 2 than disable ClothSelect component and no more cloth will be select
                    if (counter >= 2)
                    {
                        gameObject.GetComponent<ClothSelect>().enabled = false;
                        //Active exit button
                        clothSelectExit_Button.SetActive(true);
                    }

                }
                

            }
        }
        catch(Exception e)
        {
           
        }
    }

    public void ActionExitButton()
    {
        AfterClothExit.Invoke();
    }

    IEnumerator AnimPlay(RaycastHit hit, int i)
    {
        //Play Animation of hit gameObject
        hit.transform.gameObject.GetComponent<Animator>().SetBool("play", true);
       yield return new WaitForSeconds(1f);
        //Active and Deactive Cloth
        before[i].SetActive(false);
        after[i].SetActive(true);
    }
}
