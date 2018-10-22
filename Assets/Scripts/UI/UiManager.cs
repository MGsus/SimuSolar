using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
	
	public class UIManager : MonoBehaviour
	{

		public static UIManager Instance = null;
		
		[SerializeField]
		private GameObject _tooltip;

		private void Awake()
		{
			if (Instance == null)
			{
				Instance = this;
			}
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
