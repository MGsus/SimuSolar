using System.Collections.Generic;
using System.Linq;
using CodeMonkey.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace Graph
{
	public class WindowGraph : MonoBehaviour
	{
		[SerializeField] private Sprite _circleSprite;
		private RectTransform _graphContainer;
		private GameManager _manager;
		

		// Use this for initialization
		private void Awake()
		{
			_graphContainer = transform.Find("graphContainer").GetComponent<RectTransform>();
			List<int> valueList = new List<int>(){ 5,98,45,30,22,17,15,13,17,25,37,40,36,33};
			_manager = GameObject.FindGameObjectWithTag("Juego").GetComponent(typeof(GameManager))as GameManager;
//			ShowGraph(valueList); // Cada hora ejecutar
		}

		private void FixedUpdate()
		{
			ShowGraph();
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
			List<int> Money = _manager.LogMoney;
			float graphHeight = _graphContainer.sizeDelta.y;
			float yMax = Money.Max();
			const float xSize = 50f;
			GameObject lastCircleGameObject = null;
			for (var i = _manager.HoraAct-1; i < _manager.HoraAct; i++)
			{
				float xPosition = xSize + i * xSize;
				float yPosition = Money[i] / yMax * graphHeight;
				CreateCircle(new Vector2(xPosition, yPosition));
				GameObject circleGameObject = CreateCircle(new Vector2(xPosition, yPosition));
				if (lastCircleGameObject != null)
				{
					CreateDotConnection(lastCircleGameObject.GetComponent<RectTransform>().anchoredPosition,
						circleGameObject.GetComponent<RectTransform>().anchoredPosition);
				}
				lastCircleGameObject = circleGameObject;
			}
		}

		private void CreateDotConnection(Vector2 dotPositionA, Vector2 dotPositionB)
		{
			var dotConnection = new GameObject("dotConnection", typeof(Image));
			dotConnection.transform.SetParent(_graphContainer, false);
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
		}﻿
	}
}
