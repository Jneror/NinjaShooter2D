using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class EnemyController : MonoBehaviour
{
	public enum dir { down, up, right, left }

	public Character npc;
	public dir initialDirection;
	public int attackDistance;
	public GameObject player;
	public float triggerRadius = 10;

	private Rigidbody2D rb;
	private float health;
	private Vector2 direction;
	private PlayerController playerController;

	void Start()
	{
		health = npc.maxHealth;
		SetDirection(initialDirection);

		rb = GetComponent<Rigidbody2D>();
		rb.drag = 0.0f;

		playerController = player.GetComponent<PlayerController>();
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

	public void Recover(float healthAmount)
	{
		health += healthAmount;
		if (health - npc.maxHealth > 0) health = npc.maxHealth;
	}

	public void MoveDirection(Vector2 newDirection)
	{
		direction = newDirection.normalized;
		rb.MovePosition(rb.position + direction * npc.moveVelocity);
	}

	public float PlayerDistance()
	{
		return (player.transform.position - transform.position).magnitude;
	}
	
	public bool CanHitPlayer()
	{
		return (PlayerDistance() < attackDistance);
	}

	public bool CanSeePlayer()
	{
		return (PlayerDistance() < triggerRadius);
	}

	public void FollowPlayer()
	{
		MoveDirection(player.transform.position - transform.position);
	}

	public void GoForward()
	{
		Vector2 position = new Vector2(rb.position.x, rb.position.y);
		rb.MovePosition(position + npc.moveVelocity * direction);
	}

	public bool Attack()
	{
		RaycastHit2D hit = Physics2D.Raycast(rb.position, direction, attackDistance);
		if (hit && hit.collider.tag == "Player" && CanHitPlayer())
		{
			playerController.ReceiveDamage(npc.attackPower);
			return true;
		}
		return false;
	}
}
