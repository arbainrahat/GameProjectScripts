using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StitchDressSize : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    //DataFields
    [SerializeField] GameObject movingHand;  //Get respective movingHand game object
    [SerializeField] GameObject movingText;  //Get movingText game object
    [SerializeField] GameObject line;        //Get line game object

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //On Drag Start, Deactive movingHand
        movingHand.SetActive(false);
    }

    public void OnDrag(PointerEventData eventData)
    {  
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        movingText.SetActive(true);       //Active movingText object
        line.SetActive(true);             //Active line object
        gameObject.SetActive(false);      //DeActive this Drag Area Object
    }
}
