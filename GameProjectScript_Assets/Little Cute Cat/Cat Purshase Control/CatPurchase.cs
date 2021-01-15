using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class CatPurchase : MonoBehaviour
{
    //DataFields
    public Transform[] cameraPositions;
    public Camera cam;
    public GameObject rightButton;
    public GameObject leftButton;
    public float camSmoothSpeed;
    private int camIndex;
    public GameObject cashText;
    public GameObject priceText;
    public GameObject notEnoughCashPanel;
    public GameObject purchaseButton;
    public GameObject selectButton;
    public Image Lock;
    public UnityEvent After;
    public GameObject catCarry;

    public GameObject particle0;
    public GameObject particle1;
    public GameObject particle2;

    public GameObject player;
    public GameObject playerTimeline;
    public GameObject catHand;
    public Texture black;
    public Texture brown;
    public Texture lightbrown;

    private TextMeshProUGUI cashTxt;
    private TextMeshProUGUI priceTxt;
    //private int cash=5000;
    private int price=1500;

    private void OnEnable()
    { 
        rightButton.SetActive(true);
        leftButton.SetActive(false);
        
    }
   
    private void Start()
    {
        camIndex = 0;
        cashTxt = cashText.GetComponent<TextMeshProUGUI>();
        priceTxt = priceText.GetComponent<TextMeshProUGUI>();

        cashTxt.text = PlayerPrefsManager.CashPref.ToString()+"$";
        priceTxt.text = price.ToString() + "$";

    }
   
    private void LateUpdate()
    {
        cam.transform.position = Vector3.Lerp(cam.transform.position, cameraPositions[camIndex].position, Time.deltaTime * camSmoothSpeed);
        priceTxt.text = price.ToString() + "$";
        cashTxt.text = PlayerPrefsManager.CashPref.ToString() + "$";

        if (camIndex > 0)
        {
            leftButton.SetActive(true);
            price = 3000;
            if (camIndex == 2)
            {
                price = 2000;
            }
        }
        else
        {
            leftButton.SetActive(false);
            price = 1500;
           
        }
         if (camIndex == 2)
        {
            rightButton.SetActive(false);
        }
        else
        {
            rightButton.SetActive(true);
        }

        //for (int i = 1; i <= 3; i++)
        //{
        // print("Stop is" + PlayerPrefs.GetInt("cat" + 1));
        //print("camIndex" + camIndex);

        if (camIndex == 0)
        {
            if (PlayerPrefs.GetInt("cat" + camIndex) == 1)
            {

                purchaseButton.SetActive(false);
                selectButton.SetActive(true);

                // priceText.SetActive(false);
                Lock.enabled = false;
                priceText.transform.parent.gameObject.SetActive(false);
            }
            else
            {
                purchaseButton.SetActive(true);
                selectButton.SetActive(false);

                //priceText.SetActive(true);
                priceText.transform.parent.gameObject.SetActive(true);
                Lock.enabled = true;
            }
        }
        if (camIndex == 1)
        {
            if (PlayerPrefs.GetInt("cat" + camIndex) == 2)
            {

                purchaseButton.SetActive(false);
                selectButton.SetActive(true);

                // priceText.SetActive(false);
                Lock.enabled = false;
                priceText.transform.parent.gameObject.SetActive(false);
            }
            else
            {
                purchaseButton.SetActive(true);
                selectButton.SetActive(false);

                //priceText.SetActive(true);
                priceText.transform.parent.gameObject.SetActive(true);
                Lock.enabled = true;
            }
        }
        if (camIndex == 2)
        {
            if (PlayerPrefs.GetInt("cat" + camIndex) == 3)
            {

                purchaseButton.SetActive(false);
                selectButton.SetActive(true);

                // priceText.SetActive(false);
                Lock.enabled = false;
                priceText.transform.parent.gameObject.SetActive(false);
            }
            else
            {
                purchaseButton.SetActive(true);
                selectButton.SetActive(false);

                //priceText.SetActive(true);
                priceText.transform.parent.gameObject.SetActive(true);
                Lock.enabled = true;
            }
        }
        //}

    }
    public void Next()
    {
        camIndex++;
        
    }
    public void Previous()
    {
        camIndex--;
        
    }
    public void Purchase()
    {
        if (price <= PlayerPrefsManager.CashPref )
        {
            PlayerPrefsManager.CashPref -= price;
            if (camIndex == 0 && PlayerPrefs.GetInt("cat" + camIndex) != 1)
            {
                PlayerPrefs.SetInt("cat" + camIndex, 1);
            }
            else if(camIndex == 1 && PlayerPrefs.GetInt("cat" + camIndex) != 2)
            {
                PlayerPrefs.SetInt("cat" + camIndex, 2);
            }
            else if (camIndex == 2 && PlayerPrefs.GetInt("cat" + camIndex) != 3)
            {
                PlayerPrefs.SetInt("cat" + camIndex, 3);
            }
        }
        else
        {
            notEnoughCashPanel.SetActive(true);
        }

        if (camIndex == 0)
        {
            particle0.SetActive(true);
        }
        else if (camIndex == 1)
        {
            particle1.SetActive(true);
        }
        else
        {
            particle2.SetActive(true);
        }
    }

    public void Select()
    {
        if (camIndex == 0)
        {
            player.GetComponent<Renderer>().material.mainTexture = black;
            catCarry.GetComponent<Renderer>().material.mainTexture = black;
            catHand.GetComponent<Renderer>().material.mainTexture = black;
            PlayerPrefsManager.CatTexture = 0;
        }
        else if (camIndex == 1)
        {
            player.GetComponent<Renderer>().material.mainTexture = brown;
            catCarry.GetComponent<Renderer>().material.mainTexture = brown;
            catHand.GetComponent<Renderer>().material.mainTexture = brown;
            PlayerPrefsManager.CatTexture = 1;
        }
        else if (camIndex == 2)
        {
            player.GetComponent<Renderer>().material.mainTexture = lightbrown;
            catCarry.GetComponent<Renderer>().material.mainTexture = lightbrown;
            catHand.GetComponent<Renderer>().material.mainTexture = lightbrown;
            PlayerPrefsManager.CatTexture = 2;
        }
        After.Invoke();
    }

    //CatTexture set the texture permanent
    public void CatTexture()
    {
        if (PlayerPrefsManager.CatTexture == 0)
        {
            player.GetComponent<Renderer>().material.mainTexture = black;
            playerTimeline.GetComponent<Renderer>().material.mainTexture = black;
            catHand.GetComponent<Renderer>().material.mainTexture = black;
        }
        else if (PlayerPrefsManager.CatTexture == 1)
        {
            player.GetComponent<Renderer>().material.mainTexture = brown;
            playerTimeline.GetComponent<Renderer>().material.mainTexture = brown;
            catHand.GetComponent<Renderer>().material.mainTexture = brown;
        }
        else if (PlayerPrefsManager.CatTexture == 2)
        {
            player.GetComponent<Renderer>().material.mainTexture = lightbrown;
            playerTimeline.GetComponent<Renderer>().material.mainTexture = lightbrown;
            catHand.GetComponent<Renderer>().material.mainTexture = lightbrown;
        }
    }

    
}
