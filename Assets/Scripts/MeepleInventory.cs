using UnityEngine;
using System.Collections;

public class MeepleInventory : MonoBehaviour
{

		public GUIText goodsAcquiredOfMovingExplorer;
		// Use this for initialization

		void Start ()
		{
				goodsAcquiredOfMovingExplorer.transform.position = Camera.main.WorldToViewportPoint (transform.position);

				wipeGoodsAcquiredText ();
	
		}

		public void wipeGoodsAcquiredText ()
		{
				goodsAcquiredOfMovingExplorer.text = "";
		}
	

}
