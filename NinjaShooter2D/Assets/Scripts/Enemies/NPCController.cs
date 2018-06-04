using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class NPCController : MonoBehaviour
{
	public Character npc;

	private float health;
	private float defense;

	void Start()
	{
		health = npc.maxHealth;
	}

	public void ReceiveDamage(float damage)
	{
		float damageFactor = 100.0f / (100.0f + npc.defense);
		health -= damageFactor * damage;
		if (health < 0) health = 0.0f;
	}

	public void Recover(float healthAmount)
	{
		health += healthAmount;
		if (health - npc.maxHealth > 0) health = npc.maxHealth;
	}

	public void Attack()
	{
		
	}
}
