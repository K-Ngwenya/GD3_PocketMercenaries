using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public Unit[] friendlyUnits;
    private EnemyAI enemyScript;
    private GameObject enemy;
    private GameObject player;
    

    private void Start() {
        enemy = GameObject.Find("EnemyUnit");
        enemyScript = enemy.GetComponent<EnemyAI>();

        friendlyUnits[0] = ScriptableObject.CreateInstance<Unit>();
        friendlyUnits[1] = ScriptableObject.CreateInstance<Unit>();
        friendlyUnits[2] = ScriptableObject.CreateInstance<Unit>();

        init(friendlyUnits[0], "SwordGuy", 100, 25);
        init(friendlyUnits[1], "HorseGuy", 100, 50);
        init(friendlyUnits[2], "BowGuy", 100, 15);
    }

    private void init(Unit unit, string name, int health, int attack)
    {
        unit.unitName = name;
        unit.health = health;
        unit.attack = attack;
    }

    public void Attack()
    {
        Debug.Log("Pow!");
        float damage = friendlyUnits[0].attack;
        enemyScript.Health -= damage;
    }
}
