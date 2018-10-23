using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Graph
{
    public class WindowGraph : MonoBehaviour
    {
        [SerializeField] private Sprite _circleSprite;
        private RectTransform _labelTemplateX;
        private RectTransform _labelTemplateY;
        private RectTransform _dashTemplateX;
        private RectTransform _dashTemplateY;
        private RectTransform _graphContainer;
        private GameManager _manager;
        private List<GameObject> _plotPoints;
        private int Inicio = 0;

        // Use this for initialization
        private void Start()
        {
            _graphContainer = transform.Find("graphContainer").GetComponent<RectTransform>();
            _manager = GameObject.FindGameObjectWithTag("Juego").GetComponent(typeof(GameManager)) as GameManager;
            _plotPoints = new List<GameObject>();
            _labelTemplateX = _graphContainer.Find("labelTemplateX").GetComponent<RectTransform>();
            _labelTemplateY = _graphContainer.Find("labelTemplateY").GetComponent<RectTransform>();
            _dashTemplateX = _graphContainer.Find("dashTemplateX").GetComponent<RectTransform>();
            _dashTemplateY = _graphContainer.Find("dashTemplateY").GetComponent<RectTransform>();

//			ShowGraph(valueList); // Cada hora ejecutar
        }

        private void FixedUpdate()
        {
            if (Inicio != (int) (_manager._Time / 3600))
            {
                Inicio = (int) (_manager._Time / 3600);
                ShowGraph();
                PlotLines(_plotPoints);
            }
        }

        private void PlotLines(List<GameObject> listPoints)
        {
            GameObject lastCircleGameObject = null;
            foreach (var point in listPoints)
            {
                if (lastCircleGameObject != null)
                {
                    CreateDotConnection(lastCircleGameObject.GetComponent<RectTransform>().anchoredPosition,
                        point.GetComponent<RectTransform>().anchoredPosition);
                }

                lastCircleGameObject = point;
            }
        }

        private GameObject CreateCircle(Vector2 anchoredPosition)
        {
            GameObject pointer = new GameObject("circle", typeof(Image));
            pointer.transform.SetParent(_graphContainer, false);
            pointer.GetComponent<Image>().sprite = _circleSprite;
            RectTransform rectTransform = pointer.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = anchoredPosition;
            rectTransform.sizeDelta = new Vector2(11, 11);
            rectTransform.anchorMin = new Vector2(0, 0);
            rectTransform.anchorMax = new Vector2(0, 0);
            return pointer;
        }

        private void ShowGraph()
        {
            List<int> moneyLog = _manager.LogMoney;
            float graphHeight = _graphContainer.sizeDelta.y;
            float yMax = 20000000f;
            const float xSize = 50f;
            for (var i = _manager.HoraAct - 1; i < _manager.HoraAct; i++)
            {
                float xPosition = xSize + i * xSize;
                float yPosition = (moneyLog[i] / yMax) * graphHeight;
                GameObject circleGameObject = CreateCircle(new Vector2(xPosition, yPosition));
                _plotPoints.Add(circleGameObject);
                // Labels
                RectTransform labelX = Instantiate(_labelTemplateX);
                labelX.SetParent(_graphContainer,false);
                labelX.gameObject.SetActive(true);
                labelX.anchoredPosition = new Vector2(xPosition,-7f);
                labelX.GetComponent<Text>().text = i.ToString();
                
                // Dash
                RectTransform dashX = Instantiate(_dashTemplateX);
                dashX.SetParent(_graphContainer,false);
                dashX.gameObject.SetActive(true);
                dashX.anchoredPosition = new Vector2(xPosition,-3f);
                
            }

            int separatorCount = 8;
            for (int i = 0; i <= separatorCount; i++)
            {
                RectTransform labelY = Instantiate(_labelTemplateY);
                labelY.SetParent(_graphContainer,false);
                labelY.gameObject.SetActive(true);
                float normalizedValue = i * 1f / separatorCount;
                labelY.anchoredPosition = new Vector2(-7f,normalizedValue*graphHeight);
                labelY.GetComponent<Text>().text = Mathf.RoundToInt(normalizedValue*yMax).ToString();
                
                RectTransform dashY = Instantiate(_dashTemplateY);
                dashY.SetParent(_graphContainer,false);
                dashY.gameObject.SetActive(true);
                dashY.anchoredPosition = new Vector2(-4f,normalizedValue*graphHeight);
            }
        }

        private void CreateDotConnection(Vector2 dotPositionA, Vector2 dotPositionB)
        {
            var dotConnection = new GameObject("dotConnection", typeof(Image));
            dotConnection.transform.SetParent(_graphContainer, false);
            dotConnection.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
            RectTransform rectTransform = dotConnection.GetComponent<RectTransform>();
            Vector2 dir = (dotPositionB - dotPositionA).normalized;
            float distance = Vector2.Distance(dotPositionA, dotPositionB);
            rectTransform.anchorMin = new Vector2(0, 0);
            rectTransform.anchorMax = new Vector2(0, 0);
            rectTransform.sizeDelta = new Vector2(distance, 3f);
            rectTransform.anchoredPosition = dotPositionA + dir * distance * .5f;
            rectTransform.localEulerAngles = new Vector3(0, 0, GetAngleFromVectorFloat(dir));
        }

        private static float GetAngleFromVectorFloat(Vector3 dir)
        {
            dir = dir.normalized;
            var n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            if (n < 0) n += 360;

            return n;
        }
    }
}