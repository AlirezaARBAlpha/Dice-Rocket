using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceCheckZoneScript : MonoBehaviour {

	Vector3 diceVelocity;
	[SerializeField]
    public GameManager gameManager;
	// Update is called once per frame
	void FixedUpdate () {
		diceVelocity = DiceScript.diceVelocity;
	}

	void OnTriggerStay(Collider col)
	{
		if (diceVelocity.x == 0f && diceVelocity.y == 0f && diceVelocity.z == 0f)
		{
			switch (col.gameObject.name) {
			case "Side1":
				//DiceNumberTextScript.diceNumber = 6;
				gameManager.ShiftRocket(60);
				break;
			case "Side2":
				//DiceNumberTextScript.diceNumber = 5;
				gameManager.ShiftRocket(50);
				break;
			case "Side3":
				//DiceNumberTextScript.diceNumber = 4;
				gameManager.ShiftRocket(40);
				break;
			case "Side4":
				//DiceNumberTextScript.diceNumber = 3;
				gameManager.ShiftRocket(30);
				break;
			case "Side5":
				//DiceNumberTextScript.diceNumber = 2;
				gameManager.ShiftRocket(20);
				break;
			case "Side6":
				//DiceNumberTextScript.diceNumber = 1;
				gameManager.ShiftRocket(10);
				break;
			}
		}
	}
}
