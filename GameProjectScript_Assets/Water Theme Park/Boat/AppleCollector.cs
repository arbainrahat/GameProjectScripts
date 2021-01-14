using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleCollector : MonoBehaviour
{
    [SerializeField] GameObject coinParticle;
    GameObject temp;
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
            PlayerPrefsManager.CashPref += 5;
            temp=Instantiate(coinParticle, transform.position, Quaternion.identity) as GameObject;
            audioSource.PlayOneShot(audioClip);
            Destroy(gameObject,audioClip.length);
            Destroy(temp, 1f);
        }
    }

}
