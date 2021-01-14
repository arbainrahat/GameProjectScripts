using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class boat : MonoBehaviour {

	public float turnSpeed = 1000f;
	public float accellerateSpeed = 1000f;

	private Rigidbody rbody;

	
	// Use this for initialization
	void Start () 
	{
		rbody = GetComponent<Rigidbody>();
	}
	
	
	
	
	//Boat control methods through buttons
	public void Up()
    {	
		rbody.AddForce(transform.forward  * accellerateSpeed * Time.deltaTime * -1);
	}

	public void Back()
	{
		rbody.AddForce(transform.forward * accellerateSpeed * Time.deltaTime );
	}

	public void Right()
    {
		rbody.AddTorque(0f, turnSpeed * Time.deltaTime, 0);
	
	}

	public void Left()
	{
		rbody.AddTorque(0f, turnSpeed * Time.deltaTime * -1, 0f);
	}

}
