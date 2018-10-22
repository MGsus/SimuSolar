using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.GlobalIllumination;

public class SunScript : MonoBehaviour
{
	private GameManager _manager;
	private float _smooth = 100f;
	private float _ang;

	// Use this for initialization
	void Start()
	{
		_manager = GameObject.FindGameObjectWithTag("Juego").GetComponent(typeof(GameManager)) as GameManager;
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		_ang = _manager._Time - 90;
		Quaternion target = Quaternion.Euler(_ang, 0, 0);
		transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * _smooth);
		Vector3 fwd = transform.TransformDirection(transform.forward);
		RaycastHit hit;
		if (Physics.BoxCast(GetComponent<Collider>().bounds.center, transform.localScale, transform.forward, out hit))
		{
			Debug.Log(hit.collider.name);
		}
	}

//	private void OnDrawGizmos()
//	{
//		Gizmos.color = Color.red;
//		Gizmos.DrawRay(transform.position,);
//	}
}
