using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollActive : MonoBehaviour
{
	[SerializeField] private BoxCollider boxCollider;
	[SerializeField] private GameObject enemyGO;
	[SerializeField] private Animator enemyAnim;
	[SerializeField] private Rigidbody enemyRigibody;
	private Collider[] ragDollColliders;
	private Rigidbody[] limbsRigidbodies;	

	void Start()
	{
		GetRagdollAndRigidbodies();
		RagDollOff();
	}
	
	private void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Punch" && GameManager.instance.enemyInBack != 5)
		{
			RagDollOn();			
			Destroy(gameObject, 1f);
		}
	}

	//coleta todos os colliders e rigidbodies do GameObject
	void GetRagdollAndRigidbodies()
	{
		ragDollColliders = enemyGO.GetComponentsInChildren<Collider>();
		limbsRigidbodies = enemyGO.GetComponentsInChildren<Rigidbody>();
	}

	//desativa o RagDoll
	void RagDollOff()
	{
		foreach (Collider col in ragDollColliders)
		{
			col.enabled = false;
		}

		foreach (Rigidbody rig in limbsRigidbodies)
		{
			rig.isKinematic = true;
		}

		enemyAnim.enabled = true;
		boxCollider.enabled = true;
		enemyRigibody.isKinematic = false;
	}

	//ativa o RagDoll
	public void RagDollOn()
	{		
		enemyAnim.enabled = false;

		foreach (Collider col in ragDollColliders)
		{
			col.enabled = true;
		}

		foreach (Rigidbody rig in limbsRigidbodies)
		{
			rig.isKinematic = false;
		}

		boxCollider.enabled = false;
		enemyRigibody.isKinematic = true;
	}

	//espera o objeto ser destruido para coletar
	private void OnDestroy()
	{
		GameManager.instance.EnemyCollect();
	}
}