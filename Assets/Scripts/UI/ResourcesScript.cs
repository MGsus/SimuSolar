using System.Globalization;
using TMPro;
using UnityEngine;

namespace UI
{
	public class ResourcesScript : MonoBehaviour
	{
		public TextMeshProUGUI _timeText;
		public TextMeshProUGUI _moneyText;
		private GameManager _manager;

		// Use this for initialization
		void Start()
		{
			_manager = GameObject.FindGameObjectWithTag("Juego").GetComponent(typeof(GameManager)) as GameManager;
		}

		// Update is called once per frame
		void FixedUpdate()
		{
			_timeText.text = "Tiempo: " + _manager._Time.ToString("##:##;F1");
			_moneyText.text = "Capital: " + _manager._Money.ToString("C");
			if (_manager._Time.ToString("F1") == "60")
			{
				_timeText.text = "Tiempo: " + _manager._Time.ToString("g2");
			}

			//Debug.Log(_manager._Time);
		}
	}
}