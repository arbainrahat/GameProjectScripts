using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class BabyBathParticles : MonoBehaviour
{
    public UnityEvent AfterShower;

    public GameObject showerParticle;
    public GameObject SoapParticle;


    public GameObject Timer;
    public Image fillBar;

    public Image soapScreen;
    public GameObject kittenBathCharacter;

    //public GameObject Drag;

    

    private void Start()
    {
       
        fillBar.fillAmount = 0;
       
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Shower")
        {

            //print("Shower Particle");
            showerParticle.SetActive(true);
            kittenBathCharacter.GetComponent<Animator>().Play("Jump");
            
            Timer.SetActive(true);
            if (fillBar.fillAmount >= 1)
            {
                fillBar.fillAmount = 0;
            }

            DragDrop.objDragDrop.BabyHand.SetActive(false);
            //Drag.GetComponent<DragDrop>().BabyHand.SetActive(false);

        }

        if (collision.tag == "Soap")
        {
            SoapParticle.SetActive(true);
            kittenBathCharacter.GetComponent<Animator>().Play("Jump");
            soapScreen.color = new Color(1, 1, 1, 0.2f);
            Timer.SetActive(true);

           DragDrop.objDragDrop.BabyHand.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Soap")
        {

           StartCoroutine(Barfill());

        }

        if (collision.tag == "Shower")
        {
            StartCoroutine(Barfill());

        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Shower")
        {

           // print("Shower Particle");
            showerParticle.SetActive(false);
            kittenBathCharacter.GetComponent<Animator>().Play("Idle");

            StopAllCoroutines();
        }

        if (collision.tag == "Soap")
        {
            SoapParticle.SetActive(false);
            kittenBathCharacter.GetComponent<Animator>().Play("Idle");
            StopAllCoroutines();
        }


        
    }

    IEnumerator Barfill()
    {
        while (fillBar.fillAmount <= 1)
        {
            
                fillBar.fillAmount += 0.001f;
                yield return new WaitForSeconds(0.5f);
            
            if (fillBar.fillAmount >= 1)
            {
                kittenBathCharacter.GetComponent<Animator>().Play("Idle");
                Timer.SetActive(false);

            }
        }

   }



}
