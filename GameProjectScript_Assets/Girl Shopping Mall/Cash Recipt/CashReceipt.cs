using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CashReceipt : MonoBehaviour
{
  //  //Get Parent GameObject of ProductList and PriceList
  //  [SerializeField] GameObject product;
  //  [SerializeField] GameObject price;
  //
  //  //ProductList and PriceList Array for store the child text Game Objects
  //  GameObject[] productList;
  //  GameObject[] priceList;
  //
  //  //Field for get Total Text Object TextMeshProUGUI Component
  //  [SerializeField] TextMeshProUGUI totalText;
  //
  //  // Start is called before the first frame update
  //  void Start()
  //  {
  //      //Set the Size of ProductList & PriceList Array with respect to their childs
  //     productList = new GameObject[product.transform.childCount];
  //     priceList = new GameObject[price.transform.childCount];
  //
  //      //Get ProductList & PriceList Child Game Objects
  //      for(int l = 0; l < productList.Length; l++)
  //      {
  //         productList[l] = product.transform.GetChild(l).gameObject;
  //         priceList[l] = price.transform.GetChild(l).gameObject;
  //      }
  //  }
  //  //SetProductNameAndProductPrice Method will set the products name and products price at Panel
  //  public void SetProductNameAndProductPrice()
  //  {
  //      int sum = 0;
  //      for (int i = 0; i < ProductPrice.inst.productName.Length; i++)
  //      {
  //          productList[i].GetComponent<TextMeshProUGUI>().text = ProductPrice.inst.productName[i];
  //          priceList[i].GetComponent<TextMeshProUGUI>().text = ProductPrice.inst.price[i];
  //          //Sum Price of all Products
  //          sum += int.Parse(ProductPrice.inst.price[i]);
  //      }
  //      //Set Total Price at Total Text Field
  //      totalText.text = sum.ToString();
  //      //Subtract Total product price from Cash Pref
  //      PlayerPrefsManager.CashPref -= sum;
  //      
  //  }
  //  public void setRemainCash()
  //  {
  //      //Set Remaining Cash in Cash Box
  //      GameManager.instance.cashBox.text = PlayerPrefsManager.CashPref.ToString() + "$";
  //  }
  //  //AfterPayBill Method will Invoke the AfterPayBill UnityEvent
  //  public void AfterPayBill()
  //  {
  //      ProductPrice.inst.AfterBillPay.Invoke();
  //  }
}
