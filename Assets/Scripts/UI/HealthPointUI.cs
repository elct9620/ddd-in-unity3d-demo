using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class HealthPointUI : MonoBehaviour
	{
		public int current = 0;
		public int max = 0;
		private TextMeshProUGUI _component;

		public void Refresh(int newCurrent, int newMax)
		{
			current = newCurrent;
			max = newMax;

			if (_component == null)
			{
				return;
			}
			
			_component.text = $"HP: {this.current}/{this.max}";
			if (current <= 0)
			{
				_component.color = Color.red;		
			}
		}

		void Start()
		{
			_component = this.GetComponent<TextMeshProUGUI>();
		}
	}
}