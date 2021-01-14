using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BoatCollide : MonoBehaviour
{
    public UnityEvent OnCollide;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boat"))
        {
            OnCollide.Invoke();
        }
    }
}
