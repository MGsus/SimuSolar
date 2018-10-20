using TMPro;
using UnityEngine;

namespace UI
{
	public class ResourcesScript : MonoBehaviour
	{
		public TextMeshProUGUI _timeText;
		private GameManager _manager;

		// Use this for initialization
		void Start()
		{
			_manager = GameObject.FindGameObjectWithTag("Juego").GetComponent(typeof(GameManager)) as GameManager;
			Debug.Log("inicial: " + _manager._Time);
		}

		// Update is called once per frame
		void FixedUpdate()
		{
			_timeText.text = "Tiempo: " + _manager._Time.ToString("F1");
			if (_manager._Time.ToString("F1") == "60")
			{
			}

			//Debug.Log(_manager._Time);
		}
	}
}