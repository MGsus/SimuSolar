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
	private Vector3 _currPosition;
	private Vector3 _lastFramePosition;

	// Use this for initialization
	private void Start()
	{
		_manager = GameObject.FindGameObjectWithTag("Juego").GetComponent(typeof(GameManager)) as GameManager;
	}

	// Update is called once per frame
	private void Update()
	{
	}

	private void ReleaseIfClicked()
	{
		if (Input.GetMouseButtonDown(2)) _newPane = null;
	}

	public void AddAgent()
	{
		_newPane = Instantiate(_pane);
		MoveCurrentObjectToMouse();
		ReleaseIfClicked();
	}

	private void MoveCurrentObjectToMouse()
	{
		_currPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 5.0f));
		_newPane.transform.position = _currPosition;
		
		
//		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//		RaycastHit hit;
//		if (Physics.Raycast(ray,out hit))
//		{
//			var nPos = hit.point + new Vector3(12f, 0, -6f);
//			Debug.Log("Entra pos ground: "+hit.point);
//			_newPane.transform.position = nPos;
//		}
	}
}
