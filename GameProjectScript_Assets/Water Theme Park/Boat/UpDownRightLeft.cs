using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UpDownRightLeft : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool ispressed = false;
    public string tagBtn;

    [SerializeField] boat boatComp;
    [SerializeField] Animator anim;
    [SerializeField] GameObject boatPlayer;
    Animator playerAnim;

    [SerializeField] GameObject parTicle;
    [SerializeField] GameObject splashParticle;

    private void Start()
    {
        if (PlayerPrefsManager.CharacterPref == 0)
        {
            playerAnim = boatPlayer.transform.GetChild(0).GetComponent<Animator>();
        }
        else if (PlayerPrefsManager.CharacterPref == 1)
        {
            playerAnim = boatPlayer.transform.GetChild(1).GetComponent<Animator>();
        }
    }

    void Update()
    {
        //Call associate methods from boat script component at the base of tagBtn

        if (ispressed && tagBtn == "Up")
        {
            boatComp.Up(); 
        }

        if(ispressed && tagBtn == "Back")
        {
            boatComp.Back();
        }

        if (ispressed && tagBtn == "Right")
        {
            boatComp.Right();
            anim.SetBool("RightTilt" , true);
            anim.SetBool("LeftTilt", false);

            playerAnim.SetBool("Right",true);
            playerAnim.SetBool("Front", false);
        }

        if (ispressed && tagBtn == "Left")
        {
            boatComp.Left();
            anim.SetBool("LeftTilt", true);
            anim.SetBool("RightTilt", false);

            playerAnim.SetBool("Left", true);
            playerAnim.SetBool("Front", false);
        }

    }

    //on mouse click update ispressed field

    public void OnPointerDown(PointerEventData eventData)
    {
        ispressed = true;
        parTicle.SetActive(true);
        splashParticle.SetActive(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ispressed = false;

        anim.SetBool("RightTilt", false);
        anim.SetBool("LeftTilt", false);

        parTicle.SetActive(false);
        splashParticle.SetActive(false);

        playerAnim.SetBool("Right", false);
        playerAnim.SetBool("Front", true);

        playerAnim.SetBool("Left", false);
        playerAnim.SetBool("Front", true);
    }
}
