using UnityEngine;

public class MouseController : MonoBehaviour
{
	private Vector3 _lastFramePosition;
	private Vector3 _currPosition;
	public GameObject Cursor;
	public GameObject Canvas;

	// Use this for initialization
	private void Start()
	{
	}

	/// <summary>
	/// Gets the mouse position in world space.
	/// </summary>
	public Vector3 GetMousePosition()
	{
		return _currPosition;
	}

	// Update is called once per frame
	private void Update()
	{
		_currPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 1f));
		// Update cursor position
		Cursor.transform.position = _currPosition;
	}
}
