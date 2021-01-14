using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{
    public GameObject[] checkpoints;
    public int checkPoint_Count;


    // Start is called before the first frame update
    void Start()
    {
        checkPoint_Count = checkpoints.Length;
    }

    // Update is called once per frame
    void Update()
    {

        if(checkPoint_Count == 0)
        {
            GameManager.instance.Complete();
        }
    }
}
