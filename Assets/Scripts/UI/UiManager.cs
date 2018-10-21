using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
	
	public class UiManager : MonoBehaviour {

		
		[SerializeField]
		private GameObject _tooltip;
		
		// Use this for initialization
		void Start () {
		
		}
	
		// Update is called once per frame
		void Update () {
		
		}
		
		public void ShowToolTip()
		{
			_tooltip.SetActive(true);
		}

		public void HideToolTip()
		{
			_tooltip.SetActive(false);
		}
	}

}
