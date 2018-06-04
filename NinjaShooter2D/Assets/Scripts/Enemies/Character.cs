using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NPC", menuName = "NPC Properties")]
public class Character : ScriptableObject {
	
	public string displayName;
	
	public float maxHealth;
	public float attackPower;
	public float defense;

}
