using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class NPCController : MonoBehaviour
{
	public Character npc;
	private Rigidbody2D rb;
	public enum dir { down, up, right, left }

	private float health;

	private Vector3 direction;
	public dir initialDirection;
	public int attackDistance;

	void Start()
	{
		health = npc.maxHealth;
		SetDirection(initialDirection);

		rb = GetComponent<Rigidbody2D>();
		rb.drag = 0.0f;
	}

	private void SetDirection(dir newDirection)
	{
		switch (newDirection)
		{
			case dir.down:
				direction = Vector3.down;
				break;
			case dir.up:
				direction = Vector3.up;
				break;
			case dir.left:
				direction = Vector3.left;
				break;
			case dir.right:
				direction = Vector3.right;
				break;
			default:
				break;
		}
	}

	public void ReceiveDamage(float damage)
	{
		health -= damage;
		if (health < 0) health = 0.0f;
	}

	private void Recover(float healthAmount)
	{
		health += healthAmount;
		if (health - npc.maxHealth > 0) health = npc.maxHealth;
	}

	private void SetVelocity(Vector2 vel)
	{
		rb.velocity = vel;
		direction = vel.normalized;
	}

	public void Stop()
	{
		rb.velocity = Vector2.zero;
	}

	private bool Attack()
	{
		RaycastHit2D hit = Physics2D.Raycast(rb.position, direction, attackDistance);
		return (hit.collider.tag == "Player");
	}
}
