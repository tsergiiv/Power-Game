using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour {

	public Text userInput1;
	public Text userInput2;

	public Image imageInput1;
	public Image imageInput2;

	public int solution1;
	public int solution2;

	public Button hintImage;
	public Text hints;
	public GameObject winPopUp;
	public Canvas mainCanvas;

	// additional variables
	int totalSolution = 0;
	int activeInput = 1;
	int hintAmount = 3;
	int userNum1 = 0;
	int userNum2 = 0;
	int userSum = 0;
	int hintUsed = 0;

	void Start() {
		totalSolution = solution1 * solution1 + solution2 * solution2;
		changeActive (1);
	}

	// called when user click on one button of the keyboard
	public void _click(int number) {
		if (activeInput == 1) {
			if (this.userNum1 < 10) {
				int newValue = (this.userNum1 * 10 + number);
				userInput1.text = newValue.ToString ();
				this.userNum1 = newValue;
			}
		} else {
			if (this.userNum2 < 10) {
				int newValue = (this.userNum2 * 10 + number);
				userInput2.text = newValue.ToString ();
				this.userNum2 = newValue;
			}
		}

		checkWin ();
	}

	// check whether user win a level
	public void checkWin() {
		userSum = userNum1 * userNum1 + userNum2 * userNum2;
		if (userSum == totalSolution && userNum1 > 0 && userNum2 > 0) {
			Debug.Log ("win");
			//showWinPopUp ();
		}
	}

	// clear one digit from acrive number and change an active field
	public void clear() {
		if (activeInput == 1) {
			int newValue = userNum1/10 ;
			if (newValue == 0)
				userInput1.text = "?";
			else 
				userInput1.text = newValue.ToString();
			userNum1 = newValue;
		} else {
			Debug.Log (userNum2);
			if (userNum2 > 0) {
				int newValue = userNum2/10 ;
				if (newValue == 0) 
					userInput2.text = "?";
				else 
					userInput2.text = newValue.ToString();
				userNum2 = newValue;
			} else {
				if (hintUsed == 0)
					changeActive(1);
			}
		}
	}

	// called when user press hint button
	// reduce hint amount and show one number to user
	public void hint() {
		if (hintAmount > 0) {
			hintAmount--;
			hintUsed++;
			if (hintUsed == 1) {
				Destroy (imageInput1);
				changeActive (2);
				userNum1 = solution1;
				userInput1.text = solution1.ToString ();
			} else {
				Destroy (imageInput2);
				userNum2 = solution2;
				userInput2.text = solution2.ToString ();
			}
			hints.text = hintAmount.ToString ();
		} 
		checkWin ();
	}

	public void showWinPopUp() {
		Debug.Log ("right");
		winPopUp.transform.parent = mainCanvas.transform;
	}

	// change active input field
	public void changeActive (int n) {
		activeInput = n;
		if (n == 1) {
			imageInput1.GetComponent<Image> ().color = new Color32 (0, 255, 0, 255);
			imageInput2.GetComponent<Image> ().color = new Color32 (255, 255, 255, 255);
		} else {
			imageInput1.GetComponent<Image> ().color = new Color32 (255, 255, 255, 255);
			imageInput2.GetComponent<Image> ().color = new Color32 (0, 255, 0, 255);
		}
	}
		
}
