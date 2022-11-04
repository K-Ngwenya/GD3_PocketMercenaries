using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour
{
    public Unit[] enemyUnits;
    public Sprite[] enemyCharacters;
    [SerializeField] GameObject healthBarE;
    [SerializeField] PlayerControls player;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject myTurn;
    [SerializeField] GameObject enemyTurn;
    [SerializeField] int switchDelay;
    public int health1E;
    public int health2E;
    public int health3E;
    public int attack1E;
    public int attack2E;
    public int attack3E;
    private const float maxHP = 100;
    private SpriteRenderer creatorE;
    private GameObject friendlyUnit;
    private Image theBar;
    private Sprite face;
    private int characterNum;
    public Unit enemyFocus;
    public float HealthE;


    private void Start() 
    {
        characterNum = 0;

        theBar = healthBarE.GetComponent<Image>();

        enemy = GameObject.Find("EnemyUnit");

        enemyUnits[0] = ScriptableObject.CreateInstance<Unit>();
        enemyUnits[1] = ScriptableObject.CreateInstance<Unit>();
        enemyUnits[2] = ScriptableObject.CreateInstance<Unit>();

        face = enemyCharacters[0];
        init(enemyUnits[0], "SwordGuy", 100, 25, face);
        face = enemyCharacters[1];
        init(enemyUnits[1], "HorseGuy", 250, 50, face);
        face = enemyCharacters[2];
        init(enemyUnits[2], "BowGuy", 50, 15, face);

        HealthE = enemyUnits[0].health;

        enemyFocus = enemyUnits[characterNum];

        creatorE = enemy.GetComponent<SpriteRenderer>();

        RenderCharacter();
    }

    private void Update() {
        
            theBar.fillAmount = HealthE/enemyUnits[characterNum].health;

            if(HealthE <= 0)
            {
                characterNum +=1;
                RenderCharacter();
                HealthE = enemyUnits[characterNum].health;
            }

           if(characterNum == 0)
            {
                creatorE.sprite = enemyCharacters[0];
            }
            else if(characterNum == 1)
            {
                creatorE.sprite = enemyCharacters[1];
            }
            else if(characterNum == 2)
            {
                creatorE.sprite = enemyCharacters[2];
            }
    }

    private void RenderCharacter()
    {
        enemyFocus = enemyUnits[characterNum];
        creatorE.sprite = enemyCharacters[characterNum];
    }

    public void TakeDamage(float damage)
    {
        HealthE -= damage;
    }

    private IEnumerator switchBackDelay()
    {
        yield return new WaitForSeconds(switchDelay);
        enemyTurn.SetActive(false);
        myTurn.SetActive(true);
    }

    public void Attack()
    {
        float damage = enemyUnits[characterNum].attack;
        Debug.Log("Pow! E" + damage);
        player.TakeDamage(damage);
    }

    private void init(Unit unit, string name, int health, int attack, Sprite sprite)
    {
        unit.unitName = name;
        unit.health = health;
        unit.attack = attack;
        unit.artwork = sprite;
    }

}
