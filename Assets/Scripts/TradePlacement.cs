﻿using UnityEngine;
using System.Collections;

public class TradePlacement : DropLocation {
	public DesertGenerator.GoodItem good;

	// Use this for initialization
	void Start () {
		label = "trade_placement";
	}

	public void setGood(DesertGenerator.GoodItem good_item) {
		GameObject desert = GameObject.Find("Desert");
		good = good_item;
		GetComponent<SpriteRenderer> ().sprite = desert.GetComponent<DesertTileIndex> ().goodTileSprites [(int)good];
	}



	// Update is called once per frame
	void Update () {
	
	}
}
