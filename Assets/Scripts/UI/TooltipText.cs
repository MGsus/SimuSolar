using TMPro;
using UnityEngine;

/**************************************************************************
 * Every frame, this script checks to see which tile is under the mouse
 * is under the mouse and then updates the GetComponent<Txt>.txt
 * parameter of the object it is attached to.
***************************************************************************/

namespace UI
{
	public class TooltipText : MonoBehaviour
	{
		private TextMeshProUGUI _myText;
		// Use this for initialization
		private void Start()
		{
			_myText = GetComponent<TextMeshProUGUI>();
			if (_myText== null) 
			{
				Debug.LogError("TooltipError: No 'TextMeshPro' component on this object");
				this.enabled = false;
				return;
			}
		}

		// Update is called once per frame
		private void Update()
		{
			
		}
	}
}
