using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaneScript : MonoBehaviour
{
	private Vector3 _spCenter;
	private Vector3 _currPosition;

	/// <summary>
	/// OnMouseDown: Mover el Panel
	/// OnMouseUp: Soltar el Panel
	/// OnMouseDrag: Mover del panel
	/// </summary>
	private void OnMouseDown()
	{
		OnMouseDrag();
	}

	private void OnMouseUp()
	{
		GetComponent<Rigidbody>().useGravity = true;
		GetComponent<Rigidbody>().mass = 100f;
		transform.rotation = Quaternion.identity;
	}

	private void OnMouseDrag()
	{
		var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (!Physics.Raycast(ray, out hit, 10f)) return;
		transform.position = hit.point + new Vector3(0, 5.0f, 0);
		transform.rotation = Quaternion.identity;
	}
}
