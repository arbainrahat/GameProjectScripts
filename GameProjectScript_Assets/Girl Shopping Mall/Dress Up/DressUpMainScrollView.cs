using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DressUpMainScrollView : MonoBehaviour
{
    #region DataFields

    // GameObject Type Array will hold all the dressup scrollview options
    [SerializeField] GameObject[] dressUpScrollView;
    [Header("Dress List")]
    [SerializeField] GameObject[] dressList;  //dressList Array will store the dresses
    [Header("Shoes List")]
    [SerializeField] GameObject[] shoesList;  //shoesList Array will store the shoes
    [Header("Hat List")]
    [SerializeField] GameObject[] hatList;  //hatList Array will store the hats
    [Header("Glasses List")]
    [SerializeField] GameObject[] glassesList;  //glassesList Array will store the glasses
    [Header("Wallet List")]
    [SerializeField] GameObject[] walletList;  //walletList Array will store the wallets

    #endregion
    #region Methods
    //Option method will Active the dressup scrollview option on the base on parameter value 
    // & other dressup scrollview option will DeActive
    public void Option(int hierarchyLevel)
    {
        for(int i = 0; i < dressUpScrollView.Length; i++)
        {
            //If hierarchyLevel is equal to Integer i than Active that Game Object
            if (i == hierarchyLevel)
            {
                dressUpScrollView[i].SetActive(true);
            }
            else
            {
                //All other dressup scrollviews option will DeActive
                dressUpScrollView[i].SetActive(false);
            }
        }
    }

    //DressChange Method will change the dress at the base of parameter value
    public void DressChange(int index)
    {
        for (int i = 0; i < dressList.Length; i++)
        {
            //If index value is equal to Integer i than Active that Game Object
            if (i == index)
            {
                dressList[i].SetActive(true);
            }
            else
            {
                //All other game objects will DeActive
                dressList[i].SetActive(false);
            }
        }
    }

    //ShoesChange Method will change the shoes at the base of parameter value
    public void ShoesChange(int index)
    {
        for (int i = 0; i < shoesList.Length; i++)
        {
            //If index value is equal to Integer i than Active that Game Object
            if (i == index)
            {
                shoesList[i].SetActive(true);
            }
            else
            {
                //All other game objects will DeActive
                shoesList[i].SetActive(false);
            }
        }
    }

    //HatChange Method will change the hat at the base of parameter value
    public void HatChange(int index)
    {
        for (int i = 0; i < hatList.Length; i++)
        {
            //If index value is equal to Integer i than Active that Game Object
            if (i == index)
            {
                hatList[i].SetActive(true);
            }
            else
            {
                //All other game objects will DeActive
                hatList[i].SetActive(false);
            }
        }
    }

    //GlassesChange Method will change the glasses at the base of parameter value
    public void GlassesChange(int index)
    {
        for (int i = 0; i < glassesList.Length; i++)
        {
            //If index value is equal to Integer i than Active that Game Object
            if (i == index)
            {
                glassesList[i].SetActive(true);
            }
            else
            {
                //All other game objects will DeActive
                glassesList[i].SetActive(false);
            }
        }
    }

    //WalletsChange Method will change the wallet at the base of parameter value
    public void WalletsChange(int index)
    {
        for (int i = 0; i < walletList.Length; i++)
        {
            //If index value is equal to Integer i than Active that Game Object
            if (i == index)
            {
                walletList[i].SetActive(true);
            }
            else
            {
                //All other game objects will DeActive
                walletList[i].SetActive(false);
            }
        }
    }
    #endregion
}
