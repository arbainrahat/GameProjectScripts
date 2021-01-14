using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    //Private DataFields
    float currentTime = 0f;
    float startTime = 60f;
    float minTime;
    float timer;

    //Field for get text UI of Timer
    [SerializeField]Text countText;
    [SerializeField] GameObject textObject;
    Text comp;

    // Start is called before the first frame update
    void Start()
    {
        //Initialize Time Here
        currentTime = startTime;
        minTime = 4f;
        comp = textObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        currentTime -= 1 * Time.deltaTime;
        //Change Time to Text UI
        countText.text = minTime+":"+currentTime.ToString("0");
        if (currentTime <= 0)
        {
            minTime -= 1;
            if (minTime >= 0)
            {
                currentTime = 60f;
            }
            else
            {
                currentTime = 0f;
            }
        }
        
        //Change Text Color if Time 20s
        if ( minTime <= 0 && currentTime <= 20f)
        {
            countText.color = Color.red;
            //Fade In or Out Text
            
                if (timer >= 0.5f)
                {
                    comp.enabled = false;
                }
                if (timer >= 1f)
                {
                    comp.enabled = true;
                    timer = 0f;
                }
            
        }
        
        //Set Zero if Time Complete
        if (currentTime<=0 && minTime <= 0)
        {
         countText.text = 0 + ":" + 0;
            GameManager.instance.losePanel.SetActive(true);
           
        }
    }
    //Set Timer Time
    public void SetTimerTime()
    {
        minTime = 1f;
    }
    
}
