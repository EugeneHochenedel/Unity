using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{

	public float Velocity;
	public bool Moving = false;
	public bool Limit = false;

	void Start()
	{
		gameObject.transform.position = new Vector3(-4.5f,0.5f,-4.5f);
	}
	
	void LinearInterpolation(float fX, float fY, float fZ)
	{
		gameObject.transform.position = new Vector3(transform.position.x + fX, transform.position.y + fY, transform.position.z + fZ);
	}

	void Update()
	{
		if(Input.GetKey("space"))
		{
			LinearInterpolation(0, 5 * Time.deltaTime * Velocity, 0);
		}

		if (Input.GetMouseButton(0))
		{
			Moving = true;
		}

		if(transform.position.x <= -4.5f && transform.position.z <= -4.5f)
		{
			Limit = false;
		}

		if (Moving == true && Limit == false)
		{
			gameObject.transform.position = new Vector3(transform.position.x + 1 * Time.deltaTime * Velocity, transform.position.y, transform.position.z + 1 * Time.deltaTime * Velocity);
		}

		if (transform.position.x >= 4.5f && transform.position.z >= 4.5f)
		{
			Limit = true;
		}
		if (Moving == true && Limit == true)
		{
			gameObject.transform.position = new Vector3(transform.position.x - 1 * Time.deltaTime * Velocity, transform.position.y, transform.position.z - 1 * Time.deltaTime * Velocity);
		}
	}
} 

/*

    Move an object from one place to another over time with one button press

    Do not user transform.Translate or Lerp functions.

    You will need a start and end points and a Velocity
*/