using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireShoot : MonoBehaviour
{
    public GameObject bullet;   //bullet get bullet prefab
    public Transform barrel;    //barrwel get barrel game object

    public Transform crosshair;  //Get crosshair
    Vector3 direction;
    //Sound Fields
    private AudioSource source;
    public AudioClip clipSound;

    private void Awake()
    {
        source = gameObject.GetComponent<AudioSource>();
    }

   // void Update()
   // {
   //   // //when left mouse button press
   //    if (Input.GetMouseButtonDown(0))
   //    {
   //         Firing();
   //    }
   // }

    public void Firing() 
    {
        //Cast ray from main camera at position of crosshair
        Ray ray = Camera.main.ScreenPointToRay(crosshair.position);
        //Get raycast information
        RaycastHit hit;
        //if ray hit something
        if (Physics.Raycast(ray, out hit))
        {
            //Calculate Direction
            //Direction = Destination - current position
            direction = (hit.point - barrel.position).normalized;
            //Instantiate Bullet Prefab at barrel position
            GameObject clone = Instantiate(bullet, barrel.position, Quaternion.identity);

            //Play Fire Sound
            source.clip = clipSound;
            source.Play();

            //Update score at hit target
            if (hit.collider.CompareTag("Target"))
            {
                PlayerPrefsManager.ScorePref++;
            }

            //set direction for bullet in, DirectionSetup method
            clone.GetComponent<Bullet>().DirectionSetup(direction);
        }
    }
    
}
