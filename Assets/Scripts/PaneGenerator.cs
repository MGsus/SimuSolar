using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;

public class PaneGenerator : MonoBehaviour
{
	public GameObject _pane;
	private GameObject _newPane;
	private GameManager _manager;
	private Camera _camera;
	private Vector3 _currPosition;
	private Vector3 _lastFramePosition;

	// Use this for initialization
	void Start()
	{
		_camera = Camera.main;
		_manager = GameObject.FindGameObjectWithTag("Juego").GetComponent(typeof(GameManager)) as GameManager;
	}

	// Update is called once per frame
	void Update()
	{
	}

	private void MoveCurrentObjectToMouse()
	{
		_currPosition = _camera.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 10f));
		_newPane.transform.position = _currPosition;
		if (Input.GetMouseButtonDown(0))
		{
			var diff = _lastFramePosition - _currPosition;
			_newPane.transform.Translate(diff);
		}

		_lastFramePosition = _currPosition;
	}

	private void ReleaseIfClicked()
	{
		if (Input.GetMouseButtonDown(1))
		{
			_newPane = null;
		}
	}
	
	public void AddAgent()
	{
		_newPane = Instantiate(_pane);
		MoveCurrentObjectToMouse();
	}
}
