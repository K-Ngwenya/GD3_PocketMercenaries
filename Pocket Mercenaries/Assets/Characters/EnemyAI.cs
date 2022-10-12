using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour
{
    public Unit[] enemyUnits;
    private const float maxHP = 100;
    public float Health;
    [SerializeField] GameObject healthBar;
    private GameObject friendlyUnit;
    private Image theBar;
    

    private void Start() 
    {
        theBar = healthBar.GetComponent<Image>();

        enemyUnits[0] = ScriptableObject.CreateInstance<Unit>();
        enemyUnits[1] = ScriptableObject.CreateInstance<Unit>();
        enemyUnits[2] = ScriptableObject.CreateInstance<Unit>();

        init(enemyUnits[0], "SwordGuy", 100, 25);
        init(enemyUnits[1], "HorseGuy", 100, 50);
        init(enemyUnits[2], "BowGuy", 100, 15);

        Health = enemyUnits[0].health;
    }

    private void Update() {
        //Health = enemyUnits[0].health;
        theBar.fillAmount = Health/maxHP;
    }

    private void init(Unit unit, string name, int health, int attack)
    {
        unit.unitName = name;
        unit.health = health;
        unit.attack = attack;
    }

}
