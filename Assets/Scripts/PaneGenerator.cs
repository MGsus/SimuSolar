using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;

public class PaneGenerator : MonoBehaviour
{
	public GameObject _pane;
	private GameObject _newPane;
	private Vector3 _currPosition;
	private Vector3 _lastFramePosition;

	public void AddAgent()
	{
		_newPane = Instantiate(_pane);
		MoveCurrentObjectToMouse();
	}

	private void MoveCurrentObjectToMouse()
	{
		_currPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 5.0f));
		_newPane.transform.position = _currPosition;
	}
}
