using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTextTrigger : MonoBehaviour
{
    // DataFields for get game objects
    [SerializeField] GameObject panelText;           //panelText get the respective text of Panel
    [SerializeField] GameObject nextDragArea;        //nextDragArea get the drag area game object
    [SerializeField] GameObject nextMovehand;        //nextMoveHand get the next point hand game object

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Panel")
        {
            //When this moving text game object enter in Trigger than this text DeActive & Respective Panel text will Active
            gameObject.SetActive(false);
            panelText.SetActive(true);

            //If nextDragArea & nextMovehand not Null
            if (nextDragArea != null && nextMovehand != null)
            {
                //Set nextDragArea & nextMovehand game object set Active
                nextDragArea.SetActive(true);
                nextMovehand.SetActive(true);
            }
            else
            {
                Invoke("Complt", 1f);
            }
        }
    }

    void Complt()
    {
        GameManager.instance.Complete();
    }
}
