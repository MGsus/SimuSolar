using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
	private Vector3 _lastFramePosition;
	private Vector3 _currPosition;
	private Camera _camera;

	// Use this for initialization
	void Start()
	{
		_camera = Camera.main;
	}

	// Update is called once per frame
	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			_currPosition = _camera.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 10f));
			/*var ray = _camera.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit))
			{
				lastFramePosition = hit.point;
			}*/

			Debug.Log("Posición con ScreenToWorldPoint" + _currPosition);
		}

		if (Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))
		{
			Vector3 diff = _lastFramePosition - _currPosition;
			_camera.transform.Translate(diff);
		}

		_lastFramePosition = _currPosition;
	}
}
