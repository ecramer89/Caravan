using UnityEngine;
using System.Collections;

public class Merchant : Event {


	public override void activateEvent (GameObject desertExplorer){
		Debug.Log ("merchant");
		explorer = desertExplorer;
		tellPlayerToFinishEndTurn();
		
	}

	protected override void takeEffect(){


		
	}
}
