using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    private RectTransform itemRect;
    public RectTransform itemHolderRect;

    [SerializeField] private Canvas canvas;

    public GameObject SoapHand;
    public GameObject BabyHand;
    public GameObject ShowerHand;

    public Image fill;
    public GameObject shower;
    public GameObject soap;
    public Image soapScr;

    public GameObject eventAfterShower;

    public static DragDrop objDragDrop;

    public GameObject sparkleParticle;
    public GameObject SoapParticles;


    private void Start()
    {
        itemRect = GetComponent<RectTransform>();
        objDragDrop = this;
    }


    public void OnPointerDown(PointerEventData eventData)
    {
       // Debug.Log("PointerDown");
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        // Debug.Log("DragStart");
        if (gameObject.tag == "Soap")
        {
            SoapHand.SetActive(false);
            BabyHand.SetActive(true);

        }

        if (gameObject.tag == "Shower")
        {
           

                ShowerHand.SetActive(false);
                BabyHand.SetActive(true);
            
        }
    }


    public void OnDrag(PointerEventData eventData)
    {
        itemRect.anchoredPosition += eventData.delta / canvas.scaleFactor;
        // Debug.Log("OnDrag");
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        itemRect.anchoredPosition = itemHolderRect.anchoredPosition;

        if (gameObject.tag == "Soap")
        {
            if (fill.fillAmount >= 1)
            {
                soap.SetActive(false);
                SoapParticles.SetActive(false);
                shower.SetActive(true);
                ShowerHand.SetActive(true);
                shower.GetComponent<Image>().raycastTarget = enabled;
                soap.GetComponent<Image>().raycastTarget = !enabled;

            }
        }

        if (gameObject.tag == "Shower")
        {
            if (fill.fillAmount >= 1)
            {
                shower.GetComponent<Image>().enabled = false;
                sparkleParticle.SetActive(true);
                soapScr.color = new Color(1, 1, 1, 0f);
                shower.GetComponent<Image>().raycastTarget = !enabled;

                StartCoroutine(forDelay());

                //Call AfterShower Event

               
            }
        }


        IEnumerator forDelay()
        {
            yield return new WaitForSeconds(5);
            eventAfterShower.GetComponent<BabyBathParticles>().AfterShower.Invoke();

        }

        // Debug.Log("DragEnd");
    }

    


    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.tag == "Baby")
    //    {
    //
    //      //  print("Collide with baby");
    //    }
    //   
    //}
}