using UnityEngine;

public class MouseController : MonoBehaviour
{
	private Vector3 _lastFramePosition;
	private Vector3 _currPosition;
	public GameObject Cursor;

	// Use this for initialization
	private void Start()
	{
	}

	// Update is called once per frame
	private void Update()
	{
		_currPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 1f));
		// Update cursor position
		Cursor.transform.position = _currPosition;
	}
}
