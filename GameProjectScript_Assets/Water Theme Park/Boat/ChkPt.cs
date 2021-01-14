using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChkPt : MonoBehaviour
{
    public CheckPoints comp;

    AudioSource audioSource;
    public AudioClip audioClip;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boat"))
        {
            audioSource.PlayOneShot(audioClip);
            Invoke("Delay", 0.005f);
            comp.checkPoint_Count--;
        }
    }

    void Delay()
    {
        gameObject.SetActive(false);
    }
}
