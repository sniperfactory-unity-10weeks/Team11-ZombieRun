using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{

	Vector3 BigRDoorBackPoint;
	Vector3 BigLDoorBackPoint;
	Vector3 OneDoor1BackPoint;
	Vector3 OneDoor2BackPoint;

	bool isOpen;

	private void Awake()
	{
		if(this.gameObject.tag == "BigRDoor")
		{
			BigRDoorBackPoint = transform.position;
		}
		else if(this.gameObject.tag == "BigLDoor")
		{
			BigLDoorBackPoint = transform.position;
		}
		else if(this.gameObject.tag == "OneDoor1")
		{
			OneDoor1BackPoint = transform.position;
		}	
		else if(this.gameObject.tag == "OneDoor2")
		{
			OneDoor2BackPoint = transform.position;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			isOpen = true;
		}
	}

	private void FixedUpdate()
	{
		if(isOpen)
		{
			if(this.gameObject.tag == "BigRDoor")
			{
				this.transform.position = Vector3.Lerp(this.transform.position
					, new Vector3(3, 0, 0), Time.deltaTime);
			}
			else if(this.gameObject.tag == "BigLDoor")
			{
				this.transform.position = Vector3.Lerp(this.transform.position
					, new Vector3(-5, 0, 0), Time.deltaTime);
			}
			else if (this.gameObject.tag == "OneDoor1")
			{
				this.transform.position = Vector3.Lerp(this.transform.position
					, new Vector3(-21, 0, 27), Time.deltaTime);
			}
			else if (this.gameObject.tag == "OneDoor2")
			{
				this.transform.position = Vector3.Lerp(this.transform.position
					, new Vector3(29, 0, 30), Time.deltaTime);
			}
		}
		else
		{
			if (this.gameObject.tag == "BigRDoor")
			{
				this.transform.position = Vector3.Lerp(this.transform.position
					, BigRDoorBackPoint, Time.deltaTime);
			}
			else if (this.gameObject.tag == "BigLDoor")
			{
				this.transform.position = Vector3.Lerp(this.transform.position
					, BigLDoorBackPoint, Time.deltaTime);
			}
			else if (this.gameObject.tag == "OneDoor1")
			{
				this.transform.position = Vector3.Lerp(this.transform.position
					, OneDoor1BackPoint, Time.deltaTime);
			}
			else if (this.gameObject.tag == "OneDoor2")
			{
				this.transform.position = Vector3.Lerp(this.transform.position
					, OneDoor2BackPoint, Time.deltaTime);
			}
		}

	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			isOpen = false;
		}
	}
}
