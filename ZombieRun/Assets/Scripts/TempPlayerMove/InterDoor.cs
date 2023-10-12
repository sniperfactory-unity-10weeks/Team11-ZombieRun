using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterDoor : MonoBehaviour
{
	Vector3 RDoorBackPoint;
	Vector3 LDoorBackPoint;
	Vector3 OneDoorBackPoint;
	Vector3 OneDoor2BackPoint;
	bool canOpen;

	void Start()
	{
		if (this.gameObject.tag == "RDoor")
		{
			RDoorBackPoint = transform.position;
		}
		else if (this.gameObject.tag == "LDoor")
		{
			LDoorBackPoint = transform.position;
		}
		else if(this.gameObject.tag == "OneDoor")
		{
			OneDoorBackPoint = transform.position;
		}
		else if(gameObject.tag == "OneDoor2")
		{
			OneDoor2BackPoint = transform.position;
		}
	}

	private void FixedUpdate()
	{
		if(canOpen)
		{
			if (this.gameObject.tag == "RDoor")
			{
				this.transform.position = Vector3.Lerp(this.transform.position
					, new Vector3(-3, 0, 40.81203f), 5*Time.deltaTime);
			}
			else if (this.gameObject.tag == "LDoor")
			{
				this.transform.position = Vector3.Lerp(this.transform.position
					, new Vector3(0, 0, 40.81203f), 5 * Time.deltaTime);
			}
			else if(this.gameObject.tag == "OneDoor")
			{
				this.transform.position = Vector3.Lerp(this.transform.position
					, new Vector3(-11.46f, 0, 25), 5 * Time.deltaTime);
			}
			else if( this.gameObject.tag == "OneDoor2")
			{
				this.transform.position = Vector3.Lerp(this.transform.position
					, new Vector3(11.65f, 0, 32), 5 * Time.deltaTime);
			}
		}
		else
		{
			if (this.gameObject.tag == "RDoor")
			{
				this.transform.position = Vector3.Lerp(this.transform.position
					, RDoorBackPoint, 5 * Time.deltaTime);
			}
			else if (this.gameObject.tag == "LDoor")
			{
				this.transform.position = Vector3.Lerp(this.transform.position
					, LDoorBackPoint, 5 * Time.deltaTime);
			}
			else if( this.gameObject.tag == "OneDoor")
			{
				this.transform.position = Vector3.Lerp(this.transform.position
					, OneDoorBackPoint, 5 * Time.deltaTime);
			}
			else if (this.gameObject.tag == "OneDoor2")
			{
				this.transform.position = Vector3.Lerp(this.transform.position
					, OneDoor2BackPoint, 5 * Time.deltaTime);
			}
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			canOpen = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			canOpen = false;
		}
	}
}
