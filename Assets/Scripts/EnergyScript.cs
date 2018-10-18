using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;

public class EnergyScript : MonoBehaviour
{
	public TextMeshProUGUI _timeText;
	private int _time = 0;

	// Use this for initialization
	void Start()
	{
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		_timeText.text = "Tiempo: "+_time.ToString();
		if (Input.GetMouseButtonDown(1))
		{
			_time++;
		}
	}
}
