using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.GlobalIllumination;

public class SunScript : MonoBehaviour
{
	private GameManager _manager;
	private float _smooth = 10000f;
	private float _ang;
	private int _energy = 0;
	public int Energy { get; set; }
	private int _timeOn;
	private float _timeDelay = 0.0f;
	

	// Use this for initialization
	void Start()
	{
		_manager = GameObject.FindGameObjectWithTag("Juego").GetComponent(typeof(GameManager)) as GameManager;
	}

	
	
	// Update is called once per frame
	void FixedUpdate()
	{
		// Sun Rotation
		//30,-30,0 = sunrise
		//90,-30,0 = High noon
		//180,-30,0 = sunset
		//-90,-30,0 = Midnight
		_ang = ((int) (_manager._Time / 3600) % 24) - 15;
		Quaternion target = Quaternion.Euler(_ang, 0, 0);
//		transform.rotation = Quaternion.Slerp(transform.rotation, target,);

		// Sun Ray
		Vector3 fwd = transform.TransformDirection(transform.forward);
		RaycastHit hit;
		if (Physics.BoxCast(GetComponent<Collider>().bounds.center, GetComponent<Collider>().bounds.size, fwd, out hit))
		{
			if (hit.collider.name == "Panel(Clone)")
			{
				OnTriggerStay(hit.collider);
			}
		}
	}


	private void OnTriggerStay(Collider other)
	{
		_timeOn+= (int)Time.deltaTime;
		_energy = (244 / 1000) * ((_timeOn / 3600) % 24);
		Debug.Log(other.name);
		Debug.Log(_energy);
	}
}
