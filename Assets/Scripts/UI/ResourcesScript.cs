using System;
using System.Globalization;
using TMPro;
using UnityEngine;

namespace UI
{
	public class ResourcesScript : MonoBehaviour
	{
		public TextMeshProUGUI _timeText;
		public TextMeshProUGUI _moneyText;
		public TextMeshProUGUI _dayText;
		private GameManager _manager;
		private int _timeInMin, _timeInHh=0, _timeInDays, _timeInSec;

		// Use this for initialization
		void Start()
		{
			_manager = GameObject.FindGameObjectWithTag("Juego").GetComponent(typeof(GameManager)) as GameManager;
		}

		// Update is called once per frame
		void FixedUpdate()
		{
			// Time
			_timeInSec = (int) ((_manager._Time) % 60);
			_timeInMin = (int)(_manager._Time / 0x3C) % 60;
			_timeInHh = (int) (_manager._Time / 3600) % 24;
			_timeInDays = (int)(_manager._Time / 86400) % 30;
			// UIText
			_timeText.text = "Hora: " + _timeInHh.ToString("00;F1") + ":" + _timeInMin.ToString("00;F1") + ":" +
			                 _timeInSec.ToString("00;F1");
			_dayText.text = "Día: "+ _timeInDays.ToString("00;F1");
			

			// Money
			// 472.28 valor kWh
			_moneyText.text = "Capital: " + _manager._Money.ToString("C");
		}
	}
}