using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;

	public int enemyInBack;
	public int playerMoney;

	[SerializeField] private float scaleMultiplier;

	[SerializeField] private Transform[] backEnemyPos;

	[SerializeField] private GameObject[] enemy;
	[SerializeField] private GameObject playerGO;
	[SerializeField] private GameObject shopPanel;

	[SerializeField] private Renderer playerRenderer;
	[SerializeField] private Material materialRedSkin;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	void Start()
	{
		enemyInBack = 0;
		playerMoney = 50;	
	}	

	public void EnemyCollect()
	{
		if(enemyInBack == 0)
		{
			enemy[0].SetActive(true);
			enemy[0].transform.position = backEnemyPos[0].position;
			enemyInBack += 1;			
		}
		else if (enemyInBack == 1)
		{
			enemy[1].SetActive(true);
			enemy[1].transform.position = backEnemyPos[1].position;
			enemyInBack += 1;			
		}
		else if (enemyInBack == 2)
		{
			enemy[2].SetActive(true);
			enemy[2].transform.position = backEnemyPos[2].position;
			enemyInBack += 1;			
		}
		else if (enemyInBack == 3)
		{
			enemy[3].SetActive(true);
			enemy[3].transform.position = backEnemyPos[3].position;
			enemyInBack += 1;			
		}
		else if (enemyInBack == 4)
		{
			enemy[4].SetActive(true);
			enemy[4].transform.position = backEnemyPos[4].position;
			enemyInBack += 1;			
		}
	}

	public void MoneyCollect()
	{
		if (enemyInBack == 0)
		{
			Debug.Log("you dont have enemies");

		}
		else if (enemyInBack == 1)
		{
			enemy[0].SetActive(false);
			enemyInBack -= 1;
			playerMoney += 5;
		}
		else if (enemyInBack == 2)
		{
			enemy[0].SetActive(false);
			enemy[1].SetActive(false);
			enemyInBack -= 2;
			playerMoney += 10;

		}
		else if (enemyInBack == 3)
		{
			enemy[0].SetActive(false);
			enemy[1].SetActive(false);
			enemy[2].SetActive(false);
			enemyInBack -= 3;
			playerMoney += 15;
		}
		else if (enemyInBack == 4)
		{
			enemy[0].SetActive(false);
			enemy[1].SetActive(false);
			enemy[2].SetActive(false);
			enemy[3].SetActive(false);
			enemyInBack -= 4;
			playerMoney += 20;
		}
		else if (enemyInBack == 5)
		{
			enemy[0].SetActive(false);
			enemy[1].SetActive(false);
			enemy[2].SetActive(false);
			enemy[3].SetActive(false);
			enemy[4].SetActive(false);
			enemyInBack -= 5;
			playerMoney += 25;
		}
	}

	//LEVEL UPS

	public void ChangeColorLevelUp()
	{
		if (playerMoney >= 50)
		{
			playerMoney -= 50;
			UIManager.instance.DisableSkinBuyButton();
			playerRenderer.material.SetColor("_Color", Color.red);
		}
		else
		{
			Debug.Log("you dont have money");
		}
	}

	public void ChangeScaleLevelUp()
	{
		if (playerMoney >= 50)
		{
			playerMoney -= 50;
			UIManager.instance.DisableScaleBuyButton();
			playerGO.transform.localScale = new Vector3(playerGO.transform.localScale.x * scaleMultiplier, playerGO.transform.localScale.x * scaleMultiplier, playerGO.transform.localScale.x * scaleMultiplier);
		}
		else
		{
			Debug.Log("you dont have money");
		}
	}

	public void ShopPanel(bool PlayerOnShop)
	{		
		shopPanel.SetActive(PlayerOnShop);
	}
}
