﻿using UnityEngine;
using System.Collections;

public class Barter : MonoBehaviour {

	public GameObject offerPlacement;
	public GameObject targetPlacement;
	public GameObject meeplePlacement;
	public GameController controller;

	void Start(){
		offerPlacement.GetComponent<BarterPlacement> ().barter = this;
		targetPlacement.GetComponent<BarterPlacement> ().barter = this;

		controller = GameObject.Find ("GameController").GetComponent<GameController> ();

		}
	public void AttemptToCompleteBarter () {
		if (meeplePlacement.GetComponent<DropLocation> ().Occupied () &&
						offerPlacement.GetComponent<BarterPlacement> ().Occupied () &&
						targetPlacement.GetComponent<BarterPlacement> ().Occupied ()) {


			GoodToken offerToken = offerPlacement.GetComponent<BarterPlacement> ().Occupant().GetComponent<GoodToken>();
			GoodToken targetToken = targetPlacement.GetComponent<BarterPlacement> ().Occupant().GetComponent<GoodToken>();

			offerToken.player.gameObject.GetComponent<PlayerInventory>().increaseGood(targetToken.good,targetToken.gameObject);
			offerToken.player.gameObject.GetComponent<PlayerInventory>().removeGoods(offerToken.good,1, offerToken.gameObject);

			targetToken.player.gameObject.GetComponent<PlayerInventory>().increaseGood(offerToken.good,offerToken.gameObject);
			targetToken.player.gameObject.GetComponent<PlayerInventory>().removeGoods(targetToken.good,1, offerToken.gameObject);

			Object.Destroy (targetToken.gameObject);
			Object.Destroy(offerToken.gameObject);
		
			controller.LogEvent ("barter,"+offerToken.good+"O,"+targetToken.good+"T,"+targetToken.player.gameObject.GetComponent<Player>().id+"V,");

	


						controller.getNextPlayer ();
		    
				}
		}

	public bool ShouldAllowPlacement(GoodToken token, BarterPlacement place) {
		if (place == offerPlacement) {
			return token.player == controller.currentPlayer ();
				} else {
			return true;
				}
	}

}
