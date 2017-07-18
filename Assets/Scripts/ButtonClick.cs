using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour {

	public Text amount;

	public void _click(int number) {
		int start = int.Parse(amount.text);
		amount.text = (start*10 + number).ToString();
	}
}
