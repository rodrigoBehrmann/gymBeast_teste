using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTrigger : MonoBehaviour
{
	private void OnTriggerEnter(Collider col)
	{
		if (col.CompareTag("Player"))
		{
			GameManager.instance.ShopPanel(true);
		}
	}

	private void OnTriggerExit(Collider col)
	{
		if (col.CompareTag("Player"))
		{
			GameManager.instance.ShopPanel(false);
		}
	}
}
