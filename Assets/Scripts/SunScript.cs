using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class SunScript : MonoBehaviour
{
	private GameManager _manager;
	private float _smooth = 1.0f;
	private float _tetha = 0;

	// Use this for initialization
	void Start()
	{
		_manager = GameObject.FindGameObjectWithTag("Juego").GetComponent(typeof(GameManager)) as GameManager;
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		_tetha = _manager._Time;
		Quaternion target = Quaternion.Euler(_tetha, 0, 0);
		transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * _smooth);
	}
}
