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
        private UIManager _uiManager;

        private void Start()
        {
            _uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent(typeof(UIManager)) as UIManager;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            // Show tooltip
            _uiManager.ShowToolTip();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            // Hide tooltip
            _uiManager.HideToolTip();
        }
    }
}