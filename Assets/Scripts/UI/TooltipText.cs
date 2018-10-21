using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

/**************************************************************************
 * Every frame, this script checks to see which tile is under the mouse
 * is under the mouse and then updates the GetComponent<Txt>.txt
 * parameter of the object it is attached to.
***************************************************************************/

namespace UI
{
	public class TooltipText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
	{
		private TextMeshProUGUI _myText;
		private UiManager _uiManager;
		
//		private ObservableStack<Item> _items = new ObservableStack<Item>();
//
//		public Item _myItem
//		{
//			get
//			{
//				
//			}
//		}

//		public bool IsEmpty
//		{
//			get { return _myItems.Count == 0; }
//		}

		// Use this for initialization

		// Update is called once per frame
		private void Update()
		{
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			//show tooltip
//			if (!IsEmpty)
//			{
//				GameManager.Instance.ShowTooltip();
//				Debug.Log("Show Tooltip");
//			}

			Debug.Log("Enter");
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			// Hide tooltip
//			_uiManager.Instance.HideToolTip();
			Debug.Log("Exit");
		}
	}
}
