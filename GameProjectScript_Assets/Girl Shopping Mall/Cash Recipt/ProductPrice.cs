using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
public class ProductPrice : MonoBehaviour
{
   
    public TextMeshProUGUI[] Price,PName;
    public TextMeshProUGUI Total;
    public Button BuyButton;

    //Sring Array for ProductNames & ProductPrice 
    public  string[] productName;
    public  int[] prices;
    public int TotalPrice;
    //Unity Event Variable
    public UnityEvent AfterBillPay;
    public void Start()
    {

        for (int i=0;i<Price.Length;i++)
        {
            Price[i].text = prices[i].ToString();
            TotalPrice += prices[i];
            print(TotalPrice);
        }
        for (int i = 0; i < PName.Length; i++)
        {
            PName[i].text = productName[i].ToString();
        }
        Total.text = TotalPrice.ToString() + "$";

        BuyButton.onClick.RemoveAllListeners();
        BuyButton.onClick.AddListener(Buy);

    }
    public void Buy()
    {
        PlayerPrefsManager.CashPref -= TotalPrice;
        GameManager.instance.cashBox.text = PlayerPrefsManager.CashPref.ToString() + "$";
        Invoke("EventAfter",1f);
    }

    public void EventAfter()
    {
        AfterBillPay.Invoke();
    }
    
}
